using Microsoft.AspNetCore.Identity;

namespace Hoorcollege4._2.Models
{
    public class User : IdentityUser
    {
        public int StudentNumber { get; set; }
    }
}
