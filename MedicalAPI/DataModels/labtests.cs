using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.DataModels
{
    public class labtests
    {
        //lab test properties
        [Key]
        public int labid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string date { get; set; }
        public string test { get; set; }

    }
}
