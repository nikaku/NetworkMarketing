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
using NetworkMarketing.BL.Interfaces;

namespace NetworkMarketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DistributorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateDistributorDto distributorDto)
        {
            var distributor = _mapper.Map<Distributor>(distributorDto);
            if (distributorDto.RecomendatorId == 0)
            {
                distributor.ReferalLevel = 0;
            }
            else
            {
                var recomendatorReferalsCount = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == distributorDto.RecomendatorId).Count();

                var recomendator = _unitOfWork.DistributorRepository.Find(x => x.Id == distributorDto.RecomendatorId);
                int referalLevel = 0;
                if (recomendator == null)
                {
                    referalLevel = 0;
                }
                else
                {
                    referalLevel = recomendator.ReferalLevel;
                }
                if (recomendatorReferalsCount > 2)
                {
                    return UnprocessableEntity("Recomendator Has More Then 3 Referals");
                }
                distributor.ReferalLevel = ++referalLevel;
                if (referalLevel > 4)
                {
                    return UnprocessableEntity("Referal Depth reached Limit");
                }


            }
            var res = _unitOfWork.DistributorRepository.Add(distributor);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { id = res.Id }, res.Id);
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
        public IActionResult CalculateBonus(DateTime startDate, DateTime EndDate, int distributorId)
        {
            decimal result = 0;
            var distributtor = _unitOfWork
                .DistributorRepository
                .Find(x => x.Id == distributorId && x.SalesOrders
                .Where(x => startDate < x.PostingDate && EndDate > x.PostingDate).Count() > 1);

            if (distributtor == null)
            {
                return NotFound();
            }
            var distributorChilds = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == distributorId).ToList();
            result += distributtor.CalculateBonus(10);
            foreach (var distributorChild in distributorChilds)
            {
                result += distributorChild.CalculateBonus(5);
                var distGrandChilds = _unitOfWork.DistributorRepository.FindAll(x => x.RecomendatorId == distributorChild.Id);
                foreach (var grandChild in distGrandChilds)
                {
                    result += grandChild.CalculateBonus(1);
                }
            }
            return Ok(result);
        }
    }
}