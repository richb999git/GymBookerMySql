using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymBooker1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CalendarIds { get; set; }
    }

    // From: https://stackoverflow.com/questions/24981593/specified-key-was-too-long-max-key-length-is-767-bytes-mysql-error-in-entity-fr  (ASP.NET only)
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; }  // added this to createa new table for extra info
        public System.Data.Entity.DbSet<GymClass> GymClasses { get; set; }
        public System.Data.Entity.DbSet<StdGymClassTimetable> StdGymClassTimetables { get; set; }
        public System.Data.Entity.DbSet<CalendarItem> CalendarItems { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}