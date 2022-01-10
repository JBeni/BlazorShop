namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AppRole>? Roles { get; set; }
    }
}
