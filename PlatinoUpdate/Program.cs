using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElPlatino;
using System.Xml;
using System.Windows.Forms;

namespace PlatinoUpdate
{
    class Program
    {
        private static string downloadUrl;
        private static Version newVersion;

        static void Main(string[] args)
        {
            string platinoURL = "";
            Version platinoVersion = null;
            string xmlUrl = "file://E:/JeBobs/Desktop/datedata.xml";
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name = "elplatino"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType = XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) &&(reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        downloadUrl = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.labelstatus = "Error in PlatinoUpdate!";
                Environment.Exit(1);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Version eldewritoVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if(eldewritoVersion.CompareTo(newVersion) < 0)
            {
                Form1.labelstatus = "Version " + newVersion.Major + "." + newVersion.Minor + "." + newVersion.Build + " found - updating game.";
                System.Diagnostics.Process.Start(downloadUrl);
            }
        }
    }
}
