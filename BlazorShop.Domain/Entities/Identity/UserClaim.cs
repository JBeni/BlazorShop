namespace BlazorShop.Domain.Entities.Identity
{
    public class UserClaim : IdentityUserClaim<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }
    }
}
