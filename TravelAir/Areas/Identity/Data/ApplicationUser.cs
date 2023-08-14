using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TravelAir.Models;

namespace TravelAir.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(40)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(40)")]
    public string LastName { get; set; }

    [Column(TypeName = "nvarchar(40)")]
    public string UserNameDisplay { get; set; }

    public ICollection<AppUserFlightOffer> AppUserFlightOffers { get; set; }
}

