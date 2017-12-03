using System;

namespace SCUCalendar
{
    public class Event
    {
        public string Title;
        public int Starttime;
        public int? Endtime;
        public string Postfix;
        public string Location;
        public string Summary;
        
        public Event(string title, int starttime, int? endtime, string postfix, string location, string summary)
        {
            Title = title;
            Starttime = starttime;
            Endtime = endtime;
            Postfix = postfix;
            Location = location;
            Summary = summary;
        }

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
