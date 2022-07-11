using AutoMapper;
using MedicalAPI.DataModels;
using MedicalAPI.DomainModels;
using MedicalAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAPI.Controllers
{
    [ApiController]
    public class donationController : Controller
    {
        private readonly donationRepository donationRepository;
        private readonly IMapper mapper;

        public donationController(donationRepository donationRepository, IMapper mapper)
        {
            this.donationRepository = donationRepository;
            this.mapper = mapper;
        }

        //Get All Donations
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> Getdonations()
        {
            var donations = await donationRepository.GetdonationAsync();

            return Ok(mapper.Map<List<donation>>(donations));
        }

        [HttpGet]
        [Route("[Controller]/{did:int}"), ActionName("Getdonation")]
        public async Task<IActionResult> Getdonation([FromRoute] int did)
        {
            //fetch the data
            var donation = await donationRepository.GetDonationAsync(did);
            //return the data
            if(donation == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<donation>(donation));
        }

        [HttpPost]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> Adddonations([FromBody] AddDonationRequest request)
        {
            var donations = await donationRepository.AdddonationAsync(mapper.Map<DataModels.donation>(request));
            return CreatedAtAction(nameof(Getdonation), new { did = donations.did },
                mapper.Map<donation>(donations));
        }
    }
}
