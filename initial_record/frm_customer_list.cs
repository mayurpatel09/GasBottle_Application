using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

namespace GasBottle_Application.initial_record
{
    public partial class frm_customer_list : Form
    {
        private string FromFormValues;
        public string returnPartyId;
        public string returnPartyName;

        BackgroundWorker bg;
        static string data1 = "";
        //string data = "";
        private List<string> items;
        public frm_customer_list()
        {
            InitializeComponent();
            initbackworker();
            // datat();
        }
        public void initbackworker()
        {
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.ProgressChanged += new ProgressChangedEventHandler(bg_ProgressChanged);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.WorkerReportsProgress = true;
            bg.WorkerSupportsCancellation = true;
        }
        public frm_customer_list(string FromFormValues)
        {
            InitializeComponent();
            initbackworker();
            // TODO: Complete member initialization
            this.FromFormValues = FromFormValues;
        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "Data Retriving Cancelled...";
            }
            else if (e.Error != null)
            {
                label1.Text = "Error While Getting Customers Name...";
            }
            else
            {
                listBox1.DataSource = items;
                label1.Text = "Complete....!";
            }
        }

        void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Processing......" + progressBar1.Value.ToString() + " % ";
            label1.Text += "\n" + data1;
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            mycon();
            items = new List<string>();
            cmd = new SqlCommand("select * from tbl_party", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Thread.Sleep(100);
                data1 = dt.Rows[i]["_party_id"].ToString() + " - " + dt.Rows[i][1].ToString();
                items.Insert(i, data1.ToUpper());
                int provalue = (((i + 1) * 100) / dt.Rows.Count);
                bg.ReportProgress(provalue);
                if (bg.CancellationPending)
                {
                    e.Cancel = true;
                    bg.ReportProgress(0);
                    return;
                }

            }
            bg.ReportProgress(100);
        }
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }


        private void frm_customer_list_Load(object sender, EventArgs e)
        {
            bg.RunWorkerAsync();
        }
        string stringg;
        //string Name;
        string id;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex > -1)
            //{
            //    stringg = listBox1.SelectedItem.ToString();
            //    string[] name = stringg.Split('-');
            //    Name = name[1].ToString();
            //    id = name[0].ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FromFormValues == null)
            {
                stringg = listBox1.SelectedItem.ToString();
                string[] name = stringg.Split('-');
                string name1 = name[1].ToString();
                id = name[0].ToString();
                frm_creat_customer fcr = new frm_creat_customer(name1, id);
                fcr.ShowDialog();
                this.Close();
            }
            else if (FromFormValues == "GanarateSales")
            {
                stringg = listBox1.SelectedItem.ToString().ToLower();
                string[] name = stringg.Split('-');
                returnPartyName = name[1].ToString().Trim();
                returnPartyId = name[0].ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                this.Close();
            }
            else if (FromFormValues == "partystatement")
            {
                stringg = listBox1.SelectedItem.ToString().ToLower();
                string[] name = stringg.Split('-');
                returnPartyName = name[1].ToString().Trim();
                returnPartyId = name[0].ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                this.Close();
            }
            else if (FromFormValues == "partybymonthchalan")
            {
                stringg = listBox1.SelectedItem.ToString().ToLower();
                string[] name = stringg.Split('-');
                returnPartyName = name[1].ToString().Trim();
                returnPartyId = name[0].ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                this.Close();
                
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                items = new List<string>();

                mycon();
                cmd = new SqlCommand("Select * from tbl_party where party_name LIKE @pn", con);
                cmd.Parameters.AddWithValue("@pn", textBox1.Text + "%");
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data1 = dt.Rows[i]["_party_id"].ToString() + " - " + dt.Rows[i][1].ToString();
                    items.Insert(i, data1.ToUpper());

                }
                listBox1.DataSource = items;
            }
            else
            {
                items = new List<string>();
                mycon();
                cmd = new SqlCommand("select * from tbl_party", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data1 = dt.Rows[i]["_party_id"].ToString() + " - " + dt.Rows[i][1].ToString();
                    items.Insert(i, data1.ToUpper());

                }
                listBox1.DataSource = items;
            }


        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                stringg = listBox1.SelectedItem.ToString();
                string[] name = stringg.Split('-');
                Name = name[1].ToString();
                id = name[0].ToString();
            }
        }

    }
}
