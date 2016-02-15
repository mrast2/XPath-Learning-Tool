namespace XmlAssignment
{
    partial class LearnXPath
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
            this.btn_browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtXmlPath = new System.Windows.Forms.TextBox();
            this.btn_showXML = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.cmb_xpaths = new System.Windows.Forms.ComboBox();
            this.txt_selectedNode = new System.Windows.Forms.TextBox();
            this.txt_xPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_showResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(420, 23);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtXmlPath
            // 
            this.txtXmlPath.Location = new System.Drawing.Point(43, 25);
            this.txtXmlPath.Name = "txtXmlPath";
            this.txtXmlPath.ReadOnly = true;
            this.txtXmlPath.Size = new System.Drawing.Size(354, 20);
            this.txtXmlPath.TabIndex = 1;
            // 
            // btn_showXML
            // 
            this.btn_showXML.Location = new System.Drawing.Point(177, 69);
            this.btn_showXML.Name = "btn_showXML";
            this.btn_showXML.Size = new System.Drawing.Size(75, 23);
            this.btn_showXML.TabIndex = 3;
            this.btn_showXML.Text = "Show XML";
            this.btn_showXML.UseVisualStyleBackColor = true;
            this.btn_showXML.Click += new System.EventHandler(this.btn_showXML_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser1.Location = new System.Drawing.Point(43, 117);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(452, 408);
            this.webBrowser1.TabIndex = 4;
            // 
            // cmb_xpaths
            // 
            this.cmb_xpaths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_xpaths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_xpaths.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_xpaths.FormattingEnabled = true;
            this.cmb_xpaths.Location = new System.Drawing.Point(568, 71);
            this.cmb_xpaths.Name = "cmb_xpaths";
            this.cmb_xpaths.Size = new System.Drawing.Size(523, 21);
            this.cmb_xpaths.TabIndex = 5;
            this.cmb_xpaths.SelectedValueChanged += new System.EventHandler(this.cmb_xpaths_SelectedValueChanged);
            // 
            // txt_selectedNode
            // 
            this.txt_selectedNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_selectedNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_selectedNode.Location = new System.Drawing.Point(568, 117);
            this.txt_selectedNode.Multiline = true;
            this.txt_selectedNode.Name = "txt_selectedNode";
            this.txt_selectedNode.ReadOnly = true;
            this.txt_selectedNode.Size = new System.Drawing.Size(523, 408);
            this.txt_selectedNode.TabIndex = 6;
            // 
            // txt_xPath
            // 
            this.txt_xPath.Location = new System.Drawing.Point(661, 26);
            this.txt_xPath.Name = "txt_xPath";
            this.txt_xPath.ReadOnly = true;
            this.txt_xPath.Size = new System.Drawing.Size(217, 20);
            this.txt_xPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter xPath";
            // 
            // btn_showResult
            // 
            this.btn_showResult.Location = new System.Drawing.Point(910, 24);
            this.btn_showResult.Name = "btn_showResult";
            this.btn_showResult.Size = new System.Drawing.Size(75, 23);
            this.btn_showResult.TabIndex = 9;
            this.btn_showResult.Text = "Show XML";
            this.btn_showResult.UseVisualStyleBackColor = true;
            this.btn_showResult.Click += new System.EventHandler(this.btn_showResult_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 558);
            this.Controls.Add(this.btn_showResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_xPath);
            this.Controls.Add(this.txt_selectedNode);
            this.Controls.Add(this.cmb_xpaths);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_showXML);
            this.Controls.Add(this.txtXmlPath);
            this.Controls.Add(this.btn_browse);
            this.Name = "Form1";
            this.Text = "Understanding xPaths";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtXmlPath;
        private System.Windows.Forms.Button btn_showXML;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox cmb_xpaths;
        private System.Windows.Forms.TextBox txt_selectedNode;
        private System.Windows.Forms.TextBox txt_xPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_showResult;
    }
}

