namespace BlazorShop.Domain.Entities.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }
    }
}
