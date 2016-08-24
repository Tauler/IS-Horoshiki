using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IsHoroshiki.WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole()
        {
            
        }

        public CustomRole(string name)
        {
            Name = name;
        }
    }
}