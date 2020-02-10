using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RamuAndFriendsGenericsReflection
{
   public class Animals    {
    }

    public interface IAnimal { 
    }

    internal class noiseAttribute : Attribute    {
    }

    public class dog : IAnimal {
        [noise]
        public string bark() { return "bark"; }
    }

    public class cat : IAnimal {
        [noise]
        public string meow() { return "meow"; }

    }
    public static class helpers
    {
        public static string MakeNoice<T>(this IAnimal me)
        {
            //var t = me.GetType();
            var t = typeof(T);
            MethodInfo[] myArrayMethodInfo = t.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in myArrayMethodInfo)
            {
                //typeof gets the system type from an assembly
                if (method.GetCustomAttributes(typeof(noiseAttribute), true).Any())
                {
                   return method.Invoke(me, null).ToString();
                }
            }
            return string.Empty;
        }

        public static string MakeNoice(this IAnimal me)
        {
            var t = me.GetType();
            MethodInfo[] myArrayMethodInfo = t.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in myArrayMethodInfo)
            {
                //typeof gets the system type from an assembly
                if (method.GetCustomAttributes(typeof(noiseAttribute), true).Any())
                {
                    return method.Invoke(me, null).ToString();
                }
            }
            return string.Empty;
        }

    }
}
