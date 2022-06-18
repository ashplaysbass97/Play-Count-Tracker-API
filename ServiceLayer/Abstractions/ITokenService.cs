namespace ServiceLayer.Abstractions
{
    public interface ITokenService
    {
        public string GenerateToken(string username);
    }
}
