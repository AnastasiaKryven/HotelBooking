using Hotel.Domain.Entities;
using Hotel.Domain.Enums;
using Hotel.Domain.Interfaces;
using Hotel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.Repositories
{
    public class RoomRepository: IRoomRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public RoomRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Room> Rooms => db.Rooms;

        public Room GetRoomById(int? id)
        {
            return db.Set<Room>().Find(id);
        }

        public void Create(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public void SaveRoom(Room room)
        {
            if (room.RoomId == 0)
            {
                Create(room);
            }
            else

            {
                var dbEntry = db.Rooms.Find(room.RoomId);
                if (dbEntry != null)
                {
                    dbEntry.CountOfPeople = room.CountOfPeople;
                    dbEntry.ImageData = room.ImageData;
                    dbEntry.ImageMimeType = room.ImageMimeType;
                    dbEntry.Price = room.Price;
                    dbEntry.RoomClass = room.RoomClass;
                    dbEntry.RoomState = room.RoomState;
                }
            }
            db.SaveChanges();

        }
        public void Delete(int? id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }



        public List<Room> GetRooms(RoomSortBy orderBy, bool desc)
        {
            List<Room> result = GetAll(orderBy, desc);
            return result;
        }

        public List<Room> GetAll(RoomSortBy sortBy = RoomSortBy.None, bool desc = false)
        {
            
                    List<Room> rooms = new List<Room>();
                    switch (sortBy)
                    {
                        case RoomSortBy.None:
                            rooms = db.Rooms.ToList();
                            break;
                        case RoomSortBy.CountOfPlace:
                            rooms = db.Rooms.OrderBy(x => x.CountOfPeople).ToList();
                            break;
                        case RoomSortBy.Price:
                            rooms = db.Rooms.OrderBy(x => x.Price).ToList();
                            break;
                        case RoomSortBy.Class:
                            rooms = db.Rooms.OrderBy(x => x.RoomClass).ToList();
                            break;
                        case RoomSortBy.State:
                            rooms = db.Rooms.OrderBy(x => x.RoomState).ToList();
                            break;
                        default:
                            break;
                    }
                    if (rooms != null && desc)
                    {
                        rooms.Reverse();
                    }
                    return rooms;
                }

        public void Update(Room room)
        {
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
        }

