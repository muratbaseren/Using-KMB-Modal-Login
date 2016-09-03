using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingModalLogin.Models
{
    public class KmbContext: DbContext
    {
        public DbSet<KmbUser> KmbUsers { get; set; }

        public KmbContext()
        {
            Database.SetInitializer(new KmbContextInitializer());
        }
    }

    public class KmbContextInitializer : CreateDatabaseIfNotExists<KmbContext>
    {
        protected override void Seed(KmbContext context)
        {
            context.KmbUsers.Add(new KmbUser() {
                Email = "kadirmuratbaseren@gmail.com",
                Name = "Murat",
                Surname = "Baseren",
                Username = "muratbaseren",
                Password = "123"
            });

            context.SaveChanges();
        }
    }
}
