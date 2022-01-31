using System.Collections.Generic;

namespace CV19WpfApp.Model
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }

    }
}



