﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    internal class WestWindContext : DbContext
    {
        public WestWindContext()
        {

        }

        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        { }

        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
