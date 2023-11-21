using AngularEshop.Core.DTOs.Calculations;
using DataLayer.Entities.Products;
using EShopping.Core.Entities.Calculations;


namespace EShopping.Infrastructure.Repositories
{
    public interface ICalculationRepository:IDisposable
    {

        Task<List<CalculationModel>> GetCalculation();

        Task<int> GetCalculationById(int id);
        Task<decimal> GetPriceById(int id);

        Task UpdateCalculation(CalculationModel calculation);

        //فرمول دسته بندی کنم و بگم اگر این بود اینو نشون بده
        Task<List<ProductSelectedCalculationModel>> CalculationByProductId(int productId);
        int GetHeightNew(int height);

        Task<CalculationModel> GetCalculationtById(int Id);
        Task EditCalculation(EditCalculationViewModel editCalculation,int calculationId);

        #region زیپ چسب 5 سانت
        Task<decimal> GetZipper5Price(int width);
        #endregion
        #region چسب 2 طرفه 4 سانت
        Task<decimal> GetGlue4Price(int width);
        #endregion
        #region جودون
        Task<decimal> GetChodonPrice(int width);
        #endregion
        #region گان
        Task<decimal> GetGanPrice(int height);
        #endregion
        #region آهن ربا
        Task<decimal> GetMagnetPrice(int height);
        #endregion
        #region زیپ چسب 2.5 سانت
        Task<decimal> GetZipper2Price(int height);
        #endregion
        #region چسب 2 طرفه 2 سانت
        Task<decimal> GetGlue2Price(int height);
        #endregion
        #region اجرت
        Task<decimal> GetWagePrice(int id);
        #endregion
        #region بسته بندی
        Task<decimal> GetPackagingPrice(int id);
        #endregion

       







    }
}
