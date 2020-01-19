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
    public class EmployeeManager : BaseManager<EmployeeModel>
    {
        private HotelsDBContext dbContext;
        public List<EmployeeModel> AllEmployees
        {
            get
            {
                var models = MapperConfiguratior.Mapper.Map<List<EmployeeModel>>(this.context.Employees.ToList());
                return models;
            }
        }
        public EmployeeManager() : base(new Data.HotelsDBContext())
        {

        }

        public override string Add(EmployeeModel model)
        {
            try
            {
                using (context)
                {

                    Employee employee = MapperConfiguratior.Mapper.Map<Employee>(model);
                    this.context.Employees.Add(employee);
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
                    var entity = dbContext.Employees.FirstOrDefault(x => x.ID == id);
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
        public override string Delete(EmployeeModel model)
        {
            try
            {
                using (context)
                {
                    Employee employee = MapperConfiguratior.Mapper.Map<Employee>(model);
                    this.context.Employees.Remove(employee);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} Employee Id: {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public override string Update(EmployeeModel model)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var getEmployee = dbContext.Employees.SingleOrDefault(x => x.ID == model.Id);
                    //    Hotel hotel = MapperConfiguratior.Mapper.Map<Hotel>(model);
                    //    this.context.Hotels.Update(hotel);
                    //    int res = this.context.SaveChanges();
                    //    if (res == 1)
                    //    {
                    //        return "";
                    //    }
                    //    return string.Format($"{Messages.UpdateFails} Hotel Id: {model.Id}");
                    getEmployee.FirstName = model.LastName;
                    getEmployee.SurName = model.SurName;
                    getEmployee.LastName = model.LastName;
                    getEmployee.City = model.City;
                    getEmployee.Title = model.Title;
                    getEmployee.PhoneNumber = model.PhoneNumber;
                    getEmployee.EGN = model.EGN;
                    getEmployee.Hiredate = model.Hiredate;
                    getEmployee.Email = model.Email;
                    getEmployee.HotelID = model.HotelID;
                    dbContext.Update(getEmployee);
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
