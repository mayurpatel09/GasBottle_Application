using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GasBottle_Application.initial_record;
using System.Configuration;
namespace GasBottle_Application.company
{
    public partial class frm_company_information : Form
    {
        public frm_company_information()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());
           
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("select * from tbl_company_info", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmd = new SqlCommand("company_info", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", 1);
                cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                cmd.Parameters.AddWithValue("@coname", textBox2.Text);
                cmd.Parameters.AddWithValue("@ccontact", textBox7.Text);
                cmd.Parameters.AddWithValue("@cct", textBox3.Text);
                cmd.Parameters.AddWithValue("@ctin", textBox4.Text);
                cmd.Parameters.AddWithValue("@cemel", textBox5.Text);
                cmd.Parameters.AddWithValue("@add", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully...");
                frm_financial_year ffy = new frm_financial_year();
                ffy.ShowDialog();
            }
            else
            {
                cmd = new SqlCommand("company_info", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", 0);
                cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                cmd.Parameters.AddWithValue("@coname", textBox2.Text);
                cmd.Parameters.AddWithValue("@ccontact", textBox7.Text);
                cmd.Parameters.AddWithValue("@cct", textBox3.Text);
                cmd.Parameters.AddWithValue("@ctin", textBox4.Text);
                cmd.Parameters.AddWithValue("@cemel", textBox5.Text);
                cmd.Parameters.AddWithValue("@add", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("insert Successfully...");

                
            }

        }

        private void frm_company_information_Load(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("select * from tbl_company_info", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                button1.Text = "Update";
                textBox7.Text = dt.Rows[0]["c_contact_no"].ToString();
                textBox6.Text = dt.Rows[0]["c_address"].ToString();
                textBox5.Text = dt.Rows[0]["c_email"].ToString();
                textBox4.Text = dt.Rows[0]["c_tin_no"].ToString();
                textBox3.Text = dt.Rows[0]["c_city"].ToString();
                textBox2.Text = dt.Rows[0]["c_owner_name"].ToString();
                textBox1.Text = dt.Rows[0]["c_name"].ToString();
            }


        }
    }
}
