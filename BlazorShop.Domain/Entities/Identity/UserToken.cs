namespace BlazorShop.Domain.Entities.Identity
{
    public class UserToken : IdentityUserToken<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }
    }
}
