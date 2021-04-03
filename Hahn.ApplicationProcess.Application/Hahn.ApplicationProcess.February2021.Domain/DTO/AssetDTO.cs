using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.DTO
{
    public class AssetDTO
    {
        public int ID { get; set; }
        public String AssetName { get; set; }
        public int Department { get; set; }
        public String CountryOfDepartment { get; set; }
        public String EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool broken { get; set; }

    }
}
