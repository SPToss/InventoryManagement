using DataTransfer.Zone;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Zone
{
    public interface IZoneDao
    {
        ZoneDto GetZoneById(int zoneId);

        IEnumerable<ZoneDto> GetAllActiveChildZones(IEnumerable<int> zoneIds);

        IEnumerable<ZoneDto> GetAllActiveZones();
    }
}