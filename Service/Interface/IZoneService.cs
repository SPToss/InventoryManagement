using Domain;
using System.Collections.Generic;


namespace Service.Interface
{
    public interface IZoneService
    {
        Zone GetZoneById(int zoneId);
        IEnumerable<Zone> GetAllChildZones(int zoneId);
    }
}