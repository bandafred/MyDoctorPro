using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Response;
using DoctorsHelper.Calculators.BL.Medical.GraceScale;
using DoctorsHelper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsHelper.API.Controllers.Calculators.Medical
{
    [Route("api/calculators/[controller]/[action]")]
    public class GraceScaleController : ControllerBase
    {
        private readonly GraceScaleHandler _graceScaleHandler;

        public GraceScaleController(GraceScaleHandler graceScaleHandler)
        {
            _graceScaleHandler = graceScaleHandler;
        }

        [HttpPost]
        public async Task<GraceScaleResponse> CalculateGraceScale(GraceScaleQuery query)
        {
            return await _graceScaleHandler.Handle(query);
        }

        [HttpGet]
        public async Task<List<IdValueItem<int,string>>> GetKillipDictionary() =>
            await Task.FromResult(Enum.GetValues(typeof(GraceScaleKillipEnum)).Cast<GraceScaleKillipEnum>()
                .Select(e => new IdValueItem<int,string>((int)e, e.GetAttribute<DisplayAttribute>()?.Name)).ToList());
    }
}
