using Domain;
using System.Collections.Generic;


namespace Service.Interface
{
    public interface IZoneService
    {
        IEnumerable<Zone> GetAllChildZones(int zoneId);
    }
}
