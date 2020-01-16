using System;
using Data;
using System.Collections.Generic;
using System.Text;
using Services.CustomModels.Interfaces;
namespace Services.Interfaces
{
    public abstract class BaseManager<T> where T : ICustomModel
    {
        protected HotelsDBContext context;
        public BaseManager(HotelsDBContext db)
        {
            this.context = db;
        }
        public abstract string Add(T model);
        public abstract string Update(T model);
        public abstract string Delete(T model);
    }
}
