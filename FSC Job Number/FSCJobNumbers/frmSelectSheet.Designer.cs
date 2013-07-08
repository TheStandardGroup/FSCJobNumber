namespace FSCJobNumbers
{
    partial class frmSelectSheet
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
            this.lblSelectSheet = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lvSheets = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblSelectSheet
            // 
            this.lblSelectSheet.AutoSize = true;
            this.lblSelectSheet.Location = new System.Drawing.Point(12, 9);
            this.lblSelectSheet.Name = "lblSelectSheet";
            this.lblSelectSheet.Size = new System.Drawing.Size(127, 13);
            this.lblSelectSheet.TabIndex = 1;
            this.lblSelectSheet.Text = "Select Worksheet to use:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(142, 27);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(76, 34);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lvSheets
            // 
            this.lvSheets.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvSheets.AutoArrange = false;
            this.lvSheets.FullRowSelect = true;
            this.lvSheets.Location = new System.Drawing.Point(15, 27);
            this.lvSheets.Margin = new System.Windows.Forms.Padding(2);
            this.lvSheets.MultiSelect = false;
            this.lvSheets.Name = "lvSheets";
            this.lvSheets.ShowGroups = false;
            this.lvSheets.Size = new System.Drawing.Size(121, 97);
            this.lvSheets.TabIndex = 1;
            this.lvSheets.UseCompatibleStateImageBehavior = false;
            this.lvSheets.View = System.Windows.Forms.View.List;
            // 
            // frmSelectSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 135);
            this.Controls.Add(this.lvSheets);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblSelectSheet);
            this.Name = "frmSelectSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Spreadsheet";
            this.Load += new System.EventHandler(this.frmSelectSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectSheet;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListView lvSheets;
    }
}