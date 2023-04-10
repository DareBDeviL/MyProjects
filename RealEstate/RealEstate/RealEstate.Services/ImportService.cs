﻿namespace RealEstate.Services
{
    using Newtonsoft.Json;

    using RealEstate.App.Data;
    using RealEstate.Models.ImportViewModels;
    using RealEstate.Services.Interfaces;

    public class ImportService : IImportService
    {
        private readonly IPropertyService propertyService;

        public ImportService(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        public void Import(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new InvalidOperationException("Json can not be empty!");
            }

            var jsonProps = JsonConvert.DeserializeObject<IEnumerable<ImportPropModel>>(json);

           
            foreach (var jsonProp in jsonProps!)
            {
                propertyService.Add(jsonProp);
            }
        }
    }
}