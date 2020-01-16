namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.CustomModels;
    using Services.Implementations;

    [Route("api/bookins")]
    [ApiController]

    public class BookInController : ControllerBase
    {
        private BookINManager manager;
        public BookInController(BookINManager bookINManager)
        {
            this.manager = bookINManager;
        }

        [HttpGet]
        public IActionResult AllBookINs()
        {
            var all = manager.AllBookIns;

            return Ok(all);
        }

        [HttpPost]
        public IActionResult AddProduct(BookINsModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/BookIns", model);
            }
            return BadRequest();
        }
    }
}