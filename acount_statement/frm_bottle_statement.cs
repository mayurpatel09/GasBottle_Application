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

namespace GasBottle_Application.acount_statement
{
    public partial class frm_bottle_statement : Form
    {
        public frm_bottle_statement()
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
            
            if (textBox1.Text!=null)
            {
                mycon();
                cmd = new SqlCommand("SELECT TOP (1) tp.party_name,tb._date,tp._party_id FROM tbl_bottle as tb INNER JOIN tbl_party tp ON tb.party_id = tp.party_id WHERE  (tb.bottle_number = @bn) and (tb.btl_typ_id=@btid)", con);
                cmd.Parameters.AddWithValue("@bn", textBox1.Text);
                cmd.Parameters.AddWithValue("@btid", comboBox1.SelectedValue.ToString());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Please check Bottle Number Or Its Relevent Bottle type");
                }
                
            }
            else
            {
                MessageBox.Show("Plese Enter Bottle Number!");
            }

        }

        private void frm_bottle_statement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gasbottleDataSet1.tbl_bottle_type' table. You can move, or remove it, as needed.
            this.tbl_bottle_typeTableAdapter.Fill(this.gasbottleDataSet1.tbl_bottle_type);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
