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

    public class BookINManager : BaseManager<BookINsModel>
    {
        private HotelsDBContext dbContext;
        public List<BookINsModel> AllBookIns
        {
            get
            {
                var res = MapperConfiguratior.Mapper.Map<List<BookINsModel>>(this.context.BookIns.ToList());

                return res;
            }
        }
        public BookINManager() : base(new HotelsDBContext())
        {

        }
        public override string Add(BookINsModel model)
        {
            try
            {
                using (context)
                {
                   
                    BookIn bookIn = MapperConfiguratior.Mapper.Map<BookIn>(model);
                    this.context.BookIns.Add(bookIn);
                    this.context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Delete(BookINsModel model)
        {
            try
            {
                using (context)
                {
                    BookIn bookIn = MapperConfiguratior.Mapper.Map<BookIn>(model);
                    this.context.BookIns.Remove(bookIn);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} {model.EmployeeID}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Update(BookINsModel model)
        {
            try
            {
                using (context)
                {
                    BookIn bookIn = MapperConfiguratior.Mapper.Map<BookIn>(model);
                    this.context.BookIns.Update(bookIn);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.UpdateFails} {model.EmployeeID}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

