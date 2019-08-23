using DataTransfer.Owner;

namespace DataAccess.Interfaces.Owner
{
    public interface IOwnerDao
    {
        OwnerDto GetOwnerById(int ownerId);
    }
}