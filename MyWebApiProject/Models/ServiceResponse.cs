using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiProject.Models
{
    public class ServiceResponse<T> : BaseResponse
    {
        [JsonProperty]
        public T Entity { get; set; }
        [JsonProperty]
        public List<T> Entities { get; set; }

        public ServiceResponse()
        {
            Errors = new List<string>();
            Entities = new List<T>();
        }
    }
}
