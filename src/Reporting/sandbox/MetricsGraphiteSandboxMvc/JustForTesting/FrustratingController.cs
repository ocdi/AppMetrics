// <copyright file="FrustratingController.cs" company="App Metrics Contributors">
// Copyright (c) App Metrics Contributors. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using MetricsGraphiteSandboxMvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsGraphiteSandboxMvc.JustForTesting
{
    [Route("api/[controller]")]
    public class FrustratingController : Controller
    {
        private readonly RequestDurationForApdexTesting _durationForApdexTesting;

        public FrustratingController(RequestDurationForApdexTesting durationForApdexTesting)
        {
            _durationForApdexTesting = durationForApdexTesting;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            var duration = _durationForApdexTesting.NextFrustratingDuration;

            await Task.Delay(duration, HttpContext.RequestAborted);

            return duration;
        }
    }
}