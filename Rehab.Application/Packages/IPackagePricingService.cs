using NuGet.Packaging.Core;
using Rehab.Domain.Packages;
using Rehab.Domain.Packages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageType = Rehab.Domain.Packages.Enums.PackageType;
namespace Rehab.Application.Packages
{
    public interface IPackagePricingService
    {
        Task<decimal> GetPriceAsync(PackageType packageType, BillingType billingType);
        Task<IEnumerable<PackagePriceDto>> GetAllPricesAsync();
        
    }
    public class PackagePricingService : IPackagePricingService
    {
        private readonly List<PackagePriceDto> _prices = new()
        {
            new(PackageType.Essential,499,399),
            new(PackageType.Premium,1099,999)
        };
        public Task<IEnumerable<PackagePriceDto>> GetAllPricesAsync()
            => Task.FromResult<IEnumerable<PackagePriceDto>>(_prices);

        public Task<decimal> GetPriceAsync(PackageType packageType, BillingType billingType)
        {
            var package = _prices.FirstOrDefault(p => p.packageType == packageType);
            if(package == null)
                throw new KeyNotFoundException($"Pricing not found for product type: {packageType}");

            var price = package.GetPrice(billingType);
            return Task.FromResult(price);
        }

    }
   public record PackagePriceDto(
       PackageType packageType,
       decimal MonthlyPrice,
       decimal AnnualPrice
       )
    {
        public decimal GetPrice(BillingType billingType) =>
            billingType == BillingType.Monthly ? MonthlyPrice : AnnualPrice;
    }
    
}
