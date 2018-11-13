﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.Domain
{
   public class DataContext : DbContext
    {
        public DataContext() :base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<XamarinApp.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<XamarinApp.Domain.UserType> UserTypes { get; set; }
    }
}
