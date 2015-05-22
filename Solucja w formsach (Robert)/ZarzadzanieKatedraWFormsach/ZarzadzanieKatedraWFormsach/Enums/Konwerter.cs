using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieKatedraWFormsach
{
     public static class StaticTools
        {
            public static T ConvertToEnum<T>(this string value)
            {
                if (typeof(T).BaseType != typeof(Enum))
                {
                    throw new InvalidCastException();
                }

                if (Enum.IsDefined(typeof(T), value) == false)
                {
                    throw new InvalidCastException();
                }

                try
                {
                    return (T)Enum.Parse(typeof(T), value);
                }
                catch
                {
                    throw;
                }
            }
        }
    
}
