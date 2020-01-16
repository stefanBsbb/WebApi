namespace Services.Implementations
{
    using Models;
    using Services.Common;
    using Services.CustomModels;
    using Services.CustomModels.MapperConfig;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    public class RoomManager : BaseManager<RoomModel>
    {
        private HotelsDBContext dbContext;
        public List<RoomModel> AllRooms
        {
            get
            {
                var models = MapperConfiguratior.Mapper.Map<List<RoomModel>>(this.context.Rooms.ToList());
                return models;
            }
        }
        public RoomManager() : base(new Data.HotelsDBContext())
        {

        }

        public override string Add(RoomModel model)
        {
            try
            {
                using (context)
                {

                    Room room = MapperConfiguratior.Mapper.Map<Room>(model);


                    this.context.Rooms.Add(room);
                    this.context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Delete(RoomModel model)
        {
            try
            {
                using (context)
                {
                    Room room = MapperConfiguratior.Mapper.Map<Room>(model);
                    this.context.Rooms.Remove(room);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} room Id: {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public override string Update(RoomModel model)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var getRoom = dbContext.Rooms.SingleOrDefault(x => x.ID == model.Id);
                    //    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    //    this.context.Hotels.Update(hotel);
                    //    int res = this.context.SaveChanges();
                    //    if (res == 1)
                    //    {
                    //        return "";
                    //    }
                    //    return string.Format($"{Messages.UpdateFails} Hotel Id: {model.Id}");
                    getRoom.RoomNumber = model.RoomNumber;
                    getRoom.Taken = model.Taken;

                    return "";

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
