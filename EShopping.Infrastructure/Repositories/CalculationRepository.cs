using DataLayer.Entities.Products;
using EShopping.Core.Entities.Calculations;
using EShopping.Core.Entities.Ordering;
using EShopping.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
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
        decimal purchasePrice = 0;

        public async Task<List<CalculationModel>> GetCalculation()
        {
            return await _calculationRepository.GetEntitiesQuery()
           .ToListAsync();
        }
        public async Task<List<ProductSelectedCalculationModel>> CalculationByProductId(int productId)
        {
            return await _productSelectedCalculation.GetEntitiesQuery()
                .Where(s => s.ProductId == productId).ToListAsync();

        }

        public async Task<List<CalculationModel>> GetAll()
        {
            return await _calculationRepository.GetEntitiesQuery().ToListAsync();
        }
        public async Task<decimal> GetPriceById(int id)
        {
            var query = await _calculationRepository.GetEntityById(id);
            if(query!=null)
                return query.PurchasePrice;
            return 0;
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

       
        #region زیپ چسب 5 سانت
        public async Task<decimal> GetZipper5Price(int width)
        {
            purchasePrice = await GetPriceById(5);
            //decimal resultZipper5Price =(((width + 5) * 0.01M) * purchasePrice);
            decimal a = width + 5;
            decimal b = a * 0.01M;
            decimal c = b * purchasePrice;
            return c;
        }
        #endregion
        #region زیپ چسب 2.5 سانت
        public async Task<decimal> GetZipper2Price(int height)
        {
            decimal heightNew = GetHeightNew(height);
            purchasePrice = await GetPriceById(6);
            decimal resultZipper2Price = ((heightNew / 100) * purchasePrice);
            return resultZipper2Price;
        }
        #endregion
        #region جودون
        public async Task<decimal> GetChodonPrice(int width)
        {
            purchasePrice = await GetPriceById(7);
            decimal resultChodon =((width +2) * 0.01M) * purchasePrice;
            return resultChodon;
        }
        #endregion
        #region گان
        public async Task<decimal> GetGanPrice(int height)
        {
            purchasePrice = await GetPriceById(8);
            decimal resultGan = (((((height + 10) * 0.01M) * 4.2M) * 4) * purchasePrice);
            return resultGan;
        }
        #endregion
        #region آهن ربا
        public async Task<decimal> GetMagnetPrice(int height)
        {
            decimal resultcountMagnet = 0;
            purchasePrice = await GetPriceById(9);
            switch (height)
            {
                case int n when (n >= 0 && n <= 200):
                    resultcountMagnet = (((Math.Round((height - 20) / 13.5M) * 2)) * purchasePrice);
                    break;
                case int n when (n >= 200 && n <= 400):


                    //resultcountMagnet = (((height - 30) / 13.5M) * 2);
                    decimal a = height - 30;
                    decimal b = Math.Ceiling( a / 13.5M);
                    decimal c = b * 2;
                    decimal d = c * purchasePrice;
                    resultcountMagnet = d;
                   // resultcountMagnet = (((Math.Round((height - 30) / 13.5M) * 2)) * purchasePrice);
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            return resultcountMagnet;
        }
        #endregion
        #region چسب 2 طرفه 4 سانت
        public async Task<decimal> GetGlue4Price(int width)
        {
            purchasePrice = await GetPriceById(10);
            decimal resultGlue4Price = (((width + 5) * 0.01M) * purchasePrice);
           return resultGlue4Price;
        }
        #endregion
        #region  چسب 2 طرفه 2 سانت
        public async Task<decimal> GetGlue2Price(int height)
        {
            decimal heightNew = GetHeightNew(height);
            purchasePrice = await GetPriceById(11);
            decimal resultGlue2Price =((heightNew / 100 )* purchasePrice);
            return resultGlue2Price;
        }
        #endregion


        #region اجرت
        public async Task<decimal> GetWagePrice(int id)
        {
            var query = await _calculationRepository.GetEntityById(id);
            if (query != null)
                return query.PurchasePrice;
            return 0;
        }
        #endregion
        #region بسته بندی
        public async Task<decimal> GetPackagingPrice(int id)
        {
            var query = await _calculationRepository.GetEntityById(id);
            if (query != null)
                return query.PurchasePrice;
            return 0;
        }
        #endregion


        public void Dispose()
        {
            _calculationRepository?.Dispose();
            
        }
    }

}
