﻿using System;
using System.Diagnostics;
using Adeptik.Serilog.Sinks.Loki.ExampleWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Adeptik.Serilog.Sinks.Loki.ExampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] ILogger<HomeController> logger)
        {
            var ex = new Exception("new ex");

            logger.LogInformation("info");
            logger.LogDebug("debug");
            logger.LogWarning("warning");
            logger.LogError(ex, "error");
            logger.LogCritical(ex, "critical");

            return View();
        }

        public IActionResult Privacy([FromServices] ILogger<HomeController> logger)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Handled");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
