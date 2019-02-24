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
using GasBottle_Application.initial_record;

namespace GasBottle_Application.transaction
{
    public partial class frm_list_of_chalan : Form
    {
        public frm_list_of_chalan()
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
            //cmd = new SqlCommand("select * from getchalanstatement WHERE (sales_date BETWEEN @date AND  getdate() )", con);
            cmd = new SqlCommand("Select * from getchalanstatement Where MONTH(sales_date) = MONTH(@date) AND YEAR(sales_date) = YEAR(@date)", con);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //    using (var partyList = new frm_customer_list("partybymonthchalan"))
            //    {
            //        var partyForm = partyList.ShowDialog();
            //        if (partyList.DialogResult == DialogResult.OK)
            //        {
            //            //textBox1.Text = partyList.returnPartyName;
            //            //textBox2.Text = partyList.returnPartyId;
            //            //if (textBox1.Text != "")
            //            //{
            //                mycon();
            //                cmd = new SqlCommand("SELECT * FROM  getchalanstatement WHERE (MONTH(sales_date) = MONTH(@date)) AND (YEAR(sales_date) = YEAR(@date)) AND (_party_id = @pid)", con);
            //                cmd.Parameters.AddWithValue("@pid", partyList.returnPartyId);
            //                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);

            //                da = new SqlDataAdapter(cmd);
            //                dt = new DataTable();
            //                da.Fill(dt);
            //                dataGridView1.DataSource = dt;
            //                //if (dt.Rows.Count > 0)
            //                //{
            //                //    //int sum = Convert.ToInt32(dt.Compute("SUM(count)", string.Empty));
            //                //    //label2.Text = sum.ToString();
            //                //    con.Close();

            //                //    mycon();
            //                //    cmd = new SqlCommand("select party_name from tbl_party where _party_id=@pid", con);
            //                //    cmd.Parameters.AddWithValue("@pid", textBox1.Text);
            //                //    dr = cmd.ExecuteReader();
            //                //    while (dr.Read())
            //                //    {
            //                //        textBox2.Text = dr[0].ToString();
            //                //    }
            //                //    con.Close();
            //                //    cmd.Dispose();
            //                //}
            //            }
            //        }
            //    }

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}

