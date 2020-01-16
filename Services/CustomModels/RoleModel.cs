namespace Services.CustomModels
{
    using Services.CustomModels.Interfaces;

    public class RoleModel : ICustomModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
