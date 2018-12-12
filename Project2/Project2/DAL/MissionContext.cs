using Project2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext() : base("MissionContext")
        {

        }

        public DbSet<Missions> Mission { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<MissionQuestions> MissionQuestion { get; set; }
    }
}