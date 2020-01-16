using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HotelsDBContext db = new HotelsDBContext())
            {
                //db.Users.Add(new Models.User() {FirstName = "pesho",LastName = "peshev",Email = "aeaseas.vv",Password="123456!A"});
                // db.Visitors.Add(new Models.Visitor() { FirstName = "pesho", HotelID = 1 });
                //db.Rooms.Add(new Models.Room() { RoomNumber = 123});
                //db.BookIns.Add(new Models.BookIn() {EmployeeID = 2,VisitorID = 1, Paid = true , RoomID =1 }); 
                db.UserRoles.Add(new Models.UserRoles() {UserID = 2, RoleID = 1 });
                db.SaveChanges();
                //db.UserTokens(new Models.UserToken() { });
            }


        }
    }
    
}
