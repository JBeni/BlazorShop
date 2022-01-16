namespace BlazorShop.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> Users { get; set; }
        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
