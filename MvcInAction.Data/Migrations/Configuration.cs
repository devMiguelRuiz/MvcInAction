using MvcInAction.Data.Entities;

namespace MvcInAction.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcInAction.Data.RepositoryContext";
        }

        protected override void Seed(RepositoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Contacts.AddOrUpdate(c => c.Email,
                new Contact {FirstName = "Juan", LastName = "Perez", Email = "jPerez@epam.com"},
                new Contact {FirstName = "Oscar", LastName = "Lopez", Email = "oLopez@epam.com"},
                new Contact {FirstName = "Miguel", LastName = "Ruiz", Email = "mRuiz@epam.com"});
        }
    }
}