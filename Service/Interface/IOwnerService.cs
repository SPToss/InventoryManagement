using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IOwnerService
    {
        Owner GetOwnerById(int ownerId);

        IEnumerable<Owner> GetAllActiveOwners();
    }
}
