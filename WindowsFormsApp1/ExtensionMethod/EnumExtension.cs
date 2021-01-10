using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Core.ExtensionMethod
{
    public static class EnumExtension
    {
        public static string ToDescript(this Enum value)
        {
            Type type = value.GetType();
            var member = type.GetMember(value.ToString()).FirstOrDefault();

            if (Equals(member, null))
                return string.Empty;

            var description = member.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            if (Equals(description, null))
                return string.Empty;

            return description.Description;
        }
    }
}
