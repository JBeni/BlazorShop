namespace BlazorShop.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
    }
}
