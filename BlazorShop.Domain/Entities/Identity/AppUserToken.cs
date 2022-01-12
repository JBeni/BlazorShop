namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public virtual AppUser User { get; set; }
    }
}
