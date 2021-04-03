using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Models
{
     
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String AssetName { get; set; }
        public Departments Department { get; set; }
        public String CountryOfDepartment { get; set; }
        public String EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool broken { get; set; }
    }
}
