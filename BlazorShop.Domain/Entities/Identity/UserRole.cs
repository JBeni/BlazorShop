namespace BlazorShop.Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
