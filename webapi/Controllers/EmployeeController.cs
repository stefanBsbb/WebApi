namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.CustomModels;
    using Services.Implementations;

    [Route("api/employees")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private EmployeeManager manager;
        public EmployeeController(EmployeeManager employeeManager)
        {
            this.manager = employeeManager;
        }

        [HttpGet]
        public IActionResult AllEmployees()
        {
            var all = manager.AllEmployees;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddEmployee(EmployeeModel model)
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
        public IActionResult DeleteEmployee(EmployeeModel model)
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
        public IActionResult EditEmployee([FromBody]EmployeeModel model)
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