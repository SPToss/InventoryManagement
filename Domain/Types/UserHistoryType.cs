using DataAccess.Implementation;
using DataTransfer.User;
using Domain.Types.Base;

namespace Domain.Types
{
    public class UserHistoryType : TypeCacheValue<UserHistoryTypeDto>
    {
        public UserHistoryType() : base(new UserDao().GetAllActiveUserHistoryTypes)
        {
        }
    }
}