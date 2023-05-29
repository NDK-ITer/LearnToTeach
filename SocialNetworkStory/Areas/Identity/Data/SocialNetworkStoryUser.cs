using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialNetworkStory.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SocialNetworkStoryUser class
public class SocialNetworkStoryUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreateDate { get; set; }
}

