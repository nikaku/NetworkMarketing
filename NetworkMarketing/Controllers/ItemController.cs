using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkMarketing.BL.Dtos;
using NetworkMarketing.BL.Dtos.ItemDtos;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;

namespace NetworkMarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateItemDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            var res = _unitOfWork.ItemRepository.Add(item);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { id = res.Id }, res.Id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _unitOfWork.ItemRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemDto = _mapper.Map<Item>(item);
            return Ok(itemDto);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _unitOfWork.ItemRepository.GetAll();
            var itemDtos = _mapper.Map<IEnumerable<GetItemDto>>(items);
            return Ok(itemDtos);
        }
    }
}