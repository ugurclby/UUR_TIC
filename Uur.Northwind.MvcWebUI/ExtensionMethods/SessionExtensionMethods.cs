using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uur.Northwind.MvcWebUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject (this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session,string key) where T:class
        {
            string objectString = session.GetString(key);

            if (String.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T objectValue = JsonConvert.DeserializeObject<T>(objectString);
            return objectValue;
        }
    }
}
