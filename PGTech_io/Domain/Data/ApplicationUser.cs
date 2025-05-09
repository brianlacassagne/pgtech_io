using Microsoft.AspNetCore.Identity;
using PGTech_io.Models;

namespace PGTech_io.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Response> Responses { get; set; } 
    public virtual ICollection<Solicit> Solicits { get; set; } 
}