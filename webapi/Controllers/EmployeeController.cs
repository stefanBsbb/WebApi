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
        //gets all employees
        public IActionResult AllEmployees()
        {
            var all = manager.AllEmployees;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        //adds employee by model
        public IActionResult AddEmployee(EmployeeModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/employees", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //deletes employee by id
        public IActionResult DeleteEmployeeByID(int id)
        {

            var res = manager.Delete(id);
            if (res.Length == 0)
            {
                return Created("api/employees", id);
            }
            return BadRequest();
        }
        
        [HttpDelete]
        [Route("delete")]
        //deletes employee by model
        public IActionResult DeleteEmployee(EmployeeModel model)
        {

            var res = manager.Delete(model);
            if (res.Length == 0)
            {
                return Created("api/employees", model);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits employee by model
        public IActionResult EditEmployee([FromBody]EmployeeModel model)
        {

            var res = manager.Update(model);
            if (res.Length == 0)
            {
                return Created("api/employees", model);
            }
            return BadRequest();
        }
    }
}