using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
  [Route("api/[controller]")]
  public class StudentController : Controller
  {
    private TestContext db;

    public StudentController(TestContext db)
    {
      this.db = db;
    }

    [HttpGet]
    public List<Student> GetAllStudents()
    {
      if (db.Students.Count() == 0)
      {
        db.Students.AddRange(new List<Student> {
          new Student() {
            Id = Guid.NewGuid(),
            Name = "Sahu, S",
            Subjects = new List<Subject> {
              new Subject {
                Id = Guid.NewGuid(),
                Name = "Strength of Materials"
              },
              new Subject {
                Id = Guid.NewGuid(),
                Name = "C# Lab"
              }
            }
          },
          new Student() {
            Id = Guid.NewGuid(),
            Name = "Stevens, M",
            Subjects = new List<Subject> {
              new Subject {
                Id = Guid.NewGuid(),
                Name = "C# Lab"
              }
            }
          }
        });

        db.SaveChanges();

      }
      return db.Students.Include(p => p.Subjects).ToList();
    }
  }
}