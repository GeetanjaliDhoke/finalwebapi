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
    public class radiotestsController : Controller
    {
        private readonly radiotestsRepository radiotestsRepository;
        private readonly IMapper mapper;

        public radiotestsController(radiotestsRepository radiotestsRepository, IMapper mapper)
        {
            this.radiotestsRepository = radiotestsRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> GetAllradiotestsAsync()
        {
            var radiotest = await radiotestsRepository.GetRadiotestsAsync();

            return Ok(mapper.Map<List<radiotests>>(radiotest));
        }

        [HttpGet]
        [Route("[Controller]/{rid:int}"), ActionName("GetradiotestAsync")]
        public async Task<IActionResult> GetradiotestAsync([FromRoute] int rid)
        {
            //Fetch Data
            var radiotest = await radiotestsRepository.GetRadiotestAsync(rid);
            //Return Data
            if(radiotest == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<radiotests>(radiotest));
        }

        [HttpPut]
        [Route("[Controller]/{rid:int}")]
        public async Task<IActionResult> UpdateradiotestAsync([FromRoute] int rid,
            [FromBody] UpdateRadiotestRequest request)
        {
            if (await radiotestsRepository.Exists(rid))
            {
                //Update Details
                var UpdatedRadiotests = await radiotestsRepository.Updateradiotest(rid, mapper.Map<DataModels.radiotests>(request));
                if (UpdatedRadiotests != null)
                {
                    return Ok(mapper.Map<radiotests>(UpdatedRadiotests));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[Controller]/{rid:int}")]
        public async Task<IActionResult> DeleteradiotestAsync([FromRoute] int rid)
        {
            if(await radiotestsRepository.Exists(rid))
            {
                //Delete the Radiotest
               var radiotest = await radiotestsRepository.Deleteradiotest(rid);
                return Ok(mapper.Map<radiotests> (radiotest));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> AddradiotestAsync([FromBody] AddRadioRequest request)
        {
            var radiotest = await radiotestsRepository.Addradiotest(mapper.Map<DataModels.radiotests>(request));
            return CreatedAtAction(nameof(GetradiotestAsync), new { rid = radiotest.rid },
                mapper.Map<radiotests>(radiotest));
        }
    }
}
