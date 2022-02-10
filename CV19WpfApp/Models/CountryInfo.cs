using System.Collections.Generic;

namespace CV19WpfApp.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}