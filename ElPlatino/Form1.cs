using System;
using System.Diagnostics;
using PlatinoPassoff;
using System.Windows.Forms;
using PlatinoUpdate;

namespace ElPlatino
{
    public partial class Form1 : Form
    {
        //TODO: insert custom font implementation here
        public Form1()
        {
            InitializeComponent();
            edVersionLabel.Text = "Local version not found!";
            PublicVars.labelstatus = "Click 'Check for updates' to check for updates.";
            statusLabel.Text = PublicVars.labelstatus;
            mainProgress.Visible = false;
            //TODO: insert server check here
            //TODO: Insert better local version checking here
            var versionInfo = FileVersionInfo.GetVersionInfo("mtndew.dll");
            string eldewritoProdVersion = versionInfo.ProductVersion; //creates string for eldewrito version, using the product version of mtndew
            string eldewritoFileVersion = versionInfo.FileVersion;
            if (eldewritoFileVersion != eldewritoProdVersion)
            {
                edVersionLabel.Text = "Error verifying ElDewrito version! Code 7";
            }
            else
            {
                edVersionLabel.Text = "Current Version: " + eldewritoProdVersion;
            }
            if ((mainProgress.Visible == false) && (PublicVars.labelstatus != "Program Uninitialized!") && (edVersionLabel.Text != "Error verifying ElDewrito version! Code 7")) //runs a check to see if program is actually initialized
            {
                PublicVars.initialized = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PublicVars.initialized == 1) //make sure the program is initialized before checking for updates
            {
                //TODO: insert connection to PlatinoUpdate here
                Application.Run(new PlatinoUpdate.Program());
                mainProgress.Visible = true;
                PublicVars.labelstatus = "Checking...";
                statusLabel.Text = PublicVars.labelstatus;
                mainProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                MessageBox.Show("Program is unitialized! Either the server is not responding or ElDewrito is missing.", "Error!");

            }
        }
    }
}
