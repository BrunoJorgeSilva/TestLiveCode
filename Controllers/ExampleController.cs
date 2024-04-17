using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestLiveCode.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestLiveCode.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet(Name = "GetExample")]
        public Example [] Get()
        {
            Example example = new Example()
            {
                Id = Guid.NewGuid(),
                Name = "Example",
                Date = DateTime.Now,
                Description = "This is Just an Example",
                IsDeleted = false,
            };

            Example example2 = new Example()
            {
                Id = Guid.NewGuid(),
                Name = "Example2",
                Date = DateTime.Now,
                Description = "This is Just an Example2",
                IsDeleted = true,
            };

            Example[] examples = {example, example2};
            return examples;
        }
    }
}
