﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SQLLite.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
    }
}
