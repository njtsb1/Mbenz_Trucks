using Mbenz.Trucks.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mbenz.Trucks.Infra.Facade
{
    public class VehicleDetranFacade : IVVehicleDetran
    {
        private readonly DetranOptions detranOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IVehicleRepository vehicleRepository;

        public VehicleDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, IHttpClientFactory httpClientFactory, IVehicleRepository vehicleRepository)
        {
            this.detranOptions = optionsMonitor.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.vehicleRepository = vehicleRepository;
        }

        public async Task ScheduleInspectionDetran(Guid vehicleId)
        {
            var vehicle = vehicleRepository.GetById(vehicleId);

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl); 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestModel = new InspectionModel()
            {
                Plate = vehicle.Plate,
                Scheduledto = DateTime.Now.AddDays(detranOptions.QuantityDaysToSchedule)
            };
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.InspectionUri, contentString);
        }
    }
}
