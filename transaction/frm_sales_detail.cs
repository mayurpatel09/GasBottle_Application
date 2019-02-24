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

namespace GasBottle_Application.transaction
{
    public partial class frm_sales_detail : Form
    {
        public frm_sales_detail()
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
        private void button2_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("select * from getchalanstatement where chalan_no=@chno", con);
            cmd.Parameters.AddWithValue("@chno", textBox1.Text);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            textBox2.Text = dt.Rows[0]["party_name"].ToString();
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
    }
}
