using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Common;
using Services.CustomModels;
using Services.CustomModels.MapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
   public  class UsersManager
    {

        private HotelsDBContext context;
        public UsersManager(HotelsDBContext data)
        {
            this.context = data;
        }
        public List<UserModel> GetUsers(int top = 10)
        {
            try
            {
                using (context)
                {
                    var getUsers = context.Users.Include(x => x.ID).OrderByDescending(z => z.ID).Take(top).ToList();
                    var models = MapperConfiguratior.Mapper.Map<List<UserModel>>(getUsers);

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

