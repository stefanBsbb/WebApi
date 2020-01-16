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

    public class VisitorManager : BaseManager<VisitorModel>
    {
        private HotelsDBContext dbContext;
        public List<VisitorModel> AllVisitors
        {
            get
            {
                var models = MapperConfiguratior.Mapper.Map<List<VisitorModel>>(this.context.Visitors.ToList());
                return models;
            }
        }
        public VisitorManager() : base(new Data.HotelsDBContext())
        {

        }

        public override string Add(VisitorModel model)
        {
            try
            {
                using (context)
                {

                    Visitor visitor = MapperConfiguratior.Mapper.Map<Visitor>(model);
                    //employee.EmployeeNumber = NumberGenerator.EmployeeNumberGenerator(context);

                    this.context.Visitors.Add(visitor);
                    this.context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Delete(VisitorModel model)
        {
            try
            {
                using (context)
                {
                    Visitor visitor = MapperConfiguratior.Mapper.Map<Visitor>(model);
                    this.context.Visitors.Remove(visitor);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} Visitor Id: {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public override string Update(VisitorModel model)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var getVisitor = dbContext.Visitors.SingleOrDefault(x => x.ID == model.Id);
                    //    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    //    this.context.Hotels.Update(hotel);
                    //    int res = this.context.SaveChanges();
                    //    if (res == 1)
                    //    {
                    //        return "";
                    //    }
                    //    return string.Format($"{Messages.UpdateFails} Hotel Id: {model.Id}");
                    getVisitor.FirstName = model.FirstName;
                    getVisitor.SurName = model.SurName;
                    getVisitor.LastName = model.LastName;
                    getVisitor.City = model.City;
                    getVisitor.PhoneNumber = model.PhoneNumber;
                    getVisitor.Email = model.Email;
                    getVisitor.HotelID = model.HotelID;


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

