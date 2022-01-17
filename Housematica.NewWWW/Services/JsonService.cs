using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Housematica.NewWWW.Services
{
    public class JsonService<T>
    {
        public static string convertToJson(T element)
        {
            var jsonElement = JsonConvert.SerializeObject(element, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return jsonElement;
        }

     

    }
}
