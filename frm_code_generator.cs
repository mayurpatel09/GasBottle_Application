using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace GasBottle_Application
{
    public partial class frm_code_generator : Form
    {
        public frm_code_generator()
        {
            InitializeComponent();
        }
        static Random generator = new Random();
        String r = generator.Next(100000, 999999).ToString();
        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void frm_code_generator_Load(object sender, EventArgs e)
        {
            Load:
            if (CheckForInternetConnection())
            {


                var fromAddress = new MailAddress("cksolutioninfo@gmail.com", "CylinderManagementSystem OTP");
                var toAddress = new MailAddress("depplesoft@gmail.com", "CylinderManagementSystem");
                const string fromPassword = "12345678@$$";
                const string subject = "Subject";
                string body = "Verification Code For Installing Sylinder Management System " + r;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    MessageBox.Show("Please Get Your Licence Kry From Priyank Patel (9409544924)");
                }
            }
            else
            {
                MessageBox.Show("Please Check your Internet Connection...");
                goto Load;
            }
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            if (txtC1.Text != "" && txtC2.Text != "" && txtC3.Text != "" && txtC4.Text != "" && txtC5.Text != "" && txtC6.Text != "")
            {
                if (txtC1.Text+txtC2.Text+txtC3.Text+txtC4.Text+txtC5.Text+txtC6.Text == r)
                {
                    MessageBox.Show("Youur Licence Of this Software is Updated");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Licence Key. Please enter valid Licence Key to continue installation", "Warnig Allert For Key", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    //IsValidPassword = false;
                    this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                }
            }
            else
            {
                MessageBox.Show("Please enter valid Licence Key to continue installation", "Warnig Allert For Key", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                //IsValidPassword = false;
                this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            }
        }

    }
}
