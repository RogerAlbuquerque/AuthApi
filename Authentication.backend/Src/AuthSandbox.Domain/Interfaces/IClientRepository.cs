public interface IClientRepository
{
    Task<IEnumerable<User>> ClientAuthentication();  
}