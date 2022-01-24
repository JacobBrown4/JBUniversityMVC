using JBUniversity.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JBUniversityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<JBUniversityContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Jacob",
                        LastName = "Brown",
                        TypeOfStudent = 0
                    },
                    new Student
                    {
                        FirstName = "Jeff",
                        LastName = "Winger",
                        TypeOfStudent = 3
                    },
                    new Student
                    {
                        FirstName = "Abed",
                        LastName = "Nadir",
                        TypeOfStudent = 1
                    },
                    new Student
                    {
                        FirstName = "Britta",
                        LastName = "Perry",
                        TypeOfStudent = 1
                    },
                    new Student
                    {
                        FirstName = "Troy",
                        LastName = "Barnes",
                        TypeOfStudent = 1
                    },
                    new Student
                    {
                        FirstName = "Pierce",
                        LastName = "Hawthorne",
                        TypeOfStudent = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
