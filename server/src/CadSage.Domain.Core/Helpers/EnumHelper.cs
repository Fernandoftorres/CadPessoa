using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CadSage.Domain.Core.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            else
            {
                return "Não identificado";
            }
        }

        public static string GetDisplayValue(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes == null) return value.ToString();
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            else{
                return string.Empty;
            }
        }

        public static string ObterValorEnum<T>(string enumConst) where T : struct
        {
            string resultado = string.Empty;

            T temp = default(T);
            if (Enum.TryParse<T>(enumConst, out temp))
            {
                resultado = temp.ToString();
            }
            return resultado;
        }
    }
}
