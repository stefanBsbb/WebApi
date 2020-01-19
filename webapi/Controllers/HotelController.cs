namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.CustomModels;
    using Services.Implementations;

    [Route("api/hotels")]
    [ApiController]

    public class HotelController : ControllerBase
    {
        private HotelManager manager;
        public HotelController(HotelManager hotelManager)
        {
            this.manager = hotelManager;
        }

        [HttpGet]
        //gets all hotels
        public IActionResult AllHotels()
        {
            var all = manager.AllHotels;

            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        //adds hotel by id
        public IActionResult AddHotel(HotelModel model)
        {

            var res = manager.Add(model);
            if (res.Length == 0)
            {
                return Created("api/hotels", model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        //deletes hotel by id
        public IActionResult DeleteHotelByID(int id)
        {

            var res = manager.Delete(id);
            if (res.Length == 0)
            {
                return Created("api/hotels", id);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("edit")]
        //edits hotel by model
        public IActionResult EditHotel([FromBody]HotelModel model)
        {

            var res = manager.Update(model);
            if (res.Length == 0)
            {
                return Created("api/hotels", model);
            }
            return BadRequest();
        }
    }
}