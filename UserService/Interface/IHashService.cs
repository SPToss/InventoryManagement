namespace UserService.Interface
{
    public interface IHashService
    {
        (string hash, string salt) HashString(string stringToHash);

        (string hash, string salt) HashString(string stringToHash, string salt);
    }
}