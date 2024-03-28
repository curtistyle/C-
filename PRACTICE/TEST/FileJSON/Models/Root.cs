using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileJSON.Models
{
    public class Root
    {
        public Words words { get; set; }

        [JsonConstructor]
        public Root(Words words)
        {
            this.words = words;
        }
    }
    public class Words
    {
        public List<English> english { get; set; }
        public List<Spanish> spanish { get; set; }

        [JsonConstructor]
        public Words(List<English> english, List<Spanish> spanish)
        {
            this.english = english;
            this.spanish = spanish;
        }


    }

    public class English
    {
        public string value { get; set; }
        public int key { get; set; }

        [JsonConstructor]
        public English(string value, int key)
        {
            this.value = value;
            this.key = key;
        }
    }


    public class Spanish
    {
        public object value { get; set; }
        public object key { get; set; }

        [JsonConstructor]
        public Spanish(object value, object key)
        {
            this.value = value;
            this.key = key;
        }
    }
}
