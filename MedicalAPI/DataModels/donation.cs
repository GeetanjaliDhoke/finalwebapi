using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.DataModels
{
    public class donation
    {
        [Key]
        public int did { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string amount { get; set; }
        public string cardname { get; set; }
    }
}
