﻿using System.Data.Entity;
using VKMSmalta.Admin.Models.Domain;

namespace VKMSmalta.Admin.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DebugConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}