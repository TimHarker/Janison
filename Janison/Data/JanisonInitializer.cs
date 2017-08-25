using Janison.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Janison.Data
{
    public class JanisonInitializer : DropCreateDatabaseIfModelChanges<JanisonContext> //DropCreateDatabaseAlways DropCreateDatabaseIfModelChanges
    {
        protected override void Seed(JanisonContext context)
        {
            var courses = new List<Course>
            {
            new Course{Name="Chemistry",Description="Chemistry Description",Cost=100.25M,Duration=30,DateCreated=DateTime.UtcNow.AddDays(-3),DateModified=DateTime.UtcNow.AddDays(-3),Enabled=true},
            new Course{Name="Microeconomics",Description="Microeconomics Description",Cost=310.00M,Duration=60,DateCreated=DateTime.UtcNow.AddDays(-15),DateModified=DateTime.UtcNow.AddDays(-15),Enabled=true},
            new Course{Name="Macroeconomics",Description="Macroeconomics Description",Cost=55M,Duration=30,DateCreated=DateTime.UtcNow.AddDays(-5),DateModified=DateTime.UtcNow.AddDays(-5),Enabled=true},
            new Course{Name="Calculus",Description="Calculus Description",Cost=234.62M,Duration=45,DateCreated=DateTime.UtcNow.AddDays(-10),DateModified=DateTime.UtcNow.AddDays(-10),Enabled=true},
            new Course{Name="Trigonometry",Description="Trigonometry Description",Cost=64.17M,Duration=120,DateCreated=DateTime.UtcNow.AddDays(-7),DateModified=DateTime.UtcNow.AddDays(-6),Enabled=true},
            new Course{Name="Composition",Description="Composition Description",Cost=150.99M,Duration=180,DateCreated=DateTime.UtcNow.AddDays(-2),DateModified=DateTime.UtcNow.AddDays(-1),Enabled=true},
            new Course{Name="Literature",Description="Literature Description",Cost=0.5M,Duration=90,DateCreated=DateTime.UtcNow.AddDays(-1),DateModified=DateTime.UtcNow,Enabled=true},
            new Course{Name="Literature 2",Description="Literature 2 Description",Cost=5.5M,Duration=120,DateCreated=DateTime.UtcNow.AddDays(-2),DateModified=DateTime.UtcNow.AddDays(-2),Enabled=false}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Module>
            {
            new Module{Name="Seed Data",Description="Pellentesque pretium",Duration=45,DateCreated=DateTime.UtcNow.AddDays(-17),CourseID=1},
            new Module{Name="Smell Nice",Description="Maecenas lorem",Duration=30,DateCreated=DateTime.UtcNow.AddDays(-34),CourseID=2},
            new Module{Name="Two 4 One",Description="Nibh rutrum consequat",Duration=60,DateCreated=DateTime.UtcNow.AddDays(-35),CourseID=3},
            new Module{Name="Heavy Lifting",Description="Integer vulputate sem",Duration=90,DateCreated=DateTime.UtcNow.AddDays(-53),CourseID=4},
            new Module{Name="Cool Hand",Description="Suscipit a, interdum",Duration=120,DateCreated=DateTime.UtcNow.AddDays(-37),CourseID=5},
            new Module{Name="Beach Wave",Description="Nulla est. Nulla turpis",Duration=60,DateCreated=DateTime.UtcNow.AddDays(-127),CourseID=6},
            new Module{Name="Smith House",Description="Etiam quis quam",Duration=30,DateCreated=DateTime.UtcNow.AddDays(-56),CourseID=1},
            new Module{Name="Tiger Tree",Description="Chemistry Description",Duration=180,DateCreated=DateTime.UtcNow.AddDays(-78),CourseID=1},
            new Module{Name="Tower High",Description="Pellentesque pretium",Duration=100,DateCreated=DateTime.UtcNow.AddDays(-21),CourseID=2},
            new Module{Name="Slip Ship",Description="Integer vulputate sem",Duration=50,DateCreated=DateTime.UtcNow.AddDays(-32),CourseID=3},
            new Module{Name="House House",Description="Chemistry Description",Duration=90,DateCreated=DateTime.UtcNow.AddDays(-6),CourseID=4},
            new Module{Name="Time Time",Description="Chemistry Description",Duration=75,DateCreated=DateTime.UtcNow.AddDays(-78),CourseID=5},
            new Module{Name="Etiam posu",Description="Etiam quis quam",Duration=130,DateCreated=DateTime.UtcNow.AddDays(-10),CourseID=7},
            new Module{Name="Maecenas aliquet acc",Description="Chemistry Description",Duration=30,DateCreated=DateTime.UtcNow.AddDays(-3),CourseID=7}
            };
            enrollments.ForEach(s => context.Modules.Add(s));
            context.SaveChanges();
        }
    }

}