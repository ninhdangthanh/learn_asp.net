using Microsoft.AspNetCore.Identity;

namespace FirstIdentity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
