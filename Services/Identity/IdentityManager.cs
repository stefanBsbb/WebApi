﻿namespace Services.Identity
{
    using Data;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using Services.Common;
    using Services.CustomModels;
    using Services.CustomModels.MapperConfig;
    using Services.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class IdentityManager : IIdentityManager
    {
        private readonly TokenModel _tokenManagement;
        private HotelsDBContext dbContext;
        private User User;

        public IdentityManager(HotelsDBContext data, IOptions<TokenModel> tokenManagement)
        {
            this.dbContext = data;
            this._tokenManagement = tokenManagement.Value;
        }
        /// <summary>
        /// Validate current user attempt to login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool IsValidUser(LoginModel model)
        {
            var currentUser = this.dbContext.Users.SingleOrDefault(x => x.Email == model.Email);

            if (currentUser != null)
            {
                var res = this.VerifyHashedPassword(currentUser.Password, model.Password);
                User = currentUser;
                return res;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks if user is already register. Default value false.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool isRegistered(string email)
        {
            var check = this.dbContext.Users.SingleOrDefault(x => x.Email == email);
            if (check != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Generates user token after successful register/login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GenerateUserToken(RequestTokenModel request)
        {
            string token = string.Empty;

            var claim = new List<Claim>()
            {
              new Claim(ClaimTypes.Email, request.Email)
            };

            for (int i = 0; i < User.UserRoles.Count; i++)
            {
                claim.Add(new Claim(ClaimTypes.Role, User.UserRoles.ToList()[i].Role.RoleName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
        /// <summary>
        /// Login user to the system
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string LoginUser(LoginModel model)
        {
            if (this.IsValidUser(model))
            {
                var token = this.GenerateUserToken(new RequestTokenModel() { Email = model.Email });
                if (token.Length > 0)
                {
                    dbContext.UserTokens.Add(new UserToken() { Token = token, User = User });
                    dbContext.SaveChanges();

                    return token;
                }
            }

            return "";
        }
        /// <summary>
        /// Adds new user to Db. If model is not valid return false
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Register(RegisterModel model)
        {
            if (this.isRegistered(model.Email) == false)
            {
                User = new User();

                var token = GenerateUserToken(new RequestTokenModel() { Email = model.Email });

                User = MapperConfiguratior.Mapper.Map<User>(model);

                User.Password = HashPassword(model.Password);

                var userToken = new UserToken() { Token = token, User = User };
                var getRolesFromDb =
                this.dbContext
                .Roles
                .Where(x => model.Roles.Select(z => z.RoleName).Contains(x.RoleName)).ToList();

                foreach (var role in getRolesFromDb)
                {
                    User.UserRoles.Add(new UserRoles() { Role = role });

                }

                this.dbContext.Users.Add(User);
                this.dbContext.UserTokens.Add(userToken);
                this.dbContext.SaveChanges();

                return token;

            }
            return "";
        }
        public string EditUser(UserModel model)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var getUser = dbContext.Users.SingleOrDefault(x => x.ID == model.Id);
                    //getUser = MapperConfigurator.Mapper.Map<User>(model);
                    if (getUser.Email != model.Email)
                    {
                        var checkEmail = dbContext.Users.Where(x => x.Email == model.Email).FirstOrDefault();
                        if (checkEmail != null)
                        {
                            return Messages.EmailExists;
                        }
                    }
                    getUser.Email = model.Email;
                    getUser.FirstName = model.FirstName;
                    getUser.LastName = model.LastName;

                    var checkPasswordChange = VerifyHashedPassword(getUser.Password, model.Password);
                    if (checkPasswordChange == false)
                    {
                        getUser.Password = HashPassword(model.Password);
                    }

                    dbContext.Update(getUser);
                    dbContext.SaveChanges();
                    return "";
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                using (dbContext = new HotelsDBContext())
                {
                    var entity = dbContext.Users.FirstOrDefault(x => x.ID == id);
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
        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] buffer3, byte[] buffer4)
        {
            var res = StructuralComparisons.StructuralEqualityComparer.Equals(buffer3, buffer4);
            return res;
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("Password is empty");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }


    }
}
