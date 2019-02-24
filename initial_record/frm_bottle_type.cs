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
    public partial class frm_bottle_type : Form
    {
        public frm_bottle_type()
        {
            InitializeComponent();
        }
        SqlConnection con;
       // SqlDataAdapter da;
        SqlCommand cmd;
      //  DataTable dt;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        private void frm_bottle_type_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gasbottleDataSet2.tbl_bottle_type' table. You can move, or remove it, as needed.
            this.tbl_bottle_typeTableAdapter.Fill(this.gasbottleDataSet2.tbl_bottle_type);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mycon();
            cmd = new SqlCommand("bottle_type", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bt_typ_id", 1);
            cmd.Parameters.AddWithValue("@btl_typ", textBox1.Text);
            cmd.ExecuteNonQuery();
        }
    }
}
