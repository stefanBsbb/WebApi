namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.CustomModels;
    using Services.Implementations;

    [Route("api/visitors")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        private VisitorManager manager;
        public VisitorController(VisitorManager visitorManager)
        {
            this.manager = visitorManager;
        }

        [HttpGet]
        public IActionResult AllVisitors()
        {
            var all = manager.AllVisitors;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
   
        public IActionResult AddVisitor(VisitorModel model)
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
        public IActionResult DeleteVisitor(VisitorModel model)
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
        public IActionResult EditVisitor([FromBody]VisitorModel model)
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