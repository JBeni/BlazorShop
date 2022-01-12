namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUserClaim : IdentityUserClaim<int>
    {
        public virtual AppUser User { get; set; }
    }
}
