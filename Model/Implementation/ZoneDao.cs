using DataAccess.Base;
using DataAccess.Interfaces.Zone;
using DataAccess.Sql.Zone;
using DataTransfer.Zone;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementation
{
    public class ZoneDao : BaseConnection, IZoneDao
    {
        public IEnumerable<ZoneDto> GetAllActiveChildZones(IEnumerable<int> zoneIds)
        {
            return QuerryForList<ZoneDto>(ZoneSql.GetAllChildZonesForZoneIds(string.Join(",", zoneIds.ToArray())));
        }

        public IEnumerable<ZoneDto> GetAllActiveZones()
        {
            return QuerryForList<ZoneDto>(ZoneSql.GetAllActiveZones());
        }

        public ZoneDto GetZoneById(int zoneId)
        {
            return QueryForObject<ZoneDto>(ZoneSql.GetZoneByIdSql(zoneId));
        }
    }
}
