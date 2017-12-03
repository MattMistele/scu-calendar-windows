using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

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
            // Thursday December 3, 7:00pm - 9:00pm Weekly (to Dec 4)
            //
            // if stuff is missing, don't put it in the string
            // ex: 7:00pm
            // ex: 7:00pm Weekly (to Dec 4)

            DateTime start = ConvertToDateTime(starttime);


            string day = start.DayOfWeek.ToString();
            string month = start.Month.ToString();
            string dayOfMonth = start.Day.ToString();
            string pm = "am";
            int h = start.Hour;
            if (h > 12)
            {
                h -= 12;
                pm = "pm";
            }
            string hour = h.ToString();
            string minute = start.Minute.ToString() + "0";

            string datetime = "";

            datetime = datetime + day + " " + month + "/" + dayOfMonth + ", " + hour + ":" + minute + pm;

            if (endtime != null)
            {
                DateTime end = ConvertToDateTime(endtime);

            }

            //CODE GOS HERE

            return datetime;
        }

        private DateTime ConvertToDateTime(string timeToConvert)
        {
            //2017-12-02T19:00:00.000000

            int year;
            int month;
            int day;
            int hour;

            char[] cArr = timeToConvert.ToCharArray();

            string y = "";
            y = y + cArr[0] + cArr[1] + cArr[2] + cArr[3];
            year = Convert.ToInt32(y);

            string m = "";
            m = m + cArr[5] + cArr[6];
            month = Convert.ToInt32(m);

            string d = "";
            d = d + cArr[8] + cArr[9];
            day = Convert.ToInt32(d);

            string h = "";
            h = h + cArr[11] + cArr[12];
            hour = Convert.ToInt32(h);

            DateTime time = new DateTime(year, month, day, hour, 0, 0);


            return time;
        }
    }
}
