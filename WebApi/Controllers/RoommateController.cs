using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class RoommateController : ControllerBase 
    {
        private static List<Roommate> RoommateList = new List<Roommate>()
        {
            new Roommate{
                Id = 1,
                Name = "Selen Dönmez",
                Age = 22,
                Job = "student",
                RentMoney = 500,
                HomeSize = 190,
            },
            new Roommate{
                Id = 2,
                Name = "Adam Jason",
                Age = 32,
                Job = "Actor",
                RentMoney = 350,
                HomeSize = 90,
            },
            new Roommate{
                Id = 3,
                Name = "Cem Karaca",
                Age = 68,
                Job = "Dentist",
                RentMoney = 900,
                HomeSize = 250,
            }
        };

        [HttpGet]
        public List<Roommate> GetRoommates()
        {
            var roommateList = RoommateList.OrderBy(x=> x.Id).ToList<Roommate>();
            return roommateList;
        }

        [HttpPost]
        public IActionResult AddRoommate([FromBody] Roommate newRoommate)
        {
            var roommate = RoommateList.SingleOrDefault(x => x.Name == newRoommate.Name);

            if (roommate is not null)
                return BadRequest();

            RoommateList.Add(newRoommate);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoommate(int id, [FromBody] Roommate updatedRoommate)
        {
            var roommate = RoommateList.SingleOrDefault(x => x.Id == id);

            if (roommate is null)
                return BadRequest();
            
            roommate.Age = updatedRoommate.Age != default ? updatedRoommate.Age : roommate.Age;
            roommate.Job = updatedRoommate.Job != default ? updatedRoommate.Job : roommate.Job;
            roommate.RentMoney = updatedRoommate.RentMoney != default ? updatedRoommate.RentMoney : roommate.RentMoney;
            roommate.Name = updatedRoommate.Name != default ? updatedRoommate.Name : roommate.Name;
            roommate.HomeSize = updatedRoommate.HomeSize != default ? updatedRoommate.HomeSize : roommate.HomeSize;

            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteRoommate(int id)
        {
            var roommate = RoommateList.SingleOrDefault(x => x.Id == id);
            if (roommate is null)
                return BadRequest();
            
            RoommateList.Remove(roommate);
            return Ok();
        }
    }
}