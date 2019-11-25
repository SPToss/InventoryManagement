using DataTransfer.Owner;
using System.Collections.Generic;

namespace DataAccess.Interfaces.Owner
{
    public interface IOwnerDao
    {
        OwnerDto GetOwnerById(int ownerId);

        IEnumerable<OwnerDto> GetAllActiveOwners();
    }
}