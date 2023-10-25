using EShopping.Core.Entities.Calculations;


namespace EShopping.Infrastructure.Repositories
{
    public interface ICalculationRepository:IDisposable
    {
        Task<CalculationModel> GetCalculationById(long id);
    }
}
