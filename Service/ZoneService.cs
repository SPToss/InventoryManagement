using DataAccess.Interfaces.Zone;
using DataTransfer.Zone;
using Domain;
using Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneDao _zoneDao;

        public ZoneService(IZoneDao zoneDao)
        {
            _zoneDao = zoneDao;
        }

        public IEnumerable<Zone> GetAllChildZones(int zoneId)
        {
            List<Zone> zones = new List<Zone>();

            ZoneDto zoneDto = _zoneDao.GetZoneById(zoneId);
            
            if(zoneDto == null)
            {
                return new List<Zone>();
            }

            zones.Add(Zone.FromDto(zoneDto));

            List<int> zonesToLookUp = new List<int>(zones.Select(x => x.Id));

            while (true)
            {
                var newZones = _zoneDao.GetAllActiveChildZones(zonesToLookUp).ToList() ;

                if (!newZones.Any())
                {
                    break;
                }

                zones.AddRange(newZones.Select(Zone.FromDto));

                zonesToLookUp = newZones.Select(x => x.Id).ToList();

            }

            return zones;
        }
    }
}
