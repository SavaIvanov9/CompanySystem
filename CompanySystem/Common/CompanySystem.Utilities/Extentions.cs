using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.Utilities
{
    public static class Extentions
    {
        public static object GetReflectedProperty(this object targetObject, string propertyName)
        {
            if (targetObject == null)
            {
                throw new ArgumentException("TargetObject cannot be null");
            }
            if (propertyName == null)
            {
                throw new ArgumentException("PropertyName cannot be null");
            }
            
            PropertyInfo property = targetObject.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return null;
            }

            return property.GetValue(targetObject, null);
        }

    }
}
