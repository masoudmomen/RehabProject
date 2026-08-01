using Rehab.Domain.Packages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Extensions
{
    public static class PackageRequestTypeExtensions
    {
        public static bool IsSubscription(this PackageType packageType)
        {
            return packageType == PackageType.Essential 
                || packageType == PackageType.Premium;
        }
    }
}
