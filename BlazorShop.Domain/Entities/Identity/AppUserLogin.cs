namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}
