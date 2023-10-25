using EShopping.Core.Entities.Calculations;
using EShopping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly IGenericRepository<CalculationModel> _calculationRepository;

        public CalculationRepository(IGenericRepository<CalculationModel> calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }
        public async Task<CalculationModel> GetCalculationById(long id)
        {
            return await _calculationRepository.GetEntityById(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
