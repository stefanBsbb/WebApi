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
        //gets all bookins
        public IActionResult AllBookINs()
        {
            var all = manager.AllBookIns;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        //adds bookin by model
        public IActionResult AddBookIN(BookINsModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/bookins", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //deletes bookin by id
        public IActionResult DeleteBookINByID(int id)
        {

            var res = manager.Delete(id);
            if (res.Length == 0)
            {
                return Created("api/bookins", id);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        //deletes bookin by model
        public IActionResult DeleteBookIN(BookINsModel model)
        {

            var res = manager.Delete(model);
            if (res.Length == 0)
            {
                return Created("api/bookins", model);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits bookin by model
        public IActionResult EditBookIN([FromBody]BookINsModel model)
        {

            var res = manager.Update(model);
            if (res.Length == 0)
            {
                return Created("api/bookins", model);
            }
            return BadRequest();
        }
    }
}