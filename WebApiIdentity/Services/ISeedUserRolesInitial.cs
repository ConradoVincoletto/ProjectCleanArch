namespace WebApiIdentity.Services
{
    public interface ISeedUserRolesInitial
    {
        Task SeedRolesAsync();
        Task SeedUserAsync();
    }
}
