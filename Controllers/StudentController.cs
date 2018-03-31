using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;
using System.Linq;
using System;

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
            Name = "Sahu, S"
          },
          new Student() {
            Id = Guid.NewGuid(),
            Name = "Test "
          }
        });

        db.SaveChanges();

      }
      return db.Students.ToList();
    }
  }
}