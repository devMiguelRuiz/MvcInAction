﻿using MvcInAction.Data.Entities;
using System.Data.Entity;

namespace MvcInAction.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(): base("MvcInActionDb")
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}