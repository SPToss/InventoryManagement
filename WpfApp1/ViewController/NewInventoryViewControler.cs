using RestApi.Client.Dto.Response.Zone;
using RestApi.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ViewController
{
    public class NewInventoryViewControler
    {
        public readonly IRestApiClient _restApiClient;

        public List<ZoneDto> AvailableZones { get; set; }

        public int SelectedZoneId { get; set; }

        public NewInventoryViewControler(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
            Initialize();
        }

        public void CreateNewInventory(string description)
        {
            _restApiClient.AddNewInventory(description, SelectedZoneId);
        }

        private void Initialize()
        {
            AvailableZones = _restApiClient.GetAllZones();
        }

    }
}
