using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace IsHoroshiki.WebApi.Helpers
{
    /// <summary>
    /// Хелпер json
    /// </summary>
    public static class JSONHelper
    {
        /// <summary>  
        /// Сериализовать в строку 
        /// </summary>  
        /// <param name="obj"></param>  
        /// <returns></returns>  
        public static string ToJSON(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                return serializer.Serialize(obj);
            }
            catch
            {
                return "";
            }
        }
    }
}