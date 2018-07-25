using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace OfficeApp.Models
{
    public class Department : BindableBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("head")]
        public string Head { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
