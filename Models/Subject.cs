using System;

namespace Test.Models
{
  public class Subject
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    //Navigation property
    public Student Student { get; set; }
  }
}