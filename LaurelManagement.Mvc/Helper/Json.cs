using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Mvc.Helper
{
    public static class Json
    {
        public static string ToJson( this object value)
        {
            var returnValue = string.Empty;
            try
            {
                returnValue = Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings { PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects });
            }
            catch (Exception)
            {

                throw;
            }
            return returnValue;
        }
    }
}
