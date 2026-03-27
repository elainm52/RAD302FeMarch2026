using Microsoft.AspNetCore.Identity;

namespace ApplicationDb.DataModel
{
    public class ApplicationUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
