using Services.CustomModels;
using System;
using System.Reflection;
using System.Text;

namespace Services.Common
{
    public static class ModelInfo
    {
        public static string TurnModelToString(RegisterModel model)
        {
            var getProperties = model.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo property in getProperties)
            {
                var propValue = property.GetValue(model, null);
                if (property.Name == Enum.GetName(typeof(ModelProperties), ModelProperties.Password) || property.Name == Enum.GetName(typeof(ModelProperties), ModelProperties.ConfirmPassword))
                {
                    continue;
                }
                sb.Append(string.Format($"{property.Name}: {propValue} "));
            }
            return sb.ToString();
        }
    }
}
