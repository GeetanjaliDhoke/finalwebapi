using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.DomainModels
{
    public class AddDonationRequest
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string amount { get; set; }
        public string cardname { get; set; }
    }
}
