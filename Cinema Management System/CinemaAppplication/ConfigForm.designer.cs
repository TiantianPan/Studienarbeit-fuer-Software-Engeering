using System.ComponentModel;
using System.Windows.Forms;

namespace de.i2cm.helper.HelperLib.Configuration
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OkButton = new System.Windows.Forms.Button();
            this.CButton = new System.Windows.Forms.Button();
            this.ToClipboardBtn = new System.Windows.Forms.Button();
            this.configGrid = new System.Windows.Forms.PropertyGrid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Controls.Add(this.CButton);
            this.panel1.Controls.Add(this.ToClipboardBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 528);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1566, 62);
            this.panel1.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(1126, 6);
            this.OkButton.Margin = new System.Windows.Forms.Padding(6);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(202, 44);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CButton
            // 
            this.CButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CButton.Location = new System.Drawing.Point(1340, 6);
            this.CButton.Margin = new System.Windows.Forms.Padding(6);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(202, 44);
            this.CButton.TabIndex = 1;
            this.CButton.Text = "Cancel";
            this.CButton.UseVisualStyleBackColor = true;
            // 
            // ToClipboardBtn
            // 
            this.ToClipboardBtn.Location = new System.Drawing.Point(24, 6);
            this.ToClipboardBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ToClipboardBtn.Name = "ToClipboardBtn";
            this.ToClipboardBtn.Size = new System.Drawing.Size(184, 44);
            this.ToClipboardBtn.TabIndex = 0;
            this.ToClipboardBtn.Text = "To Clipboard";
            this.ToClipboardBtn.UseVisualStyleBackColor = true;
            this.ToClipboardBtn.Click += new System.EventHandler(this.ToClipboardBtn_Click);
            // 
            // configGrid
            // 
            this.configGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.configGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configGrid.Location = new System.Drawing.Point(0, 0);
            this.configGrid.Margin = new System.Windows.Forms.Padding(6);
            this.configGrid.Name = "configGrid";
            this.configGrid.Size = new System.Drawing.Size(1566, 528);
            this.configGrid.TabIndex = 1;
            this.configGrid.Click += new System.EventHandler(this.configGrid_Click);
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 590);
            this.Controls.Add(this.configGrid);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button ToClipboardBtn;
        private PropertyGrid configGrid;
        private Button OkButton;
        private Button CButton;
    }
}