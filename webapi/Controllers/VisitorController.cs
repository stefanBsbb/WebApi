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
        //gets all visitors
        public IActionResult AllVisitors()
        {
            var all = manager.AllVisitors;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        //adds a visitor by model
   
        public IActionResult AddVisitor(VisitorModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/visitors", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //deletes visitor by id
        public IActionResult DeleteVisitorByID(int id)
        {

            var res = manager.Delete(id);
            if (res.Length == 0)
            {
                return Created("api/visitors", id);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete")]
        //deletes visitor by model
        public IActionResult DeleteVisitor(VisitorModel model)
        {

            var res = manager.Delete(model);
            if (res.Length == 0)
            {
                return Created("api/visitors", model);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits visitor by model
        public IActionResult EditVisitor([FromBody]VisitorModel model)
        {

            var res = manager.Update(model);
            if (res.Length == 0)
            {
                return Created("api/visitors", model);
            }
            return BadRequest();
        }
    }
}