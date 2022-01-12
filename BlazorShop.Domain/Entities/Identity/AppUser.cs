namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AppUserToken> UserTokens { get; set; }
        public virtual ICollection<AppUserRole> Roles { get; set; }
        public virtual ICollection<AppUserLogin> Logins { get; set; }
        public virtual ICollection<AppUserClaim> Claims { get; set; }
    }
}
