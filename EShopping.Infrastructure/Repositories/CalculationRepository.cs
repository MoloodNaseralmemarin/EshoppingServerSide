using DataLayer.Entities.Products;
using EShopping.Core.Entities.Calculations;
using EShopping.Core.Entities.Ordering;
using EShopping.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<ProductSelectedCalculationModel> _productSelectedCalculation;

        public CalculationRepository(IGenericRepository<CalculationModel> calculationRepository, IGenericRepository<ProductSelectedCalculationModel> productSelectedCalculation)
        {
            _calculationRepository = calculationRepository;
            _productSelectedCalculation = productSelectedCalculation;
        }
        int purchasePrice = 0;
        public async Task<List<ProductSelectedCalculationModel>> CalculationByProductId(int productId)
        {
            return await _productSelectedCalculation.GetAll()
                .Where(s => s.ProductId == productId).ToListAsync();

        }

        public async Task<List<CalculationModel>> GetAll()
        {
            return await _calculationRepository.GetAll().ToListAsync();
        }

        public async Task<int> GetWagePrice(long id)
        {
            CalculationModel model=await _calculationRepository.GetEntityById(id);
            return model.PurchasePrice;
        }

        public void Dispose()
        {
            _calculationRepository?.Dispose();
        }

        public async Task<int> GetPackagingPrice(int id)
        {
            CalculationModel model = await _calculationRepository.GetEntityById(id);
            return model.PurchasePrice;
        }

        public async Task<int> GetPriceById(int id)
        {
            var query = await _calculationRepository.GetEntityById(id);
            if(query!=null)
                return query.PurchasePrice;
            return 0;
        }


        public async Task<int> GetMagnetPrice(int height)
        {
            int resultcountMagnet = 0;
        
            switch (height)
            {
                case int n when (n >= 0 && n <= 200):
                purchasePrice =await GetPriceById(9);
                    resultcountMagnet = height - 20 / (int)1.01D * 2;
                    break;
                case int n when (n >= 200 && n <= 400):
                purchasePrice = await GetPriceById(9);
                     resultcountMagnet = height - 20 / (int)1.01D * 2;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return resultcountMagnet;
        }

        public Task<int> CalculationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetZipper5Price(int width)
        {
            purchasePrice = await GetPriceById(5);
            int resultzipper5Price =(width+5) * (int)0.01D * purchasePrice;
            return resultzipper5Price;
  
        }

        public async Task<int> GetGlue4Price(int width)
        {
            purchasePrice = await GetPriceById(5);
            int resultGlue4Price = (width + 5) * (int)0.01D * purchasePrice;
            return resultGlue4Price;
        }

        public async Task<int> GetGlue2Price(int height)
        {
            int heightNew = GetHeightNew(height);
            purchasePrice = await GetPriceById(5);
            int resultGlue2Price = heightNew / 1000 * purchasePrice;
            return resultGlue2Price;
        }
        public async Task<int> GetZipper2Price(int height)
        {
            int heightNew = GetHeightNew(height);
            purchasePrice = await GetPriceById(5);
            int resultZipper2Price = heightNew / 1000 * purchasePrice;
            return resultZipper2Price;
        }

        public int GetHeightNew(int height)
        {
            int heightNew = 0;
            switch (height)
            {
                case int n when (n >= 0 && n <= 230):
                    heightNew = 90;
                    break;
                case int n when (n >= 231 && n <= 270):
                    heightNew = 110;
                    break;
                case int n when (n >= 271 && n <= 300):
                    heightNew = 125;
                    break;
                case int n when (n >= 301 && n <= 330):
                    heightNew = 145;
                    break;
                case int n when (n >= 331 && n <= 360):
                    heightNew = 165;
                    break;
                case int n when (n >= 361 && n <= 400):
                    heightNew = 185;
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return heightNew;
        }

        public async Task<int> GetChodonPrice()
        {
            purchasePrice = await GetPriceById(7);
            int resultChodon = (int)1.05D * purchasePrice;
            return resultChodon;
        }

        public async Task<int> GetNavarganPrice()
        {
            purchasePrice = await GetPriceById(8);
            int resultNavargan = (int)1.05D * purchasePrice;
            return resultNavargan;
        }


}

}
