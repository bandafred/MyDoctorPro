using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Response;
using DoctorsHelper.Calculators.BL.Medical.AntihypertensiveTherapy;
using DoctorsHelper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class AntihypertensiveTherapyController : ControllerBase
    {
        private readonly AntihypertensiveTherapyHandler _antihypertensiveTherapyHandler;

        public AntihypertensiveTherapyController(AntihypertensiveTherapyHandler antihypertensiveTherapyHandler)
        {
            _antihypertensiveTherapyHandler = antihypertensiveTherapyHandler;
        }

        [HttpPost]
        public async Task<AntihypertensiveTherapyResponse> CalculateAntihypertensiveTherapy(AntihypertensiveTherapyQuery query)
        {
            return await _antihypertensiveTherapyHandler.Handle(query);
        }

        [HttpGet]
        public async Task<List<IdValueItem<int, string>>> GetDiseases() => await Task.FromResult(Enum
            .GetValues(typeof(AntihypertensiveTherapyDiseaseEnum)).Cast<AntihypertensiveTherapyDiseaseEnum>()
            .Select(e => new IdValueItem<int, string>((int) e, e.GetAttribute<DisplayAttribute>()?.Name)).ToList()
            .ToList());
    }
}
