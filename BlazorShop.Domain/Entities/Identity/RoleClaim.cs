namespace BlazorShop.Domain.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
