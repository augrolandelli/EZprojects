using BCrypt.Net;

namespace api.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verify(string password, string passwordHashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
        }
    }
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string passwordHashed);
    }
}
