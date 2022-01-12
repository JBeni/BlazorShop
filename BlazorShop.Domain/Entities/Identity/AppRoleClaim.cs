namespace BlazorShop.Domain.Entities.Identity
{
    public class AppRoleClaim : IdentityRoleClaim<int>
    {
        public virtual AppRole Role { get; set; }
    }
}
