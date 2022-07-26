using System;
using Microsoft.AspNetCore.Identity;

namespace MyStandardsProject1.Api.Models.Users
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
