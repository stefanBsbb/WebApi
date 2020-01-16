namespace Services.Implementations
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Services.CustomModels;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserRolesManager : BaseManager<UserRolesModel>
    {
        public UserRolesManager() : base(new HotelsDBContext())
        {
        }

        public ICollection<UserRolesModel> GetAll(int userId)
        {
            try
            {

                using (context)
                {
                    var getUser = context.UserRoles.Where(x => x.UserID == userId).Include(x => x.Role).ToList();

                    var result = getUser.Select(x => new UserRolesModel()
                    {
                        Roles = new List<RoleModel>() { new RoleModel() { RoleName = x.Role.RoleName, Id = x.Role.ID } },
                        UserId = x.UserID
                    }).ToList();


                    return result;
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public override string Add(UserRolesModel model)
        {
            try
            {
                using (context)
                {
                    User getUser = context.Users.SingleOrDefault(x => x.ID == model.Id);

                    List<Role> roles = context.Roles.Where(x => model.RoleIds.Contains(x.ID)).ToList();

                    foreach (var role in roles)
                    {
                        if (getUser.UserRoles.FirstOrDefault(x => x.RoleID == role.ID) == null)
                        {
                            getUser.UserRoles.Add(new UserRoles() { RoleID = role.ID, UserID = getUser.ID, Role = role, User = getUser });
                        }

                    }

                    context.Users.Update(getUser);
                    context.SaveChanges();
                    return "";
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public override string Update(UserRolesModel model)
        {
            using (context)
            {
                User user = this.context.Users.Include(x => x.UserRoles).Single(x => x.ID == model.UserId);

                List<int> newRoles = this.context.UserRoles.Where(x => x.UserID == user.ID).Select(x => x.RoleID).Where(x => model.RoleIds.Contains(x)).ToList();

                user.UserRoles.Clear();

                List<Role> getRoles = this.context.Roles.Where(x => newRoles.Contains(x.ID)).ToList();

                foreach (var role in getRoles)
                {
                    user.UserRoles.Add(new UserRoles() { Role = role });
                }
                this.context.SaveChanges();


            }
            return "";
        }

        public override string Delete(UserRolesModel model)
        {
            try
            {
                using (context)
                {
                    User getUser = context.Users.SingleOrDefault(x => x.ID == model.Id);
                    List<UserRoles> roles = context.UserRoles.Where(x => !model.RoleIds.Contains(x.ID)).ToList();
                    foreach (var role in roles)
                    {
                        getUser.UserRoles.Remove(role);
                    }
                    context.Users.Update(getUser);
                    context.SaveChanges();
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
