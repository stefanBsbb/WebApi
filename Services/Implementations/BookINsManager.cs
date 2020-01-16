namespace Services.Implementations
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Services.Common;
    using Services.CustomModels;
    using Services.CustomModels.MapperConfig;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookINsManager
    {
        private HotelsDBContext context;
        public BookINsManager(HotelsDBContext data)
        {
            this.context = data;
        }
        public List<BookINsModel> GetBookedRooms(int top = 10)
        {
            try
            {
                using (context)
                {
                    var getBookins = context.BookIns.Include(x => x.Room).OrderByDescending(z => z.Room).Take(top).ToList();
                    var models = MapperConfiguratior.Mapper.Map<List<BookINsModel>>(getBookins);

                    return models;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

    }
}
