using Microsoft.AspNetCore.Mvc;

namespace Test
{
  [Route("api/helloworld")]
  public class HelloController : Controller
  {
    [HttpGet]
    public string SayHello()
    {
      SayWorld();
      return "Hello";
    }
    
    public string SayWorld()
    {
      return "World";
    }
  }
}