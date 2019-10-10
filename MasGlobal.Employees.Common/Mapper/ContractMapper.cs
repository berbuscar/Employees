using System;
using System.Reflection;

namespace MasGlobal.Employees.Common.Mapper
{
    public class ContractMapper
    {
        public object MapRequestToExpected(object response,
                                           object source, 
                                           Type targetType)
        {
            object result = response;

            foreach (PropertyInfo pi in targetType.GetProperties())
            {
                string targetProperty = pi.Name;
                Type pitype = pi.PropertyType;
                object parentInstance = null;

                parentInstance = GetPropertyValueFromSource(source, targetProperty, pitype);

                if (parentInstance != null)
                {
                    pi.SetValue(result, parentInstance);
                }
            }
            return result;
        }

        public object MapResponseToExpected(object response, Type sourceType, Type targetType)
        {
            object result = Activator.CreateInstance(targetType);

            foreach (PropertyInfo pi in targetType.GetProperties())
            {
                string targetProperty = pi.Name;
                Type pitype = pi.PropertyType;
                object parentInstance = null;

                parentInstance = GetPropertyValueFromSource(response, targetProperty, pitype);

                if (parentInstance != null)
                {
                    pi.SetValue(result, parentInstance);
                }
            }
            return result;
        }

        //get information from source object
        private object GetPropertyValueFromSource(object objOrigen,
                                                 string propNameDestino,
                                                 Type typePropDestino)
        {
            PropertyInfo pi = objOrigen.GetType().GetProperty(propNameDestino);

            if (pi == null)
                return null;

            Type pitype = pi.PropertyType;

            string propNameSource = pi.Name;
            object ret = pi.GetValue(objOrigen, null);

            return Convert.ChangeType(ret, typePropDestino);
        }
    }
}
