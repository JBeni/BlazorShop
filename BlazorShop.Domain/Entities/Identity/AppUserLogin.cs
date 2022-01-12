namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public virtual AppUser User { get; set; }
    }
}
