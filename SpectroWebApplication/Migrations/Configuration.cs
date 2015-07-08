namespace SpectroWebApplication.Migrations
{
    using SpectroWebApplication.DAL;
    using SpectroWebApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpectroWebApplication.DAL.SpectroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SpectroWebApplication.DAL.SpectroContext";
        }

        protected override void Seed(SpectroContext context)
        {
            Account[] accounts = new Account[] {
                new Account() { ID = 1, Name = "Jane Austen", Email = "janeausten@gmail.com", Password = "32a979d6bd827c211070a22a5e51467afb8dc98ca4a68df9605187bcb6a85f9a" },
                new Account() { ID = 2, Name = "Charles Dickens", Email = "charlesdickens@gmail.com", Password = "980b25e20b48c6bcd33c687f50925714e49d048d1696a50378b5ce57f7ed8756" },
                new Account() { ID = 3, Name = "Miguel de Cervantes", Email = "migueldecervantes@gmail.com", Password = "6a639cd8c477ca660190de25b1dd5d4bac881029919f9f12119954175a53f1b9" }

            };

            context.Accounts.AddOrUpdate(
                x => x.ID, accounts
            );

            context.Posts.AddOrUpdate(
                x => x.ID,
                new Post() {
                    ID = 1,
                    IsPublic = true,
                    Title = "Did Microsoft just give up on Windows Phone?",
                    Content = "",
                    CreatedAt = DateTime.Now,
                    Account = accounts[0]
                },
                new Post() {
                    ID = 2,
                    IsPublic = true,
                    Title = "Han Solo's spinoff film will let Disney keep the original Star Wars trilogy alive",
                    Content = "",
                    CreatedAt = DateTime.Now,
                    Account = accounts[1]
                },
                new Post() {
                    ID = 3,
                    IsPublic = true,
                    Title = "Alexa, tell me what it's like to use the Amazon Echo",
                    Content = "",
                    CreatedAt = DateTime.Now,
                    Account = accounts[2]
                }
            );
        }
    }
}
