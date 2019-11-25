using DataAccess.Base;
using DataAccess.Interfaces.Owner;
using DataAccess.Sql.Owner;
using DataTransfer.Owner;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class OwnerDao : BaseConnection, IOwnerDao
    {
        public OwnerDto GetOwnerById(int ownerId)
        {
            return QueryForObject<OwnerDto>(OwnerSql.GetOwnerById(ownerId));
        }

        public IEnumerable<OwnerDto> GetAllActiveOwners()
        {
            return QuerryForList<OwnerDto>(OwnerSql.GetAllDistinctActiveOwners());
        }
    }
}