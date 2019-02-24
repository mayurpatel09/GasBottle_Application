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
    public partial class frm_show_bottle : Form
    {
        private string type;
        public frm_show_bottle()
        {
            InitializeComponent();

        }
        public frm_show_bottle(string type, string pid)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.type = type;
            this.pid = pid;
            label1.Text = type;
        }
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
       // SqlDataReader dr;
        private string pid;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        private void frm_show_bottle_Load(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("select bottle_number,_date, DATEDIFF(day, _date, GETDATE()) AS days from tbl_Bottle where btl_typ_id in (select btl_typ_id from tbl_bottle_type where btl_type=@btid) and btl_stts=1 and party_id in (select party_id from tbl_party where _party_id=@pid)", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@btid", type);  cmd.Parameters.AddWithValue("@today", System.DateTime.Now.ToString("yyyy/MM/dd"));
            da = new SqlDataAdapter(cmd);
            dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i <dt.Rows.Count ; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["days"].ToString()) >= 30)
                {
                    dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
            }
        }
    }
}
