﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prepaid_Mobile_Topup_MVC.Models;

namespace Prepaid_Mobile_Topup_MVC.Data
{
    public class Prepaid_Mobile_Topup_MVCContext : DbContext
    {
        public Prepaid_Mobile_Topup_MVCContext (DbContextOptions<Prepaid_Mobile_Topup_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Prepaid_Mobile_Topup_MVC.Models.PrepaidCustomer> PrepaidCustomer { get; set; }

        public DbSet<Prepaid_Mobile_Topup_MVC.Models.MobileAccount> MobileAccount { get; set; }

        public DbSet<Prepaid_Mobile_Topup_MVC.Models.TopUpChannel> TopUpChannel { get; set; }

        public DbSet<Prepaid_Mobile_Topup_MVC.Models.TopUp> TopUp { get; set; }
    }
}
