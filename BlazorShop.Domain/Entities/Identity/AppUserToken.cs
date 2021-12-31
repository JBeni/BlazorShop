namespace BlazorShop.Domain.Entities.Identity
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}
