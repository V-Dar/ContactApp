using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StorageController : BaseController
    {
        private DataContext DataContext { get; }

        public StorageController(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        [HttpGet("SetString/{value}")]
        public void SetString(string value)
        {
            DataContext.Str = value;
        }

        [HttpGet("GetString")]
        public string GetString()
        {
            return DataContext.Str;
        }
    }
}
