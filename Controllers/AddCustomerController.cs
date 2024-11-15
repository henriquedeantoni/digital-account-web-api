using Digital_Account_Web_Api.Models.AddCustomer;
using FluentValidation;
using Domain.Contracts.UseCases.AddCustomer;
using Microsoft.AspNetCore.Mvc;
using Digital_Account_Web_Api.Models.Error;

namespace Digital_Account_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;

        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator)
        {
            _addCustomerUseCase = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            var ValidationResult = _addCustomerInputValidator.Validate(input);

            if(!ValidationResult.IsValid)
            {
                return BadRequest(ValidationResult.Errors.ToCustomValidationFailure());
            }

            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);

            _addCustomerUseCase.AddCustomer(customer);

            return Created("", customer);
        }
    }
}
