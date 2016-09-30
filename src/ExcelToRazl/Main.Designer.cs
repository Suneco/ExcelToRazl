namespace ExcelToRazl
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnOpenExcelDialog = new System.Windows.Forms.Button();
            this.fbdRazlScriptFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseRazlScriptFolder = new System.Windows.Forms.Button();
            this.txtRazlScriptFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRazlSource = new System.Windows.Forms.TextBox();
            this.txtRazlTarget = new System.Windows.Forms.TextBox();
            this.btnGenerateRazlScript = new System.Windows.Forms.Button();
            this.txtSitecoreUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRunRazlScript = new System.Windows.Forms.Button();
            this.ofdRazlScript = new System.Windows.Forms.OpenFileDialog();
            this.txtRazlScriptPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSitecorePassword = new System.Windows.Forms.TextBox();
            this.txtSitecoreLogin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlSitecoreVersion = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectRazlScript = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.stsStatusBar = new System.Windows.Forms.StatusStrip();
            this.prbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbRazlSource = new System.Windows.Forms.ComboBox();
            this.cmbRazlTarget = new System.Windows.Forms.ComboBox();
            this.xElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.stsStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdExcel
            // 
            this.ofdExcel.FileName = "ofdExcel";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(11, 44);
            this.txtExcelPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.ReadOnly = true;
            this.txtExcelPath.Size = new System.Drawing.Size(221, 22);
            this.txtExcelPath.TabIndex = 0;
            // 
            // btnOpenExcelDialog
            // 
            this.btnOpenExcelDialog.Location = new System.Drawing.Point(237, 44);
            this.btnOpenExcelDialog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenExcelDialog.Name = "btnOpenExcelDialog";
            this.btnOpenExcelDialog.Size = new System.Drawing.Size(35, 23);
            this.btnOpenExcelDialog.TabIndex = 1;
            this.btnOpenExcelDialog.Text = "...";
            this.btnOpenExcelDialog.UseVisualStyleBackColor = true;
            this.btnOpenExcelDialog.Click += new System.EventHandler(this.btnOpenExcelDialog_Click);
            // 
            // btnChooseRazlScriptFolder
            // 
            this.btnChooseRazlScriptFolder.Location = new System.Drawing.Point(237, 89);
            this.btnChooseRazlScriptFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChooseRazlScriptFolder.Name = "btnChooseRazlScriptFolder";
            this.btnChooseRazlScriptFolder.Size = new System.Drawing.Size(35, 23);
            this.btnChooseRazlScriptFolder.TabIndex = 2;
            this.btnChooseRazlScriptFolder.Text = "...";
            this.btnChooseRazlScriptFolder.UseVisualStyleBackColor = true;
            this.btnChooseRazlScriptFolder.Click += new System.EventHandler(this.btnChooseRazlScriptFolder_Click);
            // 
            // txtRazlScriptFolder
            // 
            this.txtRazlScriptFolder.Location = new System.Drawing.Point(11, 89);
            this.txtRazlScriptFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRazlScriptFolder.Name = "txtRazlScriptFolder";
            this.txtRazlScriptFolder.ReadOnly = true;
            this.txtRazlScriptFolder.Size = new System.Drawing.Size(221, 22);
            this.txtRazlScriptFolder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pick Excel file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Razl script output folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razl connection source name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Razl connection target name:";
            // 
            // txtRazlSource
            // 
            this.txtRazlSource.Location = new System.Drawing.Point(277, 44);
            this.txtRazlSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRazlSource.Name = "txtRazlSource";
            this.txtRazlSource.Size = new System.Drawing.Size(261, 22);
            this.txtRazlSource.TabIndex = 8;
            // 
            // txtRazlTarget
            // 
            this.txtRazlTarget.Location = new System.Drawing.Point(278, 88);
            this.txtRazlTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRazlTarget.Name = "txtRazlTarget";
            this.txtRazlTarget.Size = new System.Drawing.Size(261, 22);
            this.txtRazlTarget.TabIndex = 9;
            // 
            // btnGenerateRazlScript
            // 
            this.btnGenerateRazlScript.Location = new System.Drawing.Point(1084, 39);
            this.btnGenerateRazlScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateRazlScript.Name = "btnGenerateRazlScript";
            this.btnGenerateRazlScript.Size = new System.Drawing.Size(197, 70);
            this.btnGenerateRazlScript.TabIndex = 14;
            this.btnGenerateRazlScript.Text = "Generate Razl script";
            this.btnGenerateRazlScript.UseVisualStyleBackColor = true;
            this.btnGenerateRazlScript.Click += new System.EventHandler(this.btnGenerateRazlScript_Click);
            // 
            // txtSitecoreUrl
            // 
            this.txtSitecoreUrl.Location = new System.Drawing.Point(545, 44);
            this.txtSitecoreUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSitecoreUrl.Name = "txtSitecoreUrl";
            this.txtSitecoreUrl.Size = new System.Drawing.Size(261, 22);
            this.txtSitecoreUrl.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sitecore source url:";
            // 
            // btnRunRazlScript
            // 
            this.btnRunRazlScript.Location = new System.Drawing.Point(9, 66);
            this.btnRunRazlScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunRazlScript.Name = "btnRunRazlScript";
            this.btnRunRazlScript.Size = new System.Drawing.Size(261, 43);
            this.btnRunRazlScript.TabIndex = 17;
            this.btnRunRazlScript.Text = "Run Razl script";
            this.btnRunRazlScript.UseVisualStyleBackColor = true;
            this.btnRunRazlScript.Click += new System.EventHandler(this.btnRunRazlScript_Click);
            // 
            // ofdRazlScript
            // 
            this.ofdRazlScript.FileName = "openFileDialog1";
            // 
            // txtRazlScriptPath
            // 
            this.txtRazlScriptPath.Location = new System.Drawing.Point(9, 38);
            this.txtRazlScriptPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRazlScriptPath.Name = "txtRazlScriptPath";
            this.txtRazlScriptPath.ReadOnly = true;
            this.txtRazlScriptPath.Size = new System.Drawing.Size(221, 22);
            this.txtRazlScriptPath.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRazlTarget);
            this.groupBox1.Controls.Add(this.cmbRazlSource);
            this.groupBox1.Controls.Add(this.txtSitecorePassword);
            this.groupBox1.Controls.Add(this.txtSitecoreLogin);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ddlSitecoreVersion);
            this.groupBox1.Controls.Add(this.txtExcelPath);
            this.groupBox1.Controls.Add(this.btnOpenExcelDialog);
            this.groupBox1.Controls.Add(this.btnGenerateRazlScript);
            this.groupBox1.Controls.Add(this.btnChooseRazlScriptFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRazlScriptFolder);
            this.groupBox1.Controls.Add(this.txtSitecoreUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRazlTarget);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRazlSource);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1289, 130);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Razl script";
            // 
            // txtSitecorePassword
            // 
            this.txtSitecorePassword.Location = new System.Drawing.Point(815, 87);
            this.txtSitecorePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSitecorePassword.Name = "txtSitecorePassword";
            this.txtSitecorePassword.Size = new System.Drawing.Size(261, 22);
            this.txtSitecorePassword.TabIndex = 13;
            this.txtSitecorePassword.Text = "b";
            this.txtSitecorePassword.UseSystemPasswordChar = true;
            // 
            // txtSitecoreLogin
            // 
            this.txtSitecoreLogin.Location = new System.Drawing.Point(818, 44);
            this.txtSitecoreLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSitecoreLogin.Name = "txtSitecoreLogin";
            this.txtSitecoreLogin.Size = new System.Drawing.Size(261, 22);
            this.txtSitecoreLogin.TabIndex = 12;
            this.txtSitecoreLogin.Text = "sitecore\\admin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(815, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Sitecore source password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(811, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Sitecore source login:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(545, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Select Sitecore version:";
            // 
            // ddlSitecoreVersion
            // 
            this.ddlSitecoreVersion.FormattingEnabled = true;
            this.ddlSitecoreVersion.Items.AddRange(new object[] {
            "Version 7.2 or lower (Item Web API)",
            "Version 7.5 or higher (Sitecore Service Client)"});
            this.ddlSitecoreVersion.Location = new System.Drawing.Point(545, 87);
            this.ddlSitecoreVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlSitecoreVersion.Name = "ddlSitecoreVersion";
            this.ddlSitecoreVersion.Size = new System.Drawing.Size(261, 24);
            this.ddlSitecoreVersion.TabIndex = 11;
            this.ddlSitecoreVersion.SelectedIndexChanged += new System.EventHandler(this.ddlSitecoreVersion_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectRazlScript);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnRunRazlScript);
            this.groupBox2.Controls.Add(this.txtRazlScriptPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1289, 121);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run Razl script";
            // 
            // btnSelectRazlScript
            // 
            this.btnSelectRazlScript.Location = new System.Drawing.Point(236, 37);
            this.btnSelectRazlScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectRazlScript.Name = "btnSelectRazlScript";
            this.btnSelectRazlScript.Size = new System.Drawing.Size(35, 23);
            this.btnSelectRazlScript.TabIndex = 16;
            this.btnSelectRazlScript.Text = "...";
            this.btnSelectRazlScript.UseVisualStyleBackColor = true;
            this.btnSelectRazlScript.Click += new System.EventHandler(this.btnSelectRazlScript_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Select Razl script:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stsStatusBar
            // 
            this.stsStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prbProgress});
            this.stsStatusBar.Location = new System.Drawing.Point(0, 278);
            this.stsStatusBar.Name = "stsStatusBar";
            this.stsStatusBar.Padding = new System.Windows.Forms.Padding(13, 0, 1, 0);
            this.stsStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stsStatusBar.Size = new System.Drawing.Size(1309, 26);
            this.stsStatusBar.SizingGrip = false;
            this.stsStatusBar.TabIndex = 17;
            this.stsStatusBar.Text = "statusStrip1";
            // 
            // prbProgress
            // 
            this.prbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prbProgress.Name = "prbProgress";
            this.prbProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prbProgress.Size = new System.Drawing.Size(100, 20);
            // 
            // cmbRazlSource
            // 
            this.cmbRazlSource.FormattingEnabled = true;
            this.cmbRazlSource.Location = new System.Drawing.Point(277, 44);
            this.cmbRazlSource.Name = "cmbRazlSource";
            this.cmbRazlSource.Size = new System.Drawing.Size(260, 24);
            this.cmbRazlSource.TabIndex = 17;
            this.cmbRazlSource.SelectedIndexChanged += new System.EventHandler(this.cmbRazlSource_SelectedIndexChanged);
            // 
            // cmbRazlTarget
            // 
            this.cmbRazlTarget.FormattingEnabled = true;
            this.cmbRazlTarget.Location = new System.Drawing.Point(277, 88);
            this.cmbRazlTarget.Name = "cmbRazlTarget";
            this.cmbRazlTarget.Size = new System.Drawing.Size(260, 24);
            this.cmbRazlTarget.TabIndex = 18;
            // 
            // xElementBindingSource
            // 
            this.xElementBindingSource.DataSource = typeof(System.Xml.Linq.XElement);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 304);
            this.Controls.Add(this.stsStatusBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Suneco - Razl Script Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.stsStatusBar.ResumeLayout(false);
            this.stsStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xElementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnOpenExcelDialog;
        private System.Windows.Forms.FolderBrowserDialog fbdRazlScriptFolder;
        private System.Windows.Forms.Button btnChooseRazlScriptFolder;
        private System.Windows.Forms.TextBox txtRazlScriptFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRazlSource;
        private System.Windows.Forms.TextBox txtRazlTarget;
        private System.Windows.Forms.Button btnGenerateRazlScript;
        private System.Windows.Forms.TextBox txtSitecoreUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRunRazlScript;
        private System.Windows.Forms.OpenFileDialog ofdRazlScript;
        private System.Windows.Forms.TextBox txtRazlScriptPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectRazlScript;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip stsStatusBar;
        private System.Windows.Forms.ToolStripProgressBar prbProgress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlSitecoreVersion;
        private System.Windows.Forms.TextBox txtSitecorePassword;
        private System.Windows.Forms.TextBox txtSitecoreLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRazlTarget;
        private System.Windows.Forms.ComboBox cmbRazlSource;
        private System.Windows.Forms.BindingSource xElementBindingSource;
    }
}

