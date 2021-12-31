namespace BlazorShop.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUser> Users { get; set; }
    }
}
