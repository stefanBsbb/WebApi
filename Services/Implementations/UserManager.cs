using Data;
using Models;
using Services.Common;
using Services.CustomModels;
using Services.CustomModels.MapperConfig;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class UserManager :BaseManager<UserModel>
    {
        public List<UserModel> AllUsers
        {
            get
            {
                var res = MapperConfiguratior.Mapper.Map<List<UserModel>>(this.context.Users.ToList());
                //var res = this.context.Users.ToList();
                return res;
            }
        }
        public UserManager() : base(new HotelsDBContext())
        {

        }
        public override string Add(UserModel model)
        {
            try
            {
                using (context)
                {
                    User user = MapperConfiguratior.Mapper.Map<User>(model);
                    this.context.Users.Add(user);
                    this.context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Delete(UserModel model)
        {
            try
            {
                using (context)
                {
                    User user = MapperConfiguratior.Mapper.Map<User>(model);
                    this.context.Users.Remove(user);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.DeleteFails} {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override string Update(UserModel model)
        {
            try
            {
                using (context)
                {
                    User user = MapperConfiguratior.Mapper.Map<User>(model);
                    this.context.Users.Update(user);
                    int res = this.context.SaveChanges();
                    if (res == 1)
                    {
                        return "";
                    }
                    return string.Format($"{Messages.UpdateFails} {model.Id}.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
