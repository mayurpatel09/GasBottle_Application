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

namespace GasBottle_Application.acount_statement
{
    public partial class frm_party_statement : Form
    {
        public frm_party_statement()
        {
            InitializeComponent();

        }
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                mycon();
                cmd = new SqlCommand("select * from getpartybottlecount Where party_id in (select party_id from tbl_party where _party_id=@pid)", con);
                cmd.Parameters.AddWithValue("@pid", textBox1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    int sum = Convert.ToInt32(dt.Compute("SUM(count)", string.Empty));
                    label2.Text = sum.ToString();
                    con.Close();

                    mycon();
                    cmd = new SqlCommand("select party_name from tbl_party where _party_id=@pid", con);
                    cmd.Parameters.AddWithValue("@pid", textBox1.Text);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                    }
                    con.Close();
                    cmd.Dispose();
                }
                else
                {
                    MessageBox.Show("This Party ID is not Exist...", "Party Availibity", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void frm_party_statement_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            this.ActiveControl = dataGridView1;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["View"].Index)
            {
                return;
            }
            else
            {
                string type = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string pid = textBox1.Text;
                frm_show_bottle fsb = new frm_show_bottle(type, pid);
                fsb.ShowDialog();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var partyList = new frm_customer_list("partystatement"))
            {
                var partyForm = partyList.ShowDialog();
                if (partyList.DialogResult == DialogResult.OK)
                {
                    textBox2.Text = partyList.returnPartyName;
                    textBox1.Text = partyList.returnPartyId;
                    if (textBox1.Text != "")
                    {
                        mycon();
                        cmd = new SqlCommand("select * from getpartybottlecount Where party_id in (select party_id from tbl_party where _party_id=@pid)", con);
                        cmd.Parameters.AddWithValue("@pid", textBox1.Text);
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            int sum = Convert.ToInt32(dt.Compute("SUM(count)", string.Empty));
                            label2.Text = sum.ToString();
                            con.Close();

                            mycon();
                            cmd = new SqlCommand("select party_name from tbl_party where _party_id=@pid", con);
                            cmd.Parameters.AddWithValue("@pid", textBox1.Text);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                textBox2.Text = dr[0].ToString();
                            }
                            con.Close();
                            cmd.Dispose();
                        }
                    }

                }
            }
        }
    }
}
