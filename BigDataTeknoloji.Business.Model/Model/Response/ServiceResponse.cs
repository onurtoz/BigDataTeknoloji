using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Model.Model.Response
{
    [Serializable]
    public class ServiceResponse<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }
        [JsonProperty]
        public T Entity { get; set; }
    }
}
