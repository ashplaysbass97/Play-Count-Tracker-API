namespace Service.Abstractions
{
    public interface ITokenService
    {
        public string GenerateToken(string username);
    }
}
