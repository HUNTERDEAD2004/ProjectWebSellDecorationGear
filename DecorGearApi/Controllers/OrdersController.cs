using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearApplication.Interface;
using DecorGearInfrastructure.implement;
using System.Threading;
using DecorGearApplication.DataTransferObj.Order;

namespace DecorGearApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOderRespository _orderRepo;
        

        public OrdersController(IOderRespository oderRespository)
        {
           _orderRepo = oderRespository;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OderDto>>> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetAllOder(cancellationToken); 
            return Ok(orders); 
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OderDto>> GetByIdOrder(int id, CancellationToken cancellationToken)
        {
            var request = new ViewOrderRequest { OderID = id };
            var order = await _orderRepo.GetKeyOderById(request, cancellationToken);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }        
    }
}
