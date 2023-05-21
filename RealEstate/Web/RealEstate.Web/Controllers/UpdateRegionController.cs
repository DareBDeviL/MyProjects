﻿namespace RealEstate.Web.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using RealEstate.Services.Data.Interfaces;
    using RealEstate.Services.Interfaces;

    // [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UpdateRegionController : BaseController
    {
        private readonly IRegionScraperService scraper;
        private readonly IRegionService regionService;

        public UpdateRegionController(IRegionScraperService scraper, IRegionService regionService)
        {
            this.scraper = scraper;
            this.regionService = regionService;
        }

        //[HttpPost]
        public async Task<IActionResult> UpdateRegions()
        {
            var regions = await this.scraper.GetAllAsJason();

            //this.regionService.SaveToFile(regions);

            return this.Content("Done");
            return this.RedirectToAction(nameof(this.Succsses));
        }

        public IActionResult Succsses()
        {
            return this.View();
        }
    }
}