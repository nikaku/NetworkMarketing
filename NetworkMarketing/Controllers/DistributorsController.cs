using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkMarketing.BL.Dtos.DistributorDtos;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Filters;
using NetworkMarketing.BL.Interfaces;

namespace NetworkMarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistributorService _distributorService;

        public DistributorsController(IUnitOfWork unitOfWork, IMapper mapper, IDistributorService distributorService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributorService = distributorService;
        }

        [HttpPost]
        public IActionResult Create(CreateDistributorDto distributorDto)
        {
            var distributor = _mapper.Map<Distributor>(distributorDto);
            var recomendatorReferalsCount = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == distributorDto.RecomendatorId).Count();
            var recomendator = _unitOfWork.DistributorRepository.Find(x => x.Id == distributorDto.RecomendatorId);
            var result = _distributorService.CreateDistributor(distributor, recomendatorReferalsCount, recomendator);
            if (result.IsSuccess)
            {
                var res = _unitOfWork.DistributorRepository.Add(distributor);
                _unitOfWork.Complete();
                return CreatedAtAction(nameof(Get), new { id = res.Id }, res.Id);
            }
            else
            {
                return UnprocessableEntity(result.Mesasage);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var distributor = _unitOfWork.DistributorRepository.Get(id);
            if (distributor == null)
            {
                return NotFound();
            }
            var distributorDto = _mapper.Map<GetDistributorDto>(distributor);
            return Ok(distributorDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var distributors = _unitOfWork.DistributorRepository.GetAll();
            var distributorDtos = _mapper.Map<IEnumerable<GetDistributorDto>>(distributors);
            return Ok(distributorDtos);
        }

        [HttpPost]
        [Route("CalculateBonus")]
        public IActionResult CalculateBonus(DistributorFilter filter)
        {
            decimal result = 0;
            Distributor distributtor;
            List<Distributor> distributorChilds;
            List<Distributor> distGrandChilds;
            distributtor = _unitOfWork.DistributorRepository
               .Find(x => x.Id == filter.id && x.SalesOrders
               .Where(x => filter.startDate < x.PostingDate && filter.EndDate > x.PostingDate).Count() > 1);

            if (distributtor == null)
            {
                return NotFound();
            }

            distributorChilds = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == filter.id).ToList();
            foreach (var distributorChild in distributorChilds)
            {
                distGrandChilds = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == distributorChild.Id).ToList();
            }

            result = _distributorService.CalculateCumulativeBonus(distributtor, distributorChilds, distributorChilds);

            return Ok(result);
        }
    }
}