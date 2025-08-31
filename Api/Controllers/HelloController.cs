using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HelloController : BaseController
    {
        [HttpGet("hello/{name}")]
        public string GetGreetingByName(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
