﻿using Mango.Web.Utilities;
using static Mango.Web.Utilities.SD;

namespace Mango.Web.Models
{
    public class RequestDTO
    {
        public  ApiType ApiType { get; set; } = ApiType.GET;
        
        public string Url { get; set; } = string.Empty;

        public object Data { get; set; } 

        public string AccessToken { get; set; }
    }
}
