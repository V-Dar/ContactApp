using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Api.Controllers
{
    public class TestController : BaseController
    {
        [HttpGet("test")]
        public string GetHelloWorldText()
        {
            return "Hello world!";
        }
    }
}
