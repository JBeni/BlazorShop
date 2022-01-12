namespace BlazorShop.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public virtual ICollection<AppUserRole> Users { get; set; }
        public virtual ICollection<AppRoleClaim> Claims { get; set; }
    }
}
