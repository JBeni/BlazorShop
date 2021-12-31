namespace BlazorShop.Domain.Entities
{
    public class UserJwtToken : EntityBase
    {
        public int UserId { get; set; }
        public string? JwtToken { get; set; }
        public DateTime TokenTimestamp { get; set; }

        public virtual ICollection<AppUser>? UserTokens { get; set; }
    }
}
