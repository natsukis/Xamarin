using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinApp.Domain;

namespace XamarinApp.Backend.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<XamarinApp.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<XamarinApp.Domain.UserType> UserTypes { get; set; }
    }
}