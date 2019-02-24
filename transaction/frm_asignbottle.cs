using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DeppleFunctionLib.DbConnecter;
using System.Configuration;
namespace GasBottle_Application.transaction
{
    public partial class frm_asignbottle : Form
    {
        public frm_asignbottle()
        {
            InitializeComponent();
        }
        string msg;
        string colName;


        public frm_asignbottle(string chalanNo, int sid, string p, string p_2)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.chalanNo = chalanNo;
            textBox1.Text = chalanNo;
            this.chalanNo = chalanNo;
            this.sid = sid;
            this.p = p;
            this.p_2 = p_2;
            comboBox1.SelectedIndex = 0;

        }

        public frm_asignbottle(string chalanNo, DataTable fulll, DataTable empty, string p, string p_2)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.chalanNo = chalanNo;
            textBox1.Text = chalanNo;
            this.fulll = fulll;
            this.empty = empty;
            this.p = p;
            this.p_2 = p_2;
            comboBox1.SelectedIndex = 0;
        }

        public frm_asignbottle(string chalanNo, DataTable fulll, DataTable empty, string p, string p_2, int totalbtl)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.chalanNo = chalanNo;
            textBox1.Text = chalanNo;
            this.fulll = fulll;
            this.empty = empty;
            this.p = p;
            this.p_2 = p_2;
            this.totalbtl = totalbtl;
            comboBox1.SelectedIndex = 0;

        }

        public frm_asignbottle(string chalanNo, DataTable fulll, DataTable empty, string p, string p_2, int totalbtl, string actionform)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.chalanNo = chalanNo;
            this.fulll = fulll;
            this.empty = empty;
            this.p = p;
            this.p_2 = p_2;
            this.totalbtl = totalbtl;
            this.actionform = actionform;
            comboBox1.SelectedIndex = 0;

        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr1;
        DataTable dt;
        private string chalanNo;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());
            con.Open();
        }
        DataTable datatable = new DataTable();
        DataTable emptytable = new DataTable();
        private int sid;
        private string p;
        private string p_2;
        private DataTable fulll;
        private DataTable empty;
        private int totalbtl;
        private string actionform;
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Full";
                //mycon();
                //cmd = new SqlCommand("SELECT    ts.sales_id, tsd.bt_id, tbt.btl_type, tsd.qty FROM   tbl_sales AS ts INNER JOIN  tbl_sales_detail AS tsd ON ts.sales_id = tsd.sales_id INNER JOIN  tbl_bottle_type AS tbt ON tsd.bt_id = tbt.btl_typ_id WHERE ts.chalan_no = @chln and tsd.sales_type=@sls_typ", con);
                //cmd.Parameters.AddWithValue("@chln", textBox1.Text);
                //cmd.Parameters.AddWithValue("@sls_typ", 1);


                //dr = null;
                int maxrowfull = 0;

                //dr = cmd.ExecuteReader();
                //if (datatable.Rows.Count <= 0)
                //{
                //    while (dr.Read())
                //    {
                //        datatable.Columns.Add(dr[2].ToString());
                //        if (maxrowfull < Convert.ToInt32(dr[3]))
                //        {
                //            maxrowfull = Convert.ToInt32(dr[3]);

                //        }
                //    }

                //    for (int j = 0; j < maxrowfull; j++)
                //    {
                //        DataRow dtrow = datatable.NewRow();
                //        datatable.Rows.Add(dtrow);
                //    }
                //}
                if (datatable.Columns.Count <= 0)
                {


                    for (int i = 0; i < fulll.Rows.Count; i++)
                    {
                        datatable.Columns.Add(fulll.Rows[i][1].ToString());
                        if (maxrowfull < Convert.ToInt32(fulll.Rows[i][2].ToString()))
                        {
                            maxrowfull = Convert.ToInt32(fulll.Rows[i][2].ToString());

                        }
                    }

                    for (int j = 0; j < maxrowfull; j++)
                    {
                        DataRow dtrow = datatable.NewRow();
                        datatable.Rows.Add(dtrow);
                    }
                }
                if (datatable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = datatable;
                    mycon();
                    cmd = new SqlCommand("select distinct * from loadasign where chalan_no=@chno and btl_stts=1", con);
                    cmd.Parameters.AddWithValue("@chno", chalanNo);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtasign = new DataTable();
                    da.Fill(dtasign);
                    con.Close();
                    int flag = 0;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        flag = 0;
                        for (int j = 0; j < dtasign.Rows.Count; j++)
                        {
                            if (dataGridView1.Columns[i].HeaderText.ToString() == dtasign.Rows[j][0].ToString())
                            {
                                dataGridView1.Rows[flag].Cells[i].Value = dtasign.Rows[j]["bottle_number"].ToString();
                                flag++;
                            }

                        }

                    }
                }
                else
                {
                    dataGridView1.DataSource = null;

                }


                //else
                //{
                //    MessageBox.Show("invalid_chalan_number! OR Select Empty");
                //}
                //con.Close();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //    mycon();
                //    cmd = new SqlCommand("SELECT    ts.sales_id, tsd.bt_id, tbt.btl_type, tsd.qty FROM   tbl_sales AS ts INNER JOIN  tbl_sales_detail AS tsd ON ts.sales_id = tsd.sales_id INNER JOIN  tbl_bottle_type AS tbt ON tsd.bt_id = tbt.btl_typ_id WHERE ts.chalan_no = @chln and tsd.sales_type=@sls_typ", con);
                //    cmd.Parameters.AddWithValue("@chln", textBox1.Text);
                //    cmd.Parameters.AddWithValue("@sls_typ", 0);
                int maxrowempty = 0;
                label1.Text = "Empty";
                //    dr1 = cmd.ExecuteReader();
                //    if (emptytable.Rows.Count <= 0)
                //    {
                //        while (dr1.Read())
                //        {
                //            emptytable.Columns.Add(dr1[2].ToString());
                //            if (maxrowempty < Convert.ToInt32(dr1[3]))
                //            {
                //                maxrowempty = Convert.ToInt32(dr1[3]);
                //            }
                //        }
                //        for (int k = 0; k < maxrowempty; k++)
                //        {
                //            DataRow dtrow1 = emptytable.NewRow();
                //            emptytable.Rows.Add(dtrow1);
                //        }
                //    }

                //    if (dr1.HasRows)
                //    {
                //        dataGridView1.DataSource = emptytable;
                //        con.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("invalid_chalan_number");
                //    }

                if (emptytable.Columns.Count <= 0)
                {


                    for (int k = 0; k < empty.Rows.Count; k++)
                    {
                        emptytable.Columns.Add(empty.Rows[k][1].ToString());
                        if (maxrowempty < Convert.ToInt32(empty.Rows[k][2].ToString()))
                        {
                            maxrowempty = Convert.ToInt32(empty.Rows[k][2].ToString());

                        }
                    }
                    for (int l = 0; l < maxrowempty; l++)
                    {
                        DataRow dtrow1 = emptytable.NewRow();
                        emptytable.Rows.Add(dtrow1);
                    }
                }
                if (emptytable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = emptytable;
                    mycon();
                    cmd = new SqlCommand("select distinct * from loadasign where chalan_no=@chno and btl_stts=0", con);
                    cmd.Parameters.AddWithValue("@chno", chalanNo);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtasignempy = new DataTable();
                    da.Fill(dtasignempy);
                    con.Close();
                    int flage = 0;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        flage = 0;
                        for (int j = 0; j < dtasignempy.Rows.Count; j++)
                        {
                            if (dataGridView1.Columns[i].HeaderText.ToString() == dtasignempy.Rows[j][0].ToString())
                            {
                                dataGridView1.Rows[flage].Cells[i].Value = dtasignempy.Rows[j]["bottle_number"].ToString();
                                flage++;
                            }

                        }

                    }

                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }

        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            mycon();

            cmd = new SqlCommand("SELECT    ts.sales_id, tsd.bt_id, tbt.btl_type FROM   tbl_sales AS ts INNER JOIN  tbl_sales_detail AS tsd ON ts.sales_id = tsd.sales_id INNER JOIN  tbl_bottle_type AS tbt ON tsd.bt_id = tbt.btl_typ_id WHERE ts.chalan_no = @chln and tsd.sales_type=@sls_typ", con);


            cmd.Parameters.AddWithValue("@sls_typ", 1);
            cmd.Parameters.AddWithValue("@chln", textBox1.Text);
            DataTable datatable = new DataTable();
            // da = new SqlDataAdapter(cmd);
            //da.Fill(datatable);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridView1.DataSource = datatable;
            }
            else
            {
                MessageBox.Show("invalid_chalan_number!");

            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 && actionform == "insert")
            {
                ///entry datatable from gridview
                datatable.Rows[e.RowIndex][e.ColumnIndex] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                msg = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string colName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (bottle_entry_check(msg, colName) == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    MessageBox.Show("this bottle  of " + colName + " " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is already asign to another party");
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    button1.Enabled = true;
                }
            }


            if (comboBox1.SelectedIndex == 0 && actionform == "update")
            {
                ///entry datatable from gridview
                datatable.Rows[e.RowIndex][e.ColumnIndex] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                msg = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string colName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (bottle_entry_check(msg, colName) == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    // MessageBox.Show("this bottle  of " + colName + " " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is already asign to another party");
                    button1.Enabled = true;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    button1.Enabled = true;
                }
            }






            else if (comboBox1.SelectedIndex == 1 && actionform == "insert")
            {
                emptytable.Rows[e.RowIndex][e.ColumnIndex] = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                msg = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                colName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (bottle_entry_check(msg, colName) != true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    MessageBox.Show("this bottle numer " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is asign to another party");
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    button1.Enabled = true;
                }
            }

        }

        public bool bottle_entry_check(string btl_numer, string colName)
        {
            mycon();
            cmd = new SqlCommand("SELECT bottle_number FROM  tbl_bottle WHERE btl_stts='1' and bottle_number=@bn and btl_typ_id IN (Select btl_typ_id from tbl_bottle_type Where btl_type=@bt)", con);
            // cmd = new SqlCommand("select * from tbl_bottle where btl_typ_id=@bt and bottle_number=@bn and btl_stts='1'", con);
            cmd.Parameters.AddWithValue("@bt", colName);
            cmd.Parameters.AddWithValue("@bn", btl_numer);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            string tru = "";
            for (int bec = 0; bec <= dt.Rows.Count - 1; bec++)
            {
                tru = dt.Rows[bec][0].Equals(btl_numer).ToString();
                if (tru == "True")
                {
                    break;
                }

            }
            if (tru == "True")
            {
                return true;

            }
            else
            {
                return false;
            }
            // con.Close();

        }

        void tbl_bottle(string btl_num, string btt_id, byte stts)
        {
            mycon();
            //Int64 btlnum = Convert.ToInt64(btl_num);
            cmd = new SqlCommand("select * from tbl_bottle where btl_typ_id=@btid and bottle_number=@bn  ", con);
            cmd.Parameters.AddWithValue("@btid", btt_id);
            cmd.Parameters.AddWithValue("@bn", btl_num);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

              cmd = new SqlCommand("select party_id from tbl_party where _party_id=@_pid", con);
              cmd.Parameters.AddWithValue("@_pid", p);
              da = new SqlDataAdapter(cmd);
              DataTable _partyid = new DataTable();
              da.Fill(_partyid);

            string truth = "";
            if (dt.Rows.Count > 0)
            {
                truth = dt.Rows[0][2].Equals(btl_num).ToString();

            }
            if (truth == "True")
            {
                //update
                cmd = new SqlCommand("bottle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bt_id", dt.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@bt_typ_id", btt_id);
                cmd.Parameters.AddWithValue("@bn", btl_num);
                cmd.Parameters.AddWithValue("@bt_st", stts);
                if (actionform=="insert")
                {
                cmd.Parameters.AddWithValue("@pid", p);
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@pid", _partyid.Rows[0][0].ToString());

                }
                cmd.Parameters.AddWithValue("@dat", p_2);

                cmd.ExecuteNonQuery();

            }
            else
            {
              
                //insert
                cmd = new SqlCommand("bottle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bt_id", 0);
                cmd.Parameters.AddWithValue("@bt_typ_id", btt_id);
                cmd.Parameters.AddWithValue("@bn", btl_num);
                cmd.Parameters.AddWithValue("@bt_st", stts);
                if (actionform == "insert")
                {
                    cmd.Parameters.AddWithValue("@pid", p);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@pid", _partyid.Rows[0][0].ToString());

                }
                cmd.Parameters.AddWithValue("@dat", p_2);

                cmd.ExecuteNonQuery();

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (actionform == "insert")
            {


                // bind databse with datatable tbl_sales
                mycon();
                cmd = new SqlCommand("sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", 0);
                cmd.Parameters.AddWithValue("@pid", p);
                cmd.Parameters.AddWithValue("@chln_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@tot_qty", totalbtl);
                cmd.Parameters.AddWithValue("@asin", 0);
                cmd.Parameters.AddWithValue("@ret", 0);
                cmd.Parameters.AddWithValue("@dat", p_2);
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                cmd = new SqlCommand("select sales_id from tbl_sales where chalan_no=@chln", con);
                cmd.Parameters.AddWithValue("@chln", textBox1.Text);
                da = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                con.Close();

                con.Open();
                cmd = new SqlCommand("select * from tbl_bottle_type", con);
                da = new SqlDataAdapter(cmd);
                dt = new System.Data.DataTable();
                da.Fill(dt);
                string abc;
                con.Close();

                ////for datagrid 1 fill TBL_SALES_DETAIL
                for (int i = 0; i < fulll.Rows.Count; i++)
                {
                    con.Open();
                    cmd = new SqlCommand("sales_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sdid", 0);
                    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        abc = dt.Rows[j][1].ToString().Equals(fulll.Rows[i][1].ToString()).ToString();
                        if (abc == "True")
                        {
                            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[j][0].ToString()));
                            break;
                        }
                    }
                    cmd.Parameters.AddWithValue("@qty", fulll.Rows[i][2].ToString());
                    cmd.Parameters.AddWithValue("@ret", 0);
                    cmd.Parameters.AddWithValue("@sls_typ", 1);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }


                //////for data grid 2(empty_bottle) fill TBL_SALES_DETAIL
                for (int k = 0; k < empty.Rows.Count; k++)
                {
                    con.Open();
                    cmd = new SqlCommand("sales_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sdid", 0);
                    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        abc = dt.Rows[l][1].Equals(empty.Rows[k][1]).ToString();
                        if (abc == "True")
                        {
                            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[l][0].ToString()));
                            break;
                        }
                    }
                    cmd.Parameters.AddWithValue("@qty", empty.Rows[k][2].ToString());
                    cmd.Parameters.AddWithValue("@ret", 0);
                    cmd.Parameters.AddWithValue("@sls_typ", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                mycon();
                DataTable dt3;
                cmd = new SqlCommand("select * from tbl_bottle_type", con);
                da = new SqlDataAdapter(cmd);
                dt3 = new DataTable();
                da.Fill(dt3);
                string var1;
                string var2;
                int one = 0;
                int two = 0;
                string btt_id = "";
                string btl_num;
                if (datatable.Rows.Count > 0)
                {
                    for (int a = 0; a < datatable.Columns.Count; a++)
                    {
                        for (int b = 0; b < datatable.Rows.Count; b++)
                        {
                            if (datatable.Rows[b][a].ToString() != "")
                            {
                                cmd = new SqlCommand("bottle_entry", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@btl_e_id", 0);
                                cmd.Parameters.AddWithValue("@s_id", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                                for (int l = 0; l <= dt3.Rows.Count - 1; l++)
                                {
                                    var1 = dt3.Rows[l][1].ToString();
                                    var2 = datatable.Columns[a].ToString();
                                    if (var1 == var2)
                                    {
                                        cmd.Parameters.AddWithValue("@bt_id", Convert.ToInt32(dt3.Rows[l][0].ToString()));
                                        btt_id = dt3.Rows[l][0].ToString();
                                        break;
                                    }
                                }
                                cmd.Parameters.AddWithValue("@btl_num", datatable.Rows[b][a].ToString());
                                btl_num = datatable.Rows[b][a].ToString();
                                cmd.Parameters.AddWithValue("@sales_typ", 1);
                                one = cmd.ExecuteNonQuery();
                                tbl_bottle(btl_num, btt_id, 1);
                            }
                        }

                    }

                }
                if (emptytable.Rows.Count > 0)
                {
                    for (int a = 0; a < emptytable.Columns.Count; a++)
                    {
                        for (int b = 0; b < emptytable.Rows.Count; b++)
                        {
                            if (emptytable.Rows[b][a].ToString() != "")
                            {
                                cmd = new SqlCommand("bottle_entry", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@btl_e_id", 0);
                                cmd.Parameters.AddWithValue("@s_id", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                                for (int l = 0; l <= dt3.Rows.Count - 1; l++)
                                {
                                    var1 = dt3.Rows[l][1].ToString();
                                    var2 = emptytable.Columns[a].ToString();
                                    if (var1 == var2)
                                    {
                                        cmd.Parameters.AddWithValue("@bt_id", Convert.ToInt32(dt3.Rows[l][0].ToString()));
                                        btt_id = dt3.Rows[l][0].ToString();
                                        break;
                                    }
                                }
                                cmd.Parameters.AddWithValue("@btl_num", emptytable.Rows[b][a].ToString());
                                btl_num = emptytable.Rows[b][a].ToString();
                                cmd.Parameters.AddWithValue("@sales_typ", 0);
                                two = cmd.ExecuteNonQuery();
                                tbl_bottle(btl_num, btt_id, 0);
                            }
                        }
                    }
                }
                if (one == 1 || two == 1)
                {
                    MessageBox.Show("Bottle Assign To Chalan no : " + chalanNo + " is Complete");
                    dataGridView1.DataSource = null;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }


            }
            else
            {
                //update
                // bind databse with datatable tbl_sales
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand("select party_id from tbl_party where _party_id=@_pid", con);
                cmd.Parameters.AddWithValue("@_pid", p);
                da = new SqlDataAdapter(cmd);
                DataTable partyid = new DataTable();
                da.Fill(partyid);

                cmd = new SqlCommand("select sales_id from tbl_sales where chalan_no=@chln", con);
                cmd.Parameters.AddWithValue("@chln", textBox1.Text);
                da = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                con.Close();

                mycon();
                cmd = new SqlCommand("sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", dt1.Rows[0]["sales_id"].ToString());
                cmd.Parameters.AddWithValue("@pid", partyid.Rows[0]["party_id"].ToString());
                cmd.Parameters.AddWithValue("@chln_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@tot_qty", totalbtl);
                cmd.Parameters.AddWithValue("@asin", 0);
                cmd.Parameters.AddWithValue("@ret", 0);
                cmd.Parameters.AddWithValue("@dat", p_2);
                cmd.ExecuteNonQuery();
                con.Close();



                con.Open();
                cmd = new SqlCommand("select * from tbl_bottle_type", con);
                da = new SqlDataAdapter(cmd);
                dt = new System.Data.DataTable();
                da.Fill(dt);
                string abc;
                con.Close();

                con.Open();
                cmd = new SqlCommand("select sales_id from tbl_sales_detail where sales_id=@sales_id", con);
                cmd.Parameters.AddWithValue("@sales_id", dt1.Rows[0]["sales_id"].ToString());
                da = new SqlDataAdapter(cmd);
                DataTable salesidfrodetail = new DataTable();
                da.Fill(salesidfrodetail);
                con.Close();

                ////for datagrid 1 fill TBL_SALES_DETAIL
                for (int i = 0; i < fulll.Rows.Count; i++)
                {
                    con.Open();
                    cmd = new SqlCommand("sales_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sdid", salesidfrodetail.Rows[0][0].ToString());
                    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        abc = dt.Rows[j][1].ToString().Equals(fulll.Rows[i][1].ToString()).ToString();
                        if (abc == "True")
                        {
                            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[j][0].ToString()));
                            break;
                        }
                    }
                    cmd.Parameters.AddWithValue("@qty", fulll.Rows[i][2].ToString());
                    cmd.Parameters.AddWithValue("@ret", 0);
                    cmd.Parameters.AddWithValue("@sls_typ", 1);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



                //////for data grid 2(empty_bottle) fill TBL_SALES_DETAIL
                for (int k = 0; k < empty.Rows.Count; k++)
                {
                    con.Open();
                    cmd = new SqlCommand("sales_detail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sdid", salesidfrodetail.Rows[0][0].ToString());
                    cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        abc = dt.Rows[l][1].Equals(empty.Rows[k][1]).ToString();
                        if (abc == "True")
                        {
                            cmd.Parameters.AddWithValue("@btid", Convert.ToInt32(dt.Rows[l][0].ToString()));
                            break;
                        }
                    }
                    cmd.Parameters.AddWithValue("@qty", empty.Rows[k][2].ToString());
                    cmd.Parameters.AddWithValue("@ret", 0);
                    cmd.Parameters.AddWithValue("@sls_typ", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                mycon();
                DataTable dt3;
                cmd = new SqlCommand("select * from tbl_bottle_type", con);
                da = new SqlDataAdapter(cmd);
                dt3 = new DataTable();
                da.Fill(dt3);

                cmd = new SqlCommand("select be_id from tbl_bottle_entry where sales_id=@sales_id", con);
                cmd.Parameters.AddWithValue("@sales_id", salesidfrodetail.Rows[0][0].ToString());
                da = new SqlDataAdapter(cmd);
                DataTable beid = new DataTable();
                da.Fill(beid);

                string var1;
                string var2;
                int one = 0;
                int two = 0;
                string btt_id = "";
                string btl_num;
                if (datatable.Rows.Count > 0)
                {
                    for (int a = 0; a < datatable.Columns.Count; a++)
                    {
                        for (int b = 0; b < datatable.Rows.Count; b++)
                        {
                            if (datatable.Rows[b][a].ToString() != "")
                            {
                                cmd = new SqlCommand("bottle_entry", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@btl_e_id", beid.Rows[0][0].ToString());
                                cmd.Parameters.AddWithValue("@s_id", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                                for (int l = 0; l <= dt3.Rows.Count - 1; l++)
                                {
                                    var1 = dt3.Rows[l][1].ToString();
                                    var2 = datatable.Columns[a].ToString();
                                    if (var1 == var2)
                                    {
                                        cmd.Parameters.AddWithValue("@bt_id", Convert.ToInt32(dt3.Rows[l][0].ToString()));
                                        btt_id = dt3.Rows[l][0].ToString();
                                        break;
                                    }
                                }
                                cmd.Parameters.AddWithValue("@btl_num", datatable.Rows[b][a].ToString());
                                btl_num = datatable.Rows[b][a].ToString();
                                cmd.Parameters.AddWithValue("@sales_typ", 1);
                                one = cmd.ExecuteNonQuery();
                                tbl_bottle(btl_num, btt_id, 1);
                            }
                        }

                    }

                }
                if (emptytable.Rows.Count > 0)
                {
                    for (int a = 0; a < emptytable.Columns.Count; a++)
                    {
                        for (int b = 0; b < emptytable.Rows.Count; b++)
                        {
                            if (emptytable.Rows[b][a].ToString() != "")
                            {
                                cmd = new SqlCommand("bottle_entry", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@btl_e_id", beid.Rows[0][0].ToString());
                                cmd.Parameters.AddWithValue("@s_id", Convert.ToInt32(dt1.Rows[0]["sales_id"].ToString()));
                                for (int l = 0; l <= dt3.Rows.Count - 1; l++)
                                {
                                    var1 = dt3.Rows[l][1].ToString();
                                    var2 = emptytable.Columns[a].ToString();
                                    if (var1 == var2)
                                    {
                                        cmd.Parameters.AddWithValue("@bt_id", Convert.ToInt32(dt3.Rows[l][0].ToString()));
                                        btt_id = dt3.Rows[l][0].ToString();
                                        break;
                                    }
                                }
                                cmd.Parameters.AddWithValue("@btl_num", emptytable.Rows[b][a].ToString());
                                btl_num = emptytable.Rows[b][a].ToString();
                                cmd.Parameters.AddWithValue("@sales_typ", 0);
                                two = cmd.ExecuteNonQuery();
                                tbl_bottle(btl_num, btt_id, 0);
                            }
                        }
                    }
                }
                if (one == 1 || two == 1)
                {
                    MessageBox.Show("Chalan update Completed...!!!");
                    dataGridView1.DataSource = null;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
        }
        public AutoCompleteStringCollection asigntofull()
        {
            AutoCompleteStringCollection emptybottle = new AutoCompleteStringCollection();
            try
            {
                mycon();
                cmd = new SqlCommand("select * from tbl_bottle where btl_stts='1' and party_id=@pid ", con);
                cmd.Parameters.AddWithValue("@pid", p);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emptybottle.Add(dr[2].ToString());
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return emptybottle;
        }
        public AutoCompleteStringCollection asigntoempty()
        {
            AutoCompleteStringCollection fullbottle = new AutoCompleteStringCollection();
            try
            {
                mycon();
                cmd = new SqlCommand("select * from tbl_bottle where btl_stts='1' and party_id=@pid ", con);
                cmd.Parameters.AddWithValue("@pid", p);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fullbottle.Add(dr[2].ToString());
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return fullbottle;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Empty")
            {
                TextBox tbb = e.Control as TextBox;
                if (tbb != null)
                {
                    tbb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbb.AutoCompleteCustomSource = asigntoempty();
                    tbb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }

        private void frm_asignbottle_Load(object sender, EventArgs e)
        {
            if (actionform=="update")
            {
                dataGridView1.ReadOnly = true;
            }
            //if (comboBox1.SelectedIndex == 0)
            //{
            //    mycon();
            //    cmd = new SqlCommand("select distinct * from loadasign where chalan_no=@chno and btl_stts=0", con);
            //    cmd.Parameters.AddWithValue("@chno", chalanNo);
            //    da = new SqlDataAdapter(cmd);
            //    dt = new DataTable();
            //    da.Fill(dt);
            //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //    {
            //        for (int j = 0; i < dt.Rows.Count; j++)
            //        {
            //            if (dataGridView1.Columns[i].ToString() == dt.Rows[i][0].ToString())
            //            {
            //                dataGridView1.Rows[j].Cells[i].Value = dt.Rows[j][i].ToString();
            //            }

            //        }
            //        con.Close();
            //    }
                textBox1.Text = chalanNo;
                this.ActiveControl = dataGridView1;
            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (actionform=="update")
            {
                string bottlenum = dataGridView1.CurrentCell.Value.ToString();
                string btl_type = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
                string chalannumber = chalanNo;
                string gridtype = "";
                if (comboBox1.SelectedIndex==0)
                {
                    gridtype = "fill";
                }
                else if (comboBox1.SelectedIndex==1)
                {
                    gridtype = "empty";

                }
                frm_update_helper fuh = new frm_update_helper(bottlenum, btl_type, chalannumber,gridtype,p,p_2);
                fuh.Show();
            }
        }

        }
    }
