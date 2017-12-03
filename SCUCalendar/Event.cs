using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SCUCalendar
{
    public class Event
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("start_time")]
        public string starttime { get; set; }
        [JsonProperty("end_time")]
        public string endtime { get; set; }
        [JsonProperty("time_postfix")]
        public string postfix { get; set; }
        [JsonProperty("location")]
        public string location { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }

        public string DateToString()
        {
            // TODO: take the start time, end time, and postfix to return a string such as:
            // 7:00pm - 9:00pm Weekly (to Dec 4)
            //
            // if stuff is missing, don't put it in the string
            // ex: 7:00pm
            // ex: 7:00pm Weekly (to Dec 4)

            return null;
        }
    }
}
