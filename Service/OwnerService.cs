using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Owner> GetAllActiveOwners()
        {
            var ownersDto = _ownerDao.GetAllActiveOwners();

            return ownersDto.Select(Owner.FromDto);
        }

        public Owner GetOwnerById(int ownerId)
        {
            var ownerDto = _ownerDao.GetOwnerById(ownerId);

            return Owner.FromDto(ownerDto);
        }
    }
}