﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPlatino
{
    public partial class Form1 : Form
    {
        public static string labelstatus = "Program Uninitialized!"; //default is uninitialized, user shouldn't see unless there's a problem
        public int initialized = 0;
        //TODO: insert custom font implementation here
        public Form1()
        {
            InitializeComponent();
            edVersionLabel.Text = "Local version not found!";
            labelstatus = "Click 'Check for updates' to check for updates.";
            statusLabel.Text = labelstatus;
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
            if ((mainProgress.Visible == false) && (labelstatus != "Program Uninitialized!") && (edVersionLabel.Text != "Error verifying ElDewrito version! Code 7")) //runs a check to see if program is actually initialized
            {
                initialized = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (initialized == 1) //make sure the program is initialized before checking for updates
            {
                //TODO: insert connection to PlatinoUpdate here
                mainProgress.Visible = true;
                labelstatus = "Checking...";
                statusLabel.Text = labelstatus;
                mainProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                MessageBox.Show("Program is unitialized! Either the server is not responding or ElDewrito is missing.", "Error!");

            }
        }
    }
}
