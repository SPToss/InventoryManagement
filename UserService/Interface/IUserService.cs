namespace UserService.Interface
{
    public interface IUserService
    {
        User Authorize(string login, string password);
    }
}