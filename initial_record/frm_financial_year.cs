using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace GasBottle_Application.initial_record
{
    public partial class frm_financial_year : Form
    {
        public frm_financial_year()
        {
            InitializeComponent();
        }
       // SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        //DataTable dt;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("insert into tbl_financial_year(year_s,year_e) values(@year_s,@year_e)", con);
            cmd.Parameters.AddWithValue("@year_s", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@year_e", dateTimePicker2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Finamcial Year Added Succesfully!!..");
        }

        private void frm_financial_year_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gasbottleDataSet3.tbl_financial_year' table. You can move, or remove it, as needed.
            this.tbl_financial_yearTableAdapter.Fill(this.gasbottleDataSet3.tbl_financial_year);

        }
    }
}
