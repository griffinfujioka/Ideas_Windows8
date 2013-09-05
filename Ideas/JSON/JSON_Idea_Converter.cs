using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideas.DataModel;
using Newtonsoft; 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;     // JObject  


namespace Ideas.JSON
{
    class JSON_Idea_Converter : JsonCreationConverter<Idea>
    {
        protected override Idea Create(Type objectType, JObject jsonObject)
        {
            return new Idea(); 
            //var typeName = jsonObject["Idea"].ToString();
            //switch (typeName)
            //{
            //    case "Idea":
            //        return new Idea();
            //    default: return null;
            //}
        }
    }
}
