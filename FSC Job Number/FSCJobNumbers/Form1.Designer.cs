namespace FSCJobNumbers
{
    partial class Form1
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
            this.lblSheet = new System.Windows.Forms.Label();
            this.lblSheetFake = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnRunUpdate = new System.Windows.Forms.Button();
            this.radioJobs = new System.Windows.Forms.RadioButton();
            this.radioOrderLines = new System.Windows.Forms.RadioButton();
            this.lblUpdateType = new System.Windows.Forms.Label();
            this.dgvResultSetOrderLines = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dgvResultSetJob = new System.Windows.Forms.DataGridView();
            this.btnLoadRecords = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultSetOrderLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultSetJob)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSheet.Location = new System.Drawing.Point(79, 97);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(82, 16);
            this.lblSheet.TabIndex = 4;
            this.lblSheet.Text = "Worksheet";
            // 
            // lblSheetFake
            // 
            this.lblSheetFake.AutoSize = true;
            this.lblSheetFake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetFake.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSheetFake.Location = new System.Drawing.Point(79, 97);
            this.lblSheetFake.Name = "lblSheetFake";
            this.lblSheetFake.Size = new System.Drawing.Size(82, 16);
            this.lblSheetFake.TabIndex = 18;
            this.lblSheetFake.Text = "Worksheet";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(50, 53);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(76, 16);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "Excel File";
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtFile.Location = new System.Drawing.Point(132, 53);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(391, 20);
            this.txtFile.TabIndex = 2;
            // 
            // btnRunUpdate
            // 
            this.btnRunUpdate.Enabled = false;
            this.btnRunUpdate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRunUpdate.Location = new System.Drawing.Point(82, 142);
            this.btnRunUpdate.Name = "btnRunUpdate";
            this.btnRunUpdate.Size = new System.Drawing.Size(206, 23);
            this.btnRunUpdate.TabIndex = 12;
            this.btnRunUpdate.Text = "Set FSC YN for ALL Records to \"N\"";
            this.btnRunUpdate.UseVisualStyleBackColor = true;
            // 
            // radioJobs
            // 
            this.radioJobs.AutoSize = true;
            this.radioJobs.Checked = true;
            this.radioJobs.Location = new System.Drawing.Point(164, 13);
            this.radioJobs.Name = "radioJobs";
            this.radioJobs.Size = new System.Drawing.Size(87, 17);
            this.radioJobs.TabIndex = 14;
            this.radioJobs.TabStop = true;
            this.radioJobs.Text = "Job Numbers";
            this.radioJobs.UseVisualStyleBackColor = true;
            // 
            // radioOrderLines
            // 
            this.radioOrderLines.AutoSize = true;
            this.radioOrderLines.Location = new System.Drawing.Point(257, 13);
            this.radioOrderLines.Name = "radioOrderLines";
            this.radioOrderLines.Size = new System.Drawing.Size(102, 17);
            this.radioOrderLines.TabIndex = 15;
            this.radioOrderLines.Text = "Order Line Items";
            this.radioOrderLines.UseVisualStyleBackColor = true;
            // 
            // lblUpdateType
            // 
            this.lblUpdateType.AutoSize = true;
            this.lblUpdateType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateType.Location = new System.Drawing.Point(50, 13);
            this.lblUpdateType.Name = "lblUpdateType";
            this.lblUpdateType.Size = new System.Drawing.Size(102, 18);
            this.lblUpdateType.TabIndex = 16;
            this.lblUpdateType.Text = "Update Type";
            // 
            // dgvResultSetOrderLines
            // 
            this.dgvResultSetOrderLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultSetOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultSetOrderLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultSetOrderLines.Enabled = false;
            this.dgvResultSetOrderLines.Location = new System.Drawing.Point(0, 0);
            this.dgvResultSetOrderLines.Name = "dgvResultSetOrderLines";
            this.dgvResultSetOrderLines.Size = new System.Drawing.Size(620, 10);
            this.dgvResultSetOrderLines.TabIndex = 20;
            this.dgvResultSetOrderLines.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(332, 142);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(206, 23);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbSheet
            // 
            this.cbSheet.DropDownHeight = 1000;
            this.cbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.IntegralHeight = false;
            this.cbSheet.Location = new System.Drawing.Point(166, 97);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(121, 21);
            this.cbSheet.TabIndex = 23;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(520, 51);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 23);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dgvResultSetJob
            // 
            this.dgvResultSetJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultSetJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultSetJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultSetJob.Enabled = false;
            this.dgvResultSetJob.Location = new System.Drawing.Point(0, 0);
            this.dgvResultSetJob.Name = "dgvResultSetJob";
            this.dgvResultSetJob.Size = new System.Drawing.Size(620, 10);
            this.dgvResultSetJob.TabIndex = 24;
            this.dgvResultSetJob.Visible = false;
            // 
            // btnLoadRecords
            // 
            this.btnLoadRecords.Enabled = false;
            this.btnLoadRecords.Location = new System.Drawing.Point(332, 97);
            this.btnLoadRecords.Name = "btnLoadRecords";
            this.btnLoadRecords.Size = new System.Drawing.Size(206, 23);
            this.btnLoadRecords.TabIndex = 25;
            this.btnLoadRecords.Text = "Load Records";
            this.btnLoadRecords.UseVisualStyleBackColor = true;
            this.btnLoadRecords.Visible = false;
            this.btnLoadRecords.Click += new System.EventHandler(this.btnLoadRecords_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnLoadRecords);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.cbSheet);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.lblUpdateType);
            this.groupBox1.Controls.Add(this.radioOrderLines);
            this.groupBox1.Controls.Add(this.radioJobs);
            this.groupBox1.Controls.Add(this.btnRunUpdate);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.lblSheetFake);
            this.groupBox1.Controls.Add(this.lblSheet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.groupBox1.Size = new System.Drawing.Size(642, 631);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.dgvResultSetOrderLines);
            this.panel1.Controls.Add(this.dgvResultSetJob);
            this.panel1.Location = new System.Drawing.Point(12, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 10);
            this.panel1.TabIndex = 26;
            this.panel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(642, 631);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update FSCYN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultSetOrderLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultSetJob)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.Label lblSheetFake;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnRunUpdate;
        private System.Windows.Forms.RadioButton radioJobs;
        private System.Windows.Forms.RadioButton radioOrderLines;
        private System.Windows.Forms.Label lblUpdateType;
        private System.Windows.Forms.DataGridView dgvResultSetOrderLines;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dgvResultSetJob;
        private System.Windows.Forms.Button btnLoadRecords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;

    }
}

