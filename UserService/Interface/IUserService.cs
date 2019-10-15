namespace UserService.Interface
{
    public interface IUserService
    {
        bool Authorize(string login, string password);
    }
}