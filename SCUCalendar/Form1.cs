using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCUCalendar
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            InitializeFilterListView();
           
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
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
    }
}
