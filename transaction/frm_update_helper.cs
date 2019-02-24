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
    public partial class frm_update_helper : Form
    {
        private string bottlenum;
        private string btl_type;
        private string chalannumber;

        public frm_update_helper()
        {
            InitializeComponent();
        }

        public frm_update_helper(string bottlenum, string btl_type, string chalannumber)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.bottlenum = bottlenum;
            this.btl_type = btl_type;
            this.chalannumber = chalannumber;
        }

        public frm_update_helper(string bottlenum, string btl_type, string chalannumber, string gridtype)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.bottlenum = bottlenum;
            this.btl_type = btl_type;
            this.chalannumber = chalannumber;
            this.gridtype = gridtype;
        }

        public frm_update_helper(string bottlenum, string btl_type, string chalannumber, string gridtype, string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.bottlenum = bottlenum;
            this.btl_type = btl_type;
            this.chalannumber = chalannumber;
            this.gridtype = gridtype;
            this.p = p;
        }

        public frm_update_helper(string bottlenum, string btl_type, string chalannumber, string gridtype, string p, string p_2)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.bottlenum = bottlenum;
            this.btl_type = btl_type;
            this.chalannumber = chalannumber;
            this.gridtype = gridtype;
            this.p = p;
            this.p_2 = p_2;
        }

        private void frm_update_helper_Load(object sender, EventArgs e)
        {

        }
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        private string gridtype;
        private string p;
        private string p_2;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mycon();
            if (gridtype == "fill" && textBox1.Text !="")
            {
                cmd = new SqlCommand("update tbl_bottle set btl_stts=0,party_id=0 where bottle_number=@btn", con);
                cmd.Parameters.AddWithValue("@btn", bottlenum);
                cmd.ExecuteNonQuery();


                tbl_bottle(textBox1.Text, btl_type, 1);

                cmd=new SqlCommand("Select be_id from tbl_bottle_entry where sales_id in (select sales_id from tbl_sales where chalan_no=@chno) and sales_type=1 and btl_typ_id in (select btl_typ_id from tbl_bottle_type where btl_type=@btp) and bottle_number=@bn ", con);
                cmd.Parameters.AddWithValue("@bn", bottlenum);
                cmd.Parameters.AddWithValue("@chno", chalannumber);
                cmd.Parameters.AddWithValue("@btp", btl_type);
                da = new SqlDataAdapter(cmd);
                DataTable beid = new DataTable();
                da.Fill(beid);

                cmd = new SqlCommand("update tbl_bottle_entry set bottle_number=@bn where be_id=@be_id", con);
                cmd.Parameters.AddWithValue("@bn", textBox1.Text);
                cmd.Parameters.AddWithValue("@be_id", beid.Rows[0][0].ToString());
                cmd.ExecuteNonQuery();
                this.Close();
            }
            else if (gridtype == "empty" && textBox1.Text!="")
            {
                cmd = new SqlCommand("update tbl_bottle set btl_stts=1,party_id=0 where bottl_number=@btn", con);
                cmd.Parameters.AddWithValue("@btn", bottlenum);
                cmd.ExecuteNonQuery();
            }
        }


        void tbl_bottle(string btl_num, string btt_id, byte stts)
        {
            mycon();
            //Int64 btlnum = Convert.ToInt64(btl_num);
            cmd = new SqlCommand("select * from tbl_bottle where btl_typ_id in (select btl_typ_id from tbl_bottle_type where btl_type=@btid) and bottle_number=@bn  ", con);
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

            cmd = new SqlCommand("select btl_typ_id from tbl_bottle_type where btl_type=@type", con);
            cmd.Parameters.AddWithValue("@type", btl_type);
            da = new SqlDataAdapter(cmd);
            DataTable btid = new DataTable();
            da.Fill(btid);

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
                cmd.Parameters.AddWithValue("@bt_typ_id", btid.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@bn", btl_num);
                cmd.Parameters.AddWithValue("@bt_st", stts);
                cmd.Parameters.AddWithValue("@pid", _partyid.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@dat",p_2);
                cmd.ExecuteNonQuery();

            }
            else
            {

                //insert
                cmd = new SqlCommand("bottle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bt_id", 0);
                cmd.Parameters.AddWithValue("@bt_typ_id", btid.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@bn", btl_num);
                cmd.Parameters.AddWithValue("@bt_st", stts);

                cmd.Parameters.AddWithValue("@pid", _partyid.Rows[0][0].ToString());


                cmd.Parameters.AddWithValue("@dat", p_2);

                cmd.ExecuteNonQuery();

            }

        }
    }
}
