using ExcelToRazl.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Xml.Linq;

namespace ExcelToRazl
{
    public partial class Main : Form
    {
        private string _fileNameExcel = string.Empty;
        private string _folderNameRazl = string.Empty;
        private string _fileNameRazl = string.Empty;
        private string _razlInstallationLocation = string.Empty;
        private bool _hasRazl = false;
        private string _razlVersion = "3.0.4.0";
        private string _sitecoreUrl = string.Empty;
        private bool _hasConnectionsInDdl = false;

        public Main()
        {
            List<Connection> Connections = new List<Connection>();

            InitializeComponent();
            GetRazlData();
            // Get installation location of Razl and set _hasRazl variable
            _hasRazl = !string.IsNullOrWhiteSpace(_razlInstallationLocation);

            if (_hasRazl)
            {
                // Retrieve the Razl user config file to be able to read the existing connections
                var razlUserConfigPath = LocateRazlUserConfig();

                // Get a list of connections from the Razl user config
                Connections = GetConnections(razlUserConfigPath);

                // Check if there are connections to show in the comboboxes
                _hasConnectionsInDdl = Connections.Any();

                // If so, set datasources of the comboboxes
                if(_hasConnectionsInDdl)
                {
                    BindRazlConnections(cmbRazlSource, GetConnections(razlUserConfigPath));
                    BindRazlConnections(cmbRazlTarget, GetConnections(razlUserConfigPath));
                }
            }

            // Hide or show the textfields or comboboxes
            txtRazlSource.Visible = !_hasConnectionsInDdl;
            txtRazlTarget.Visible = !_hasConnectionsInDdl;
            cmbRazlSource.Visible = _hasConnectionsInDdl;
            cmbRazlTarget.Visible = _hasConnectionsInDdl;

            // Set filters on file selection dialogs
            ofdExcel.Filter = "Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            ofdRazlScript.Filter = "XML (*.xml)|*.xml";

            // Hide or show the elements in the Run Script section
            btnSelectRazlScript.Enabled = _hasRazl;
            btnRunRazlScript.Enabled = _hasRazl;

            // Show message if no Razl installation could be found
            if(!_hasRazl)
            {
                MessageBox.Show("Razl is not installed on this system. Running a Razl script from this tool won't be possible.", "No Razl", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Binds a list of connections to a combobox
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="connections"></param>
        private void BindRazlConnections(ComboBox comboBox, List<Connection> connections)
        {
            comboBox.DataSource = connections;
            comboBox.DisplayMember = "Name";
        }

        /// <summary>
        /// Gets a list of connections from a HedgeHog Razl user.config file
        /// </summary>
        /// <param name="razlUserConfigPath"></param>
        /// <returns>List of connections</returns>
        private List<Connection> GetConnections(string razlUserConfigPath)
        {
            List<Connection> sitecoreConnections = new List<Connection>();

            // If the razlUserConfigPath is not set, return an empty list
            if (!string.IsNullOrWhiteSpace(razlUserConfigPath))
            {
                // Read XML from user.config
                var doc = XDocument.Load(razlUserConfigPath);

                if (doc != null)
                {
                    // Find all elements named SitecoreConnection
                    var connections = doc.Descendants("SitecoreConnection");

                    // Convert each SitecoreConnection element into a Connection object
                    foreach (var c in connections)
                    {
                        XElement xElementName = c.Element("Name");
                        XElement xElementUrl = c.Element("Url");

                        if (xElementName != null && xElementUrl != null)
                        {
                            Connection con = new Connection()
                            {
                                Name = xElementName.Value,
                                Preset = xElementName.Value,
                                Url = xElementUrl.Value
                            };

                            // Add connection object to list to return
                            sitecoreConnections.Add(con);
                        }
                    }
                }
            }

            return sitecoreConnections;
        }

        /// <summary>
        /// Gets the Razl Display version and Installation Folder
        /// </summary>
        private void GetRazlData()
        {
            // Find installation location of Hedgehog Razl
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {

                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        var subKeyNameValue = subkey.GetValue("DisplayName");

                        if (subKeyNameValue != null)
                        {
                            if (!string.IsNullOrWhiteSpace(subKeyNameValue.ToString()) && subKeyNameValue.ToString().Contains("Razl"))
                            {
                                _razlVersion = subkey.GetValue("DisplayVersion") != null ? string.Concat(subkey.GetValue("DisplayVersion").ToString(), ".0") : string.Empty;
                                _razlInstallationLocation =  subkey.GetValue("InstallLocation") != null ? subkey.GetValue("InstallLocation").ToString() : string.Empty;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Locates the Hedegehog Razl user.config file
        /// </summary>
        /// <returns>Path to the Razl user.config file</returns>
        private string LocateRazlUserConfig()
        {
            if (string.IsNullOrWhiteSpace(_razlVersion))
                return string.Empty;

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                var combined = Path.Combine(folderPath, "Hedgehog_Development");
                var directories = Directory.GetDirectories(combined, "Razl.Exe_*");

                foreach (var d in directories)
                {
                    string razlUserConfigPath = Path.Combine(d, _razlVersion);
                    if (Directory.Exists(razlUserConfigPath))
                    {
                        return Path.Combine(razlUserConfigPath, "user.config");
                    }
                }
            }

            return string.Empty;
        }

        private void btnOpenExcelDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdExcel.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtExcelPath.Text = ofdExcel.FileName;
                _fileNameExcel = ofdExcel.FileName;
            }
        }

        private void btnSelectRazlScript_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRazlScriptPath.Text))
            {
                ofdRazlScript.FileName = txtRazlScriptPath.Text;
            }

            DialogResult result = ofdRazlScript.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtRazlScriptPath.Text = ofdRazlScript.FileName;
            }
        }

