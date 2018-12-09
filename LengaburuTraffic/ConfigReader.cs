using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengaburuTraffic
{
    public class ConfigReader:IConfigReader
    {
        public virtual T GetValue<T>(string key)
        {
            object value = ConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(value, typeof(T));
        }


        

        public virtual ArrayList GetValueCollection<T>(string key)
        {
            var values = ConfigurationManager.AppSettings[key];

            Type ParameterType = typeof(T);

            ArrayList collection = new ArrayList();
            switch (Type.GetTypeCode(ParameterType))
            {
                case TypeCode.String:
                    foreach (var item in values.Split(';'))
                    {
                        collection.Add(item);
                    }

                    return collection;

            }
            return null;
        }
    }
}
