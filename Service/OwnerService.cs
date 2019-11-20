using DataAccess.Interfaces.Owner;
using Domain;
using Service.Interface;

namespace Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerDao _ownerDao;

        public OwnerService(IOwnerDao ownerDao)
        {
            _ownerDao = ownerDao;
        }

        public Owner GetOwnerById(int ownerId)
        {
            var ownerDto = _ownerDao.GetOwnerById(ownerId);

            return Owner.FromDto(ownerDto);
        }
    }
}