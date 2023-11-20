using EShooping.Application.DTOs.Orders;
using EShopping.Core.Entities.Calculations;
using EShopping.Core.Entities.Ordering;
using EShopping.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.API.Controllers
{
    public class CalculationController : ApiController
    {
        private readonly ICalculationRepository _calculatorRepository;
        public CalculationController(ICalculationRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        [HttpGet]
        [Route("show-calculation")]
        public async Task<ActionResult<IList<CalculationModel>>> GetAll()
        {
            try
            {
                var query = await _calculatorRepository.GetCalculation();
                //_logger.LogInformation("All products retrieved");
                return Ok(query);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "An Exception has occured: {Exception}");
                throw;
            }

        }
    }
}
