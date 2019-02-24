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
    public partial class frm_creat_customer : Form
    {
        public frm_creat_customer(string name1)
        {
            InitializeComponent();
            this.name1 = name1;
            // TODO: Complete member initialization

        }

        public frm_creat_customer(string name1, string id)
        {
            InitializeComponent();
            this.name1 = name1;
            this.id = id;
            edit();

        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private string id;
        private string name1;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        void edit()
        {
            if (name1 != "")
            {
                mycon();
                cmd = new SqlCommand("select * From tbl_party where _party_id=@pn", con);
                cmd.Parameters.AddWithValue("@pn", id);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[1].ToString();
                    textBox2.Text = dr[5].ToString();
                    textBox3.Text = dr[4].ToString();
                    textBox4.Text = dr["_party_id"].ToString();
                    button2.Enabled = true;
                    button1.Enabled = false;
                    button3.Enabled = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("party", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", 0);
            cmd.Parameters.AddWithValue("@pname", textBox1.Text);
            cmd.Parameters.AddWithValue("@st", 0);
            cmd.Parameters.AddWithValue("@ct", 0);
            cmd.Parameters.AddWithValue("@add", textBox3.Text);
            cmd.Parameters.AddWithValue("@con", textBox2.Text);
            cmd.Parameters.AddWithValue("@dt", SqlDbType.DateTime);
            cmd.Parameters.AddWithValue("@areid", 0);
            cmd.Parameters.AddWithValue("@_pid", textBox4.Text.ToLower());
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {
                MessageBox.Show("successfully added!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("party", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", dr["party_id"]);
            cmd.Parameters.AddWithValue("@pname", textBox1.Text);
            cmd.Parameters.AddWithValue("@st", 0);
            cmd.Parameters.AddWithValue("@ct", 0);
            cmd.Parameters.AddWithValue("@add", textBox3.Text);
            cmd.Parameters.AddWithValue("@con", textBox2.Text);
            cmd.Parameters.AddWithValue("@dt", SqlDbType.DateTime);
            cmd.Parameters.AddWithValue("@areid", 0);
            cmd.Parameters.AddWithValue("@_pid", textBox4.Text);
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {
                MessageBox.Show("successfully Updated!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!!!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mycon();

            cmd = new SqlCommand("delete from tbl_party where _party_id=@pid",con);
            cmd.Parameters.AddWithValue("@pid",textBox4.Text);
            int success=cmd.ExecuteNonQuery();
            if (success==1)
            {
                MessageBox.Show("Party Deleted Successfully...");
                dr.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Party Id");
            }
        }
    }
}
