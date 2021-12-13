using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerDataExt
{
    public class OwneDbContext: DbContext
    {
        string StringConnection;
        public DbSet<string> a { get; set; }
        public OwneDbContext()
        {
            Connection con = new Connection(true);
            StringConnection = con.GetConection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@StringConnection);
        }


    }
}
