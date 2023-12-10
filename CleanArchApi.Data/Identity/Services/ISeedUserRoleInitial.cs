namespace WebApiIdentity.Services
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync();
        Task SeedUserAsync();
    }
}
