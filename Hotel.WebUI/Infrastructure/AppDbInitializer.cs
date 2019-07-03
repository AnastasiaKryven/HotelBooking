using Hotel.Domain.Entities;
using Hotel.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.Infrastructure
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "manager" };
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com" };
            string password = "Admin123456";
            var result = userManager.Create(admin, password);
            var manager = new ApplicationUser { Email = "manager@gmail.com", UserName = "manager@gmail.com" };
            // если создание пользователя прошло успешно
            var result1 = userManager.Create(manager, password);

            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);           
            }

            if (result1.Succeeded)
            {
                userManager.AddToRole(manager.Id, role3.Name);
                userManager.AddToRole(manager.Id, role2.Name);
            }

           
            db.Rooms.Add(new Room
            {
                RoomId = 1,
                CountOfPeople = 2,
                Price = 30,
                RoomClass = Domain.Enums.Class.A,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 2,
                CountOfPeople = 2,
                Price = 35,
                RoomClass = Domain.Enums.Class.A,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 3,
                CountOfPeople = 4,
                Price = 40,
                RoomClass = Domain.Enums.Class.A,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 4,
                CountOfPeople = 2,
                Price = 50,
                RoomClass = Domain.Enums.Class.B,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 5,
                CountOfPeople = 2,
                Price = 60,
                RoomClass = Domain.Enums.Class.B,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 6,
                CountOfPeople = 4,
                Price = 80,
                RoomClass = Domain.Enums.Class.B,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 7,
                CountOfPeople = 2,
                Price = 100,
                RoomClass = Domain.Enums.Class.C,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 8,
                CountOfPeople = 4,
                Price = 140,
                RoomClass = Domain.Enums.Class.C,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 9,
                CountOfPeople = 6,
                Price = 180,
                RoomClass = Domain.Enums.Class.C,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 10,
                CountOfPeople = 2,
                Price = 200,
                RoomClass = Domain.Enums.Class.Luxe,
                RoomState = Domain.Enums.State.Free
            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 11,
                CountOfPeople = 2,
                Price = 240,
                RoomClass = Domain.Enums.Class.Luxe,
                RoomState = Domain.Enums.State.Free

            });
            db.Rooms.Add(new Domain.Entities.Room
            {
                RoomId = 12,
                CountOfPeople = 4,
                Price = 260,
                RoomClass = Domain.Enums.Class.Luxe,
                RoomState = Domain.Enums.State.Free
            });

            base.Seed(db);
        }
    }
}