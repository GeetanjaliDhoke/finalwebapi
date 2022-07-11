using AutoMapper;
using MedicalAPI.DomainModels;
using Microsoft.AspNetCore.Http;
using MedicalAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MedicalAPI.DataModels;

namespace MedicalAPI.Controllers
{
    [ApiController]
    public class labtestsController : Controller
    {
        private readonly labtestsRepository labtestsRepository;
        private readonly IMapper mapper;

        public labtestsController(labtestsRepository labtestsRepository, IMapper mapper)
        {
            this.labtestsRepository = labtestsRepository;
            this.mapper = mapper;
        }

        //Get All Lab-Tests
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> GetAlllabtestsAsync()
        {
            var labtest = await labtestsRepository.GetLabtestsAsync();

            return Ok(mapper.Map<List<labtests>>(labtest));
        }

        //Get Lab-Test Id
        [HttpGet]
        [Route("[Controller]/{labid:int}"),ActionName("GetlabtestAsync")]
        public async Task<IActionResult> GetlabtestAsync([FromRoute] int labid)
        {
            //fetch data
            var labtest = await labtestsRepository.GetLabtestAsync(labid);
            //return data
            if (labtest == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<labtests>(labtest));
        }

        //Update Lab-Tests
        [HttpPut]
        [Route("[Controller]/{labid:int}")]
        public async Task<IActionResult> UpdatelabtestAsync([FromRoute] int labid, [FromBody] UpdateLabRequest request)
        {
            if (await labtestsRepository.Exists(labid))

            {
                //Update Details
                var Updatedlabtests = await labtestsRepository.UpdateLabtest(labid, mapper.Map<DataModels.labtests>(request));

                if (Updatedlabtests != null)
                {
                    return Ok(mapper.Map<labtests>(Updatedlabtests));
                }
            }
            return NotFound();
        }

        //Delete Lab-Tests
        [HttpDelete]
        [Route("[Controller]/{labid:int}")]
        public async Task<IActionResult> DeletelabtestAsync([FromRoute] int labid)
        {
            if(await labtestsRepository.Exists(labid))
            {
                //Delete the labtest
                var labtest = await labtestsRepository.DeleteLabtest(labid);
                return Ok(mapper.Map<labtests>(labtest));
            }
            return NotFound();
        }

        //Add Lab-Tests
        [HttpPost]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> AddlabtestAsync([FromBody] AddLabRequest request)
        {
           var labtest = await labtestsRepository.AddLabtest(mapper.Map<DataModels.labtests>(request));
            return CreatedAtAction(nameof(GetlabtestAsync), new { labid = labtest.labid },
                mapper.Map<labtests>(labtest));
        }
    }
}

