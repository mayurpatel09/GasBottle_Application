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
namespace GasBottle_Application.transaction
{
    public partial class frm_generate_sale : Form
    {
        public frm_generate_sale()
        {
            InitializeComponent();
            lblPartyId.Visible = false;
           
        }
        string actionform = "";
        public frm_generate_sale(string chalan_no)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            lblPartyId.Visible = false;
            this.chalan_no = chalan_no;
           // string action = "";
        }
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        private string chalan_no;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());
            con.Open();
        }
        public AutoCompleteStringCollection autocompleteload()
        {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            try
            {
                mycon();
                cmd = new SqlCommand("select_alltable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tblname", "tbl_bottle_type");
                cmd.Parameters.AddWithValue("@colname", "*");
                cmd.Parameters.AddWithValue("@id_col", "btl_typ_id");
                cmd.Parameters.AddWithValue("@id_col_val", 0);
                dr = cmd.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                    while (dr.Read())
                        str.Add(dr.GetValue(1).ToString());
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return str;
        }
        public AutoCompleteStringCollection forempty()
        {
            AutoCompleteStringCollection bottletype = new AutoCompleteStringCollection();
            try
            {

                mycon();
                cmd = new SqlCommand("SELECT DISTINCT type.btl_type FROM  tbl_bottle AS bottle INNER JOIN  tbl_bottle_type AS type ON bottle.btl_typ_id = type.btl_typ_id WHERE  (bottle.party_id = @pid) AND (bottle.btl_stts = '1')", con);
                cmd.Parameters.AddWithValue("@pid", lblPartyId.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bottletype.Add(dr[0].ToString());
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return bottletype;
        }

        public AutoCompleteStringCollection customerload()
        {
            AutoCompleteStringCollection cust = new AutoCompleteStringCollection();
            try
            {
                mycon();
                cmd = new SqlCommand("select_alltable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tblname", "tbl_party");
                cmd.Parameters.AddWithValue("@colname", "*");
                cmd.Parameters.AddWithValue("@id_col", "party_id");
                cmd.Parameters.AddWithValue("@id_col_val", 0);
                dr = cmd.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                    while (dr.Read())
                        cust.Add(dr[1].ToString());
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return cust;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox tbbx = e.Control as TextBox;
                if (tbbx != null)
                {
                    tbbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbbx.AutoCompleteCustomSource = autocompleteload();
                    tbbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }
        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 1)
            {
                TextBox tbbx = e.Control as TextBox;
                //tbbx.Enter += new EventHandler(tbbx_Enter);
                //if (tbbx != null)
                {
                    tbbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbbx.AutoCompleteCustomSource = autocompleteload();
                    tbbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }



        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int i;

                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) && !int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                }
                else
                {

                }
            }
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int i;

                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) && !int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;

                }
                else
                {

                }
            }
            if (e.ColumnIndex == 1)
            {
                int i;

                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()) && int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;

                }
                else
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            mycon();
            cmd = new SqlCommand("select sales_id from tbl_sales where chalan_no=@chln", con);
            cmd.Parameters.AddWithValue("@chln", textBox2.Text);
            da = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            con.Close();
            if (datatable.Rows.Count > 0 && textBox2.Enabled==true)
            {
                MessageBox.Show("chalan already exist please try with difernet chalan number");
                return;
            }
            else
            {
                //for (int i = 0; i < dataGridView1.Rows.Count ; i++)
                //{
                //    if (dataGridView1.Rows[i].Cells[1].Value == null || dataGridView1.Rows[i].Cells[2].Value == null)
                //    {
                //        MessageBox.Show("Please Fill All Full Bottel Entry");
                //        return;
                //        //break;

                //    }
                //}
                //for (int i = 0; i < dataGridView2.Rows.Count ; i++)
                //{
                //    if (dataGridView2.Rows[i].Cells[1].Value == null || dataGridView2.Rows[i].Cells[2].Value == null)
                //    {
                //        MessageBox.Show("Please Fill All Empty Bottel Entry");
                //        return;
                //        //break;
                //    }
                //}

                con.Open();
                //bind databse with datatable tbl_sales

                //cmd = new SqlCommand("sales", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@sid", 0);
                //cmd.Parameters.AddWithValue("@pid", lblPartyId.Text);
                //cmd.Parameters.AddWithValue("@chln_no", textBox2.Text);
                //cmd.Parameters.AddWithValue("@tot_qty", Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox4.Text));
                //cmd.Parameters.AddWithValue("@asin", 0);
                //cmd.Parameters.AddWithValue("@ret", 0);
                //cmd.Parameters.AddWithValue("@dat", dateTimePicker1.Text);
                //cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("select sales_id from tbl_sales where chalan_no=@chln", con);
                cmd.Parameters.AddWithValue("@chln", textBox2.Text);
                da = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                con.Close();

                con.Open();
                cmd = new SqlCommand("select * from tbl_bottle_type", con);
                da = new SqlDataAdapter(cmd);
                dt = new System.Data.DataTable();
                da.Fill(dt);
               // string abc;
                con.Close();

                ////for datagrid 1 fill TBL_SALES_DETAIL
                // for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                //{
                //    con.Open();
                //    cmd = new SqlCommand("sales_detail", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@sdid", 0);
                //    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                //    for (int j = 0; j < dt.Rows.Count; j++)
                //    {
                //        abc = dt.Rows[j][1].Equals(dataGridView1.Rows[i].Cells[1].Value).ToString();
                //        if (abc == "True")
                //        {
                //            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[j][0].ToString()));
                //            break;
                //        }
                //    }
                //    cmd.Parameters.AddWithValue("@qty", dataGridView1.Rows[i].Cells[2].Value);
                //    cmd.Parameters.AddWithValue("@ret", 0);
                //    cmd.Parameters.AddWithValue("@sls_typ", 1);
                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //}


                //////for data grid 2(empty_bottle) fill TBL_SALES_DETAIL
                //for (int k = 0; k < dataGridView2.RowCount - 1; k++)
                //{
                //    con.Open();
                //    cmd = new SqlCommand("sales_detail", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@sdid", 0);
                //    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                //    for (int l = 0; l < dt.Rows.Count; l++)
                //    {
                //        abc = dt.Rows[l][1].Equals(dataGridView2.Rows[k].Cells[1].Value).ToString();
                //        if (abc == "True")
                //        {
                //            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[l][0].ToString()));
                //            break;
                //        }
                //    }
                //    cmd.Parameters.AddWithValue("@qty", dataGridView2.Rows[k].Cells[2].Value);
                //    cmd.Parameters.AddWithValue("@ret", 0);
                //    cmd.Parameters.AddWithValue("@sls_typ", 0);
                //    cmd.ExecuteNonQuery();
                //   con.Close();
                //}
                DataTable fulll = new DataTable();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    fulll.Columns.Add(col.HeaderText);
                }
                DataRow drow = null;
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        drow = fulll.NewRow();
                        bool check = true;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null || cell.Value.ToString() == "")
                            {
                                check = false;
                            }
                            else
                            {
                                drow[cell.ColumnIndex] = cell.Value;
                            }
                        }
                        if (check == true)
                        {
                            fulll.Rows.Add(drow);
                        }
                    }
                }


                DataTable empty = new DataTable();
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    empty.Columns.Add(col.HeaderText);
                }
                DataRow drow1 = null;
                if (dataGridView2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool checkall = true;

                        drow1 = empty.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null || cell.Value.ToString() == "")
                            {
                                checkall = false;
                            }
                            else
                            {
                                drow1[cell.ColumnIndex] = cell.Value;
                            }
                            
                        }
                        if (checkall == true)
                        {
                            empty.Rows.Add(drow1);
                        }

                    }
                }


                string chalanNo = textBox2.Text;
                int totalbtl = Convert.ToInt32(Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox4.Text));
                // int sid = Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString());
                using (var asign = new frm_asignbottle(chalanNo, fulll, empty, lblPartyId.Text, dateTimePicker1.Text, totalbtl,actionform))
                {
                    var aForm = asign.ShowDialog();
                    if (aForm == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                    }
                }

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
                textBox3.Text = CellSum().ToString();

        }

        private double CellSum()
        {
            double sum = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                {
                    sum += Convert.ToInt32(r.Cells[2].Value);
                }
            }
            return sum;
        }
        private double CellSum2()
        {
            double sum = 0;
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                {
                    sum += Convert.ToInt32(r.Cells[2].Value);
                }
            }
            return sum;
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
                textBox4.Text = CellSum2().ToString();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = customerload();
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text != "")
            //{
            //    mycon();
            //    cmd = new SqlCommand("select party_id from tbl_party where party_name=@pn", con);
            //    cmd.Parameters.AddWithValue("@pn", textBox1.Text);
            //    dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        lblPartyId.Text = dr[0].ToString();
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var partyList = new frm_customer_list("GanarateSales"))
            {
                var partyForm = partyList.ShowDialog();
                if (partyList.DialogResult == DialogResult.OK)
                {
                    textBox1.Text = partyList.returnPartyName;
                    txtpartycode.Text = partyList.returnPartyId;
                    if (textBox1.Text != "")
                    {
                        mycon();
                        cmd = new SqlCommand("select party_id from tbl_party where _party_id=@pn", con);
                        cmd.Parameters.AddWithValue("@pn", partyList.returnPartyId);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            lblPartyId.Text = dr[0].ToString();
                        }
                        con.Close();
                    }

                }
            }
        }

        private void txtpartycode_Leave(object sender, EventArgs e)
        {
            if (txtpartycode.Text != "")
            {
                mycon();
                cmd = new SqlCommand("select * from tbl_party where _party_id=@pn", con);
                cmd.Parameters.AddWithValue("@pn", txtpartycode.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblPartyId.Text = dr[0].ToString();
                    textBox1.Text = dr["party_name"].ToString();
                }
                else
                {
                    lblPartyId.Text = "";
                    textBox1.Text = "";
                }
                con.Close();
            }
        }

        private void frm_generate_sale_Load(object sender, EventArgs e)
        {
            if (chalan_no!=null)

            {
                textBox3.Text = "0";
                textBox4.Text = "0";
                int em = 0, fl = 0;
                textBox2.Enabled = false;
                actionform = "update";
                mycon();
                cmd = new SqlCommand("SELECT * FROM tbl_sales_detail AS tds INNER JOIN getchalanstatement AS gc ON tds.sales_id = gc.sales_id INNER JOIN tbl_bottle_type AS tbs ON tds.bt_id = tbs.btl_typ_id WHERE (gc.chalan_no = @chno)", con);
                cmd.Parameters.AddWithValue("@chno", chalan_no);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                textBox2.Text = chalan_no;
                textBox1.Text = dt.Rows[0]["party_name"].ToString();
                txtpartycode.Text=dt.Rows[0]["_party_id"].ToString();
                textBox3.Text=dt.Rows[0]["totalFull"].ToString();
                if (dt.Rows[0]["totalEmpty"].ToString()!="")
                {
                    textBox4.Text = dt.Rows[0]["totalEmpty"].ToString();
                }
                else
                {
                    textBox4.Text = "0";
                }
                lblPartyId.Text=dt.Rows[0]["_party_id"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["sales_type"].ToString()== "0")
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[em].Cells[1].Value = dt.Rows[i]["btl_type"].ToString();
                        dataGridView2.Rows[em].Cells[2].Value = dt.Rows[i]["qty"].ToString();
                        em++;
                    }
                    else if (dt.Rows[i]["sales_type"].ToString()== "1")
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[fl].Cells[1].Value = dt.Rows[i]["btl_type"].ToString();
                        dataGridView1.Rows[fl].Cells[2].Value = dt.Rows[i]["qty"].ToString();
                        fl++;
                    }
                }
                con.Close();
            }
            else
            {
                actionform = "insert";
            }
        }


    }
}
