using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GasBottle_Application.company;
using GasBottle_Application.transaction;
using GasBottle_Application.initial_record;
using GasBottle_Application.acount_statement;
using DeppleSoftwareLib.ModifyRegistry;
using DeppleSoftwareLib.EnCryptDecrypt;
using DeppleSoftwareLib;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;

namespace GasBottle_Application
{
    public partial class frm_master : Form
    {
        private int childFormNumber = 0;

        public frm_master()
        {
            InitializeComponent();
            //pictureBox1.SendToBack();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void companyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form form in Application.OpenForms)
            //{
            //    if (form.GetType() == typeof(frm_company_information))
            //    {
            //        form.Activate();
            //        return;
            //    }
            //}
            frm_company_information fci = new frm_company_information();
            //fci.MdiParent = this;
            //fci.Activate();
            fci.ShowDialog();

        }

        private void initialRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_generate_sale))
                {
                    form.Activate();
                    return;
                }
            }
            frm_generate_sale sales = new frm_generate_sale();
            sales.MdiParent = this;
            sales.Activate();
            sales.BringToFront();
            sales.Show();
        }

        private void coustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_customer_list))
                {
                    form.Activate();
                    return;
                }
            }
            frm_customer_list fcl = new frm_customer_list();
            fcl.MdiParent = this;
            fcl.Show();
        }

        private void creatCoustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_creat_customer))
                {
                    form.Activate();
                    return;
                }
            }
            frm_creat_customer fcc = new frm_creat_customer("", "");
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void bottleStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_bottle_statement))
                {
                    form.Activate();
                    return;
                }
            }
            frm_bottle_statement fcc = new frm_bottle_statement();
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void coustomerStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_party_statement))
                {
                    form.Activate();
                    return;
                }
            }
            frm_party_statement fcc = new frm_party_statement();
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void bottleTypeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_bottle_type))
                {
                    form.Activate();
                    return;
                }
            }
            frm_bottle_type fcc = new frm_bottle_type();
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void financialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_financial_year))
                {
                    form.Activate();
                    return;
                }
            }
            frm_financial_year fcc = new frm_financial_year();
            fcc.MdiParent = this;
            fcc.Show();
        }

        //private void frm_master_Load(object sender, EventArgs e)
        //{

        //}
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        private string pid;
        void mycon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCON"].ToString());

            con.Open();
        }
        void noti()
        {
            mycon();
            cmd = new SqlCommand("select * from noti", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void frm_master_Load(object sender, EventArgs e)
        {
            noti();
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Depple",true);
            //string nnmm = key.GetValue("name").ToString();
            //if (key.GetValue("name").ToString() == "CMS")
            //{
            //    if (key.GetValue("days" ).ToString() == "1")
            //    {
            //        key.SetValue("regdate", System.DateTime.Now.ToString("dd/MM/yyyy"));
            //        key.SetValue("hardiskno", CryptorEngine.Encrypt(DeppleSoftwareLib.ValidationForm.Validation.getUniqueID("C"), true));
            //        key.SetValue("days", CryptorEngine.Encrypt("2", true));
            //    }
            //    else
            //    {
            //        string hdNo = CryptorEngine.Decrypt(key.GetValue("hardiskno").ToString(), true);
            //        if (hdNo == DeppleSoftwareLib.ValidationForm.Validation.getUniqueID("C"))
            //        {
            //            string d1 = CryptorEngine.Decrypt(key.GetValue("days").ToString(), true);
            //            if (Convert.ToInt32(d1) > 40)
            //            {
            //                MessageBox.Show("Cylinder Software Licence is Expire.  Please Contact Priyank Patel(9409544924).");
            //                Application.Exit();
            //            }
            //            else
            //            {
            //                int d2 = Convert.ToInt32(d1) + 1;
            //                key.SetValue("days", CryptorEngine.Encrypt(d2.ToString(), true));
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("This is Not Your Software. Please Contact Priyank Patel(9409544924).");
            //            Application.Exit();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("This is Not Your Software. Please Contact Priyank Patel(9409544924).");
            //    Application.Exit();
            //}

            ModifyRegistry mr = new ModifyRegistry();
            string nm = mr.Read("name");
            if (nm == "CMS")
            {
                if (mr.Read("days") == "1")
                {
                    mr.Write("regdate", System.DateTime.Now.ToString("dd/MM/yyyy"));
                    mr.Write("hardiskno", CryptorEngine.Encrypt(DeppleSoftwareLib.ValidationForm.Validation.getUniqueID("C"), true));
                    mr.Write("days", CryptorEngine.Encrypt("2", true));
                }
                else
                {
                    string hdNo = CryptorEngine.Decrypt(mr.Read("hardiskno"), true);
                    if (hdNo == DeppleSoftwareLib.ValidationForm.Validation.getUniqueID("C"))
                    {


                        string d1 = CryptorEngine.Decrypt(mr.Read("days"), true);

                        if (Convert.ToInt32(d1) > 500)
                        {
                            MessageBox.Show("Cylinder Software Licence is Expire.  Please Contact Priyank Patel(9409544924).");
                            Application.Exit();
                        }
                        else
                        {
                            int d2 = Convert.ToInt32(d1) + 1;
                            mr.Write("days", CryptorEngine.Encrypt(d2.ToString(), true));
                        }
                    }
                    else
                    {
                        MessageBox.Show("This is Not Your Software. Please Contact Priyank Patel(9409544924).");
                        Application.Exit();
                    }
                }
                //mr.Read("ACTIVE");
            }
            else
            {
                MessageBox.Show("This is Not Your Software. Please Contact Priyank Patel(9409544924).");
                Application.Exit();
            }
        }

        private void chalanStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_sales_detail))
                {
                    form.Activate();
                    return;
                }
            }
            frm_sales_detail fcc = new frm_sales_detail();
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void salesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_list_of_chalan))
                {
                    form.Activate();
                    return;
                }
            }
            frm_list_of_chalan fcc = new frm_list_of_chalan();
            fcc.MdiParent = this;
            fcc.Show();
        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(frm_party_month_wise))
                {
                    form.Activate();
                    return;
                }
            }
            frm_party_month_wise fcc = new frm_party_month_wise();
            fcc.MdiParent = this;
            fcc.Show();
        }
    }
}
