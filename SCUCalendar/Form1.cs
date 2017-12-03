using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCUCalendar
{
    public partial class Form1 : Form
    {

        #region Variables
        const string EVENTS_URL = "https://scu-events.herokuapp.com/api/events";

        public Event[] eventList;

        #endregion

        #region Initialization
        public Form1()
        {
            InitializeComponent();

            eventList = GetEventListFromJSON();

            InitializeFilterListView();
            InitializeEventsListView();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //****************************************************
        // Initialize Filters ListView
        //****************************************************
        private void InitializeFilterListView()
        {
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Filter Type", 150);
            listView1.Columns.Add("Value", 213);

            //Add some dummmy items to the listview
            string[] arr = new string[2];
            ListViewItem itm;

            arr[0] = "Keyword";
            arr[1] = "Engineering";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            arr[0] = "Keyword";
            arr[1] = "Bible Study";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }

        //****************************************************
        // Initialize Events ListView
        //****************************************************
        private void InitializeEventsListView()
        {
            listView2.FullRowSelect = true;

            //Add column header
            listView2.Columns.Add("Title", 150);
            listView2.Columns.Add("Start Time", 213);
            listView2.Columns.Add("End Time", 150);
            listView2.Columns.Add("Location", 150);
            listView2.Columns.Add("PostFix", 150);
            listView2.Columns.Add("Description", 150);

            foreach (Event e in eventList)
            {
                string[] array = new string[6];
                ListViewItem item;

                array[0] = e.title;
                array[1] = e.starttime;
                array[2] = e.endtime;
                array[3] = e.location;
                array[4] = e.postfix;
                array[5] = e.description;
                item = new ListViewItem(array);
                listView2.Items.Add(item);
            }


        }
        #endregion

        #region Add Delete Filters
        //****************************************************
        // ADD FILTER BY KEYWORD
        //****************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[2];
            arr[0] = "Keyword";
            arr[1] = keywordTextbox.Text;

            ListViewItem itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            keywordTextbox.Text = "";
        }



        //****************************************************
        // DELETE FILTER
        //****************************************************
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this filter?", "Delete Filter", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = listView1.SelectedItems[i];
                        listView1.Items[itm.Index].Remove();
                    }
                }
            }
            else
                MessageBox.Show("Please select a filter", "Delete Filter");
        }
        #endregion


        #region Helper Methods
        private static Event[] GetEventListFromJSON()
        {
            WebClient client = new WebClient();
            string json = client.DownloadString(EVENTS_URL);

            Event[] events = JsonConvert.DeserializeObject<Event[]>(json);
           
            return events;
        }
        #endregion

    }
}
