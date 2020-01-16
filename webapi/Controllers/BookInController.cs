﻿namespace WebAPI.Controllers
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
        [Route("add")]
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
        [Route("delete")]
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