using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.Services.Interfaces
{
    public interface ILicense
    {
        public double percentageLicenseUsing(Guid License);
        public double projectAvailable(Guid License);
        public double userAvailable(Guid License);
        public double variantsAvailable(Guid License);
        public string licenseExpired(Guid License);
    }
}
