using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkMarketing.BL.Dtos.SalesOrderDtos;
using NetworkMarketing.BL.Entities;
using NetworkMarketing.BL.Interfaces;

namespace NetworkMarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SalesOrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateSalesOrderDto salesOrderDto)
        {
            var salesOrder = _mapper.Map<SalesOrder>(salesOrderDto);
            decimal totalPrice = 0;

            foreach (var row in salesOrder.Rows)
            {
                var unitPrice = _unitOfWork.ItemRepository.Get(row.ItemId).UnitPrice;
                totalPrice += unitPrice * row.Quantity;
                row.LineTotal = row.Quantity * unitPrice;
            }

            salesOrder.TotalPrice = totalPrice;
            var res = _unitOfWork.SalesOrderRepository.Add(salesOrder);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { id = res.Id }, res.Id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var salesOrder = _unitOfWork.SalesOrderRepository.Get(id);
            if (salesOrder == null)
            {
                return NotFound();
            }
            var salesOrderDto = _mapper.Map<GetSalesOrderDto>(salesOrder);
            return Ok(salesOrderDto);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var salesOrders = _unitOfWork.ItemRepository.GetAll();
            var salesOrderDtos = _mapper.Map<IEnumerable<GetSalesOrderDto>>(salesOrders);
            return Ok(salesOrderDtos);
        }
    }
}