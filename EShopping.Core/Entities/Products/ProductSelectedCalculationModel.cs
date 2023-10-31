
using DataLayer.Entities.Common;
using EShopping.Core.Entities.Calculations;

namespace DataLayer.Entities.Products
{
    public class ProductSelectedCalculationModel : BaseEntity
    {
        #region Properties

        public int ProductId { get; set; }

        public int CalculationId { get; set; }

        #endregion

        #region Relations

        public ProductModel Product { get; set; }

        public CalculationModel Calculation { get; set; }

        #endregion
    }
}
