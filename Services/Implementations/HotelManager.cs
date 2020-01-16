namespace Services.Implementations
{
    using Data;
    using Models;
    using Services.Common;
    using Services.CustomModels;
    using Services.CustomModels.MapperConfig;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HotelManager : BaseManager<HotelModel>
    {
        private HotelsDBContext dbContext;
        public List<HotelModel> AllHotels
        {
            get
            {
                var models = MapperConfiguratior.Mapper.Map<List<HotelModel>>(this.context.Hotels.ToList());
                return models;
            }
        }
        public HotelManager() : base(new Data.HotelsDBContext())
        {

        }

        public override string Add(HotelModel model)
        {
            try
            {
                using (context)
                {

                    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    this.context.Hotels.Add(hotel);
                    this.context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string Delete(int id)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var entity = dbContext.Hotels.FirstOrDefault(x => x.ID == id);
                    dbContext.Remove(entity);
                    dbContext.SaveChanges();
                    return "";
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public override string Delete(HotelModel model)
        {
            try
            {
                using (context)
                {
                    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    this.context.Hotels.Remove(hotel);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} Hotel Id: {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public override string Update(HotelModel model)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var getHotel = dbContext.Hotels.SingleOrDefault(x => x.ID == model.Id);
                    //    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    //    this.context.Hotels.Update(hotel);
                    //    int res = this.context.SaveChanges();
                    //    if (res == 1)
                    //    {
                    //        return "";
                    //    }
                    //    return string.Format($"{Messages.UpdateFails} Hotel Id: {model.Id}");
                    getHotel.HotelName = model.HotelName;
                    getHotel.Address = model.Address;
                    getHotel.City = model.City;
                    getHotel.PostalCode = model.PostalCode;
                    getHotel.PhoneNumber = model.PhoneNumber;
                    getHotel.WebAddress = model.WebAddress;
                    dbContext.Update(getHotel);
                    dbContext.SaveChanges();
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
