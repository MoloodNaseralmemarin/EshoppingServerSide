using DataLayer.Entities.Products;
using EShopping.Core.Entities.Calculations;


namespace EShopping.Infrastructure.Repositories
{
    public interface ICalculationRepository:IDisposable
    {
        Task<int> GetPriceById(int id);

        //فرمول دسته بندی کنم و بگم اگر این بود اینو نشون بده
        Task<List<ProductSelectedCalculationModel>> CalculationByProductId(int productId);
        Task<int> CalculationById(int id);
        int GetHeightNew(int height);
        #region چسب دو طرفه 2 سانت
        Task<int> GetGlue2Price(int height);
        #endregion
        #region زیپ چسب 2.5 سانت
        Task<int> GetZipper2Price(int height);
        #endregion
        #region چسب دو طرفه 4 سانت
        Task<int> GetGlue4Price(int width);
        #endregion
        #region زیپ چسب5سانت
        Task<int> GetZipper5Price(int width);
        #endregion
        #region جودون
        Task<int> GetChodonPrice();
        #endregion
        #region نوارگان
        Task<int> GetNavarganPrice { get; set; }
        #endregion
        #region آهن ربا
        Task<int> GetMagnetPrice(int height);
        #endregion
        #region اجرت
        Task<int> GetWagePrice(long id);
        #endregion
        #region بسته بندی
        Task<int> GetPackagingPrice(int id);
        #endregion

       







    }
}
