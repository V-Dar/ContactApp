using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Api.Controllers
{
    //http://localhost:5000/api/Test
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        //app.MapGet("/test", () => "Hello world!");
        [HttpGet("test")]
        public string GetHelloWorldText()
        {
            return "Hello world!";
        }
        //app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");
        [HttpGet("hello/{name}")]
        public string GetGreetingByName(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