        private void btnChooseRazlScriptFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdRazlScriptFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtRazlScriptFolder.Text = fbdRazlScriptFolder.SelectedPath;
                _folderNameRazl = fbdRazlScriptFolder.SelectedPath;
            }
        }

        private bool ColumnExists(OleDbDataReader reader, string columnName)
        {
            for(int i = 0; i < reader.FieldCount; i++)
            {
                if(reader.GetName(i) == columnName)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnGenerateRazlScript_Click(object sender, EventArgs e)
        {
            // Check if all required data is selected/set
            if(string.IsNullOrWhiteSpace(_fileNameExcel))
            {
                MessageBox.Show("No Excel file selected!", "No Excel file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrWhiteSpace(_folderNameRazl))
            {
                MessageBox.Show("No Razl script output folder is set!", "No output folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrWhiteSpace(txtRazlSource.Text) && cmbRazlSource.SelectedValue == null)
            {
                MessageBox.Show("No Razl source connection is set. Please set the source connection!", "No source connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrWhiteSpace(txtRazlTarget.Text) && cmbRazlTarget.SelectedValue == null)
            {
                MessageBox.Show("No Razl target connection is set. Please set the target connection!", "No target connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSitecoreUrl.Text))
            {
                MessageBox.Show("No Sitecore url is set. Please input the url to your Sitecore instance!", "No Sitecore url", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSitecoreLogin.Text))
            {
                MessageBox.Show("No Sitecore source login is set. Please provide the login name to your Sitecore source instance!", "No Sitecore source login name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSitecorePassword.Text))
            {
                MessageBox.Show("No Sitecore source password is set. Please provide the password to your Sitecore source instance!", "No Sitecore source password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            prbProgress.Maximum = 100;
            prbProgress.Value = 10;

            string strFileType = Path.GetExtension(_fileNameExcel.ToLower());
            string connString = string.Empty;
            string _razlSource = _hasConnectionsInDdl ? ((Connection)cmbRazlSource.SelectedValue).Name : txtRazlSource.Text;
            string _razlTargetName = _hasConnectionsInDdl ? ((Connection)cmbRazlTarget.SelectedValue).Name : txtRazlTarget.Text;
            string _sitecoreUrl = txtSitecoreUrl.Text;

            List<Connection> ConnectionsToScript = new List<Connection>();

            ConnectionsToScript.Add(new Connection { Name = _razlSource, Preset = _razlSource });
            ConnectionsToScript.Add(new Connection { Name = _razlTargetName, Preset = _razlTargetName });

            // Setup OLEDB Connection string to read Excel
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _fileNameExcel + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _fileNameExcel + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            List<Command> operations = new List<Command>();

            if (!_sitecoreUrl.EndsWith("/"))
                _sitecoreUrl += "/";

            prbProgress.Value = 20;

            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();

                // Get first sheet of Excel
                var ExcelTables = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
                var sheet = ExcelTables.Rows[0].Field<string>("TABLE_NAME");

                // Create a reader which reads from the first sheet of the Excel
                OleDbCommand command = new OleDbCommand(string.Format("select * from [{0}]", sheet), connection);
                OleDbDataReader reader = command.ExecuteReader();

                // Check which columns exist
                bool hasType = this.ColumnExists(reader, "Type");
                bool hasItemPath = this.ColumnExists(reader, "ItemPath");
                bool hasItemId = this.ColumnExists(reader, "ItemId");
                bool hasOverwrite = this.ColumnExists(reader, "Overwrite");

                int rowCount = 2; // Start counting at row 2, because the first row contain the headers
                List<Error> errors = new List<Error>();

                // Read each record from the excel
                while(reader.Read())
                {
                    Command c = new Command();

                    // Set command type
                    if (hasType)
                    {
                        switch (reader["Type"].ToString())
                        {
                            case "CopyAll":
                                c.Type = Models.CommandType.CopyAll;
                                break;
                            case "CopyItem":
                                c.Type = Models.CommandType.CopyItem;
                                break;
                            default:
                                c.Type = Models.CommandType.Unknown;
                                errors.Add(new Error { RowNumber = rowCount, Field = "Type", Message = "Entered type is not supported" });
                                break;
                        }
                    }
                    else
                    {
                        c.Type = Models.CommandType.Unknown;
                        errors.Add(new Error { RowNumber = rowCount, Field = "Type", Message = "No 'Type' column available in Excel file" });
                    }

                    // Set item item id
                    if (hasItemId)
                    {
                        if (reader["ItemId"] != null)
                        {
                            Guid guid = new Guid();
                            if (Guid.TryParse(reader["ItemId"].ToString(), out guid))
                            {
                                c.ItemId = guid;
                            }
                            else
                            {
                                errors.Add(new Error { RowNumber = rowCount, Field = "ItemId", Message = "ItemId doesn't contain a valid GUID." });
                                c.Type = Models.CommandType.Unknown;
                            }
                        }
                    }
                    else if (hasItemPath)
                    {
                        if (reader["ItemPath"] != null)
                        {
                            // If item path is set, retrieve the item id's from the Sitecore instance using the Sitecore Services Client API
                            try
                            {
                                var guid = new Guid();
                                var itemPath = reader["ItemPath"].ToString();

                                if (!itemPath.StartsWith("/"))
                                    itemPath.Insert(0, "/");

                                if (itemPath.EndsWith("/"))
                                    itemPath.TrimEnd('/');

                                // Use Sitecore Service Client (Sitecore 7.5+)
                                if (ddlSitecoreVersion.SelectedIndex == 1)
                                {
                                    // Create webrequest and response
                                    var queryUrl = string.Format("{0}sitecore/api/ssc/item/?path={1}&database=master", _sitecoreUrl, itemPath);

                                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryUrl);
                                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                                    if (response == null)
                                    {
                                        errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = "Item at given item path could not be retrieved!" });
                                        c.Type = Models.CommandType.Unknown;
                                    }

                                    // Deserialize response to get and set the item id
                                    using (var responseReader = new StreamReader(response.GetResponseStream()))
                                    {
                                        JavaScriptSerializer js = new JavaScriptSerializer();
                                        var objText = responseReader.ReadToEnd();
                                        Item item = (Item)js.Deserialize(objText, typeof(Item));

                                        if (Guid.TryParse(item.ItemID, out guid))
                                        {
                                            c.ItemId = guid;
                                        }
                                    }
                                }
                                // Use Sitecore Item Web API (sitecore 7.2-)
                                else if(ddlSitecoreVersion.SelectedIndex == 0)
                                {
                                    // Create webrequest and response
                                    var queryUrl = string.Format("{0}-/item/v1{1}?sc_database=master", _sitecoreUrl, itemPath);
                                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryUrl);

                                    // Set credentials to login into Sitecore
                                    request.Headers["X-Scitemwebapi-Username"] = txtSitecoreLogin.Text;
                                    request.Headers["X-Scitemwebapi-Password"] = txtSitecorePassword.Text;

                                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                                    // Deserialize response to get and set the item id
                                    using (var responseReader = new StreamReader(response.GetResponseStream()))
                                    {
                                        JavaScriptSerializer js = new JavaScriptSerializer();
                                        var objText = responseReader.ReadToEnd();
                                        ItemWebApiResult result = (ItemWebApiResult)js.Deserialize(objText, typeof(ItemWebApiResult));

                                        if (result == null)
                                        {
                                            errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = "Could not retrieve ItemId by ItemPath from Sitecore. Either the setup for the Sitecore source instance are wrong or the item doesn't exist." });
                                            c.Type = Models.CommandType.Unknown;
                                        }
                                        else if(result.statusCode != 200)
                                        {
                                            errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = "Could not retrieve ItemId by ItemPath from Sitecore." +Environment.NewLine+ "Status code from server: " + result.statusCode + Environment.NewLine + (result.error != null ? "Message from server: " + result.error.message : string.Empty)});
                                            c.Type = Models.CommandType.Unknown;
                                        }
                                        else
                                        {
                                            if (result.result.items != null && result.result.items.Any())
                                            {
                                                var item = result.result.items.FirstOrDefault();

                                                if (item == null)
                                                {
                                                    errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = "Could not retrieve ItemId by ItemPath from Sitecore. The item could not be found." });
                                                    c.Type = Models.CommandType.Unknown;
                                                }
                                                else
                                                {
                                                    if (Guid.TryParse(result.result.items.FirstOrDefault().ID, out guid))
                                                    {
                                                        c.ItemId = guid;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = "Could not retrieve ItemId by ItemPath from Sitecore. The item could not be found." });
                                                c.Type = Models.CommandType.Unknown;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath", Message = ex.Message });
                                c.Type = Models.CommandType.Unknown;
                            }
                        }
                    }
                    else
                    {
                        c.Type = Models.CommandType.Unknown;
                        errors.Add(new Error { RowNumber = rowCount, Field = "ItemPath/ItemId", Message = "No 'ItemPath' or 'ItemId' column available in Excel file" });
                    }

                    // Set the overwrite attribute if the Command Type is 'Copy All'
                    if(c.Type.Equals(Models.CommandType.CopyAll))
                    {
                        if (hasOverwrite)
                        {
                            bool overwrite = false;
                            if (bool.TryParse(reader["Overwrite"].ToString(), out overwrite))
                            {
                                c.Overwrite = overwrite;
                            }
                            else
                            {
                                errors.Add(new Error { RowNumber = rowCount, Field = "Overwrite", Message = "Overwrite is not a valid boolean" });
                                c.Type = Models.CommandType.Unknown;
                            }
                        }
                        else
                        {
                            errors.Add(new Error { RowNumber = rowCount, Field = "Overwrite", Message = "No 'Overwrite' column available in Excel file" });
                            c.Type = Models.CommandType.Unknown;
                        }
                    }
                    operations.Add(c);
                    rowCount++;
                }

                // Check if there are any errors and report them to the user
                // Rows which generated errors will not be put into the Razl script
                if(errors.Any())
                {
                    string errorMessage = string.Format("The following errors occurred:{0}{0}", Environment.NewLine);
                    foreach (var error in errors)
                    {
                        errorMessage += string.Format("RowNumber: {1}{0}Field: {2}{0}Message: {3}{0}{0}", Environment.NewLine, error.RowNumber, error.Field, error.Message);
                    }

                    errorMessage += "The affected records won't be put into the Razl Script!";

                    MessageBox.Show(errorMessage, "Errors occurred!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            prbProgress.Value = 50;

            //Make sure folder name ends with a slash
            if (!_folderNameRazl.EndsWith(@"\"))
            {
                _folderNameRazl += @"\";
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            string xmlFileName = _folderNameRazl + "RazlScript.xml";

            // Write Razl script XML
            using (XmlWriter writer = XmlWriter.Create(xmlFileName, settings))
            {
                writer.WriteStartElement("razl");

                // Start with writing the connections
                foreach(var conn in ConnectionsToScript)
                {
                    writer.WriteStartElement("connection");
                    writer.WriteAttributeString("name", conn.Name);
                    writer.WriteAttributeString("preset", conn.Preset);
                    writer.WriteEndElement();
                }

                // Write the operations
                foreach(var operation in operations)
                {
                    // Copy All operation
                    if(operation.Type.Equals(Models.CommandType.CopyAll))
                    {
                        writer.WriteStartElement("operation");

                        writer.WriteAttributeString("name", operation.TypeText);
                        writer.WriteAttributeString("source", _razlSource);
                        writer.WriteAttributeString("target", _razlTargetName);

                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("name", "itemId");
                        writer.WriteString(operation.ItemId.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("name", "overwrite");
                        writer.WriteString(operation.Overwrite.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("name", "lightningMode");
                        writer.WriteString("false");
                        writer.WriteEndElement();

                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("name", "continueOnError");
                        writer.WriteString("true");
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    } // Copy Item operation
                    else if(operation.Type.Equals(Models.CommandType.CopyItem))
                    {
                        writer.WriteStartElement("operation");

                        writer.WriteAttributeString("name", operation.TypeText);
                        writer.WriteAttributeString("source", _razlSource);
                        writer.WriteAttributeString("target", _razlTargetName);

                        writer.WriteStartElement("parameter");
                        writer.WriteAttributeString("name", "itemId");
                        writer.WriteString(operation.ItemId.ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
            }

            // Prefill the file path of the xml in the script file textbox
            txtRazlScriptPath.Text = xmlFileName;
            prbProgress.Value = 100;
            MessageBox.Show("Creating Razl script: done!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            prbProgress.Value = 0;
        }

        /// <summary>
        /// Runs the Razl Script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunRazlScript_Click(object sender, EventArgs e)
        {
            if(!_hasRazl)
            {
                MessageBox.Show("Could not run script because there is no installation of Razl found on this system.", "No Razl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check whether a script file is selected
            if(string.IsNullOrWhiteSpace(txtRazlScriptPath.Text))
            {
                MessageBox.Show("No Razl script xml is selected!", "No Razl script", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            prbProgress.Maximum = 100;
            prbProgress.Value = 10;

            string _razlScriptLocation = txtRazlScriptPath.Text;

            prbProgress.Value = 30;

            // Check whether the installation location has been found
            if(string.IsNullOrWhiteSpace(_razlInstallationLocation))
            {
                prbProgress.Value = 100;
                MessageBox.Show("Razl installation location could not be found or Razl is not installed on this machine.", "Running script failed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                prbProgress.Value = 0;
                return;
            }

            // Run script
            try
            {
                var startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = _razlInstallationLocation + "Razl.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Arguments = "/script:\"" + _razlScriptLocation + "\"";

                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Running script failed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            prbProgress.Value = 100;
            MessageBox.Show("Razl script has been executed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            prbProgress.Value = 0;
            
        }

        private void ddlSitecoreVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSitecoreVersion.SelectedIndex == 0)
            {
                txtSitecoreLogin.Enabled = true;
                txtSitecorePassword.Enabled = true;
            }

            if(ddlSitecoreVersion.SelectedIndex == 1)
            {
                txtSitecoreLogin.Enabled = false;
                txtSitecorePassword.Enabled = false;
            }
        }

        private void cmbRazlSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbRazlSource.SelectedValue;

            if(selected != null)
                txtSitecoreUrl.Text = ((Connection)cmbRazlSource.SelectedItem).Url;
        }
    }
}
