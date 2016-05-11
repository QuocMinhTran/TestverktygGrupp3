namespace TestVerktygWPF.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestVerktygWPF.Model.DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestVerktygWPF.Model.DbModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            ////
            //context.Courses.AddOrUpdate(
            //    c => c.CourseName,
            //    new Course { CourseName = "Datateknik" },
            //    new Course { CourseName = "Database" },
            //    new Course { CourseName = "OOP" }
            //    );
            //context.StudentClasses.AddOrUpdate(
            //    stc => stc.)
        }
    }
}
