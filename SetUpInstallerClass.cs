using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;


namespace GasBottle_Application
{
    [RunInstaller(true)]
    public partial class SetUpInstallerClass : System.Configuration.Install.Installer
    {
        public SetUpInstallerClass()
        {
            InitializeComponent();
        }

        private void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
        static Int16 count = 0;
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {

            using (var formVal1 = new frm_code_generator())
            {
                var validationForm = formVal1.ShowDialog();

                while (validationForm == DialogResult.Retry)
                {
                    if (count < 3)
                    {
                        count++;

                    }
                    else
                    {
                        throw new Exception("Invalid Licence Keys. Please enter valid LicenceKey to Continue Installation");

                    }
                    validationForm = formVal1.ShowDialog();

                }
            }
            base.Install(stateSaver);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            string CurrentDirectory = this.Context.Parameters["targetdir"];
            GrantAccess(CurrentDirectory + "\\" + "App_Data");
            base.Commit(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

    }
}
