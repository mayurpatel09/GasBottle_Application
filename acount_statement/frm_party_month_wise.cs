using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GasBottle_Application.initial_record;
using System.Data.SqlClient;
using System.Configuration;
using GasBottle_Application.transaction;
namespace GasBottle_Application.acount_statement
{
    public partial class frm_party_month_wise : Form
    {
        public frm_party_month_wise()
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
            using (var partyList = new frm_customer_list("partybymonthchalan"))
            {
                var partyForm = partyList.ShowDialog();
                if (partyList.DialogResult == DialogResult.OK)
                {
                    textBox1.Text = partyList.returnPartyName;
                    textBox2.Text = partyList.returnPartyId;
                    if (textBox1.Text != "")
                    {
                        mycon();
                        cmd = new SqlCommand("SELECT * FROM  getchalanstatement WHERE (MONTH(sales_date) = MONTH(@date)) AND (YEAR(sales_date) = YEAR(@date)) AND (_party_id = @pid)", con);
                        cmd.Parameters.AddWithValue("@pid", textBox2.Text);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string chalan_no=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            frm_generate_sale fgs = new frm_generate_sale(chalan_no);
            fgs.Show();
        }
    }
}
