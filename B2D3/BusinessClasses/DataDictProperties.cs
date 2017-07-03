using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace B2D3.Classes
{
    public class DataDictProperties
    {
        public static Dictionary<string, object> DictionaryFromType(object aObj)
        {
            // is er een object meegegeven?
            if (aObj == null) return new Dictionary<string, object>();

            Type t = aObj.GetType();
            PropertyInfo[] props = t.GetProperties();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = null;
                if (prp.PropertyType.Name == "ICollection`1")   // 1ste regel bevat info over object deze regel negeren!
                    continue;
                value = prp.GetValue(aObj, new object[] { });   // haal waarde uit het object 
                dict.Add(prp.Name, value);                      // haal veldnaam en data uit het array.
            }
            return dict;
        }
    }
}