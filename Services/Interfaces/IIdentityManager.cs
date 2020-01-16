using Services.CustomModels;


namespace Services.Interfaces
{
    public interface IIdentityManager
    {

        string LoginUser(LoginModel model);

        string Register(RegisterModel model);

        string EditUser(UserModel model);
        string DeleteUser(int id);


    }
}
