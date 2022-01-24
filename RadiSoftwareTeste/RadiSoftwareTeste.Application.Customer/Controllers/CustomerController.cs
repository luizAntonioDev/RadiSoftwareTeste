using Microsoft.AspNetCore.Mvc;
using RadiSoftwareTeste.Domain.Interface.Service;
using RadiSoftwareTeste.Domain.Models.DTO.Request;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Models;
using System;

namespace RadiSoftwareTeste.Application.Customer.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ApiBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("save")]
        [HttpPost]
        public IActionResult InsertCustomer([FromBody] CreateCustomerRequest request)
        {
            try
            {
                var customer = _customerService.CreateCustomer(request);

                return Ok(BaseResponse(customer));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, "Error to insert customer."));
            }

        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(BaseResponse(customers));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, "Error on return all customers."));
            }
        }

        [Route("{customerId}")]
        [HttpGet]
        public IActionResult GetCustomerById([FromRoute] Guid customerId)
        {
            try
            {
                var customer = _customerService.GetCustomerBy(customerId);
                if (customer == null) return NoContent();
                return Ok(BaseResponse(customer));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error on return client information."));
            }
        }

        [Route("wallet/{customerId}")]
        [HttpGet]
        public IActionResult GetCustomerWallet([FromRoute] Guid customerId)
        {
            try
            {
                var customer = _customerService.GetCustomerWallet(customerId);
                return Ok(BaseResponse(customer));
            }
            catch (Exception e)
            {

                return BadRequest(BaseResponse(e.Message, false, $"Error on return client information."));
            }
        }
    }
}
