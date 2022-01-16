namespace BlazorShop.Domain.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }
}
