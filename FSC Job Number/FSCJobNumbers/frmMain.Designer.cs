namespace FSCJobNumbers
{
    partial class frmMain
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
            this.btnJob = new System.Windows.Forms.Button();
            this.btnPO = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCurrentDatabase = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.btnChangeServer = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJob
            // 
            this.btnJob.Location = new System.Drawing.Point(12, 12);
            this.btnJob.Name = "btnJob";
            this.btnJob.Size = new System.Drawing.Size(105, 36);
            this.btnJob.TabIndex = 0;
            this.btnJob.Text = "Update by Job #";
            this.btnJob.UseVisualStyleBackColor = true;
            // 
            // btnPO
            // 
            this.btnPO.Location = new System.Drawing.Point(12, 54);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(105, 36);
            this.btnPO.TabIndex = 1;
            this.btnPO.Text = "Update by PO #";
            this.btnPO.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(123, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(311, 246);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 96);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(105, 36);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run Update On  Database";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 36);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Grid";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 264);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 36);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 138);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 36);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh Data Grid";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblCurrentDatabase
            // 
            this.lblCurrentDatabase.AutoSize = true;
            this.lblCurrentDatabase.Location = new System.Drawing.Point(151, 265);
            this.lblCurrentDatabase.Name = "lblCurrentDatabase";
            this.lblCurrentDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblCurrentDatabase.TabIndex = 7;
            this.lblCurrentDatabase.Text = "Database:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(264, 265);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(170, 23);
            this.lblDatabase.TabIndex = 8;
            // 
            // btnChangeServer
            // 
            this.btnChangeServer.Location = new System.Drawing.Point(12, 222);
            this.btnChangeServer.Name = "btnChangeServer";
            this.btnChangeServer.Size = new System.Drawing.Size(105, 36);
            this.btnChangeServer.TabIndex = 9;
            this.btnChangeServer.Text = "Change Server";
            this.btnChangeServer.UseVisualStyleBackColor = true;
            this.btnChangeServer.Click += new System.EventHandler(this.btnChangeServer_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(226, 287);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(472, 309);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnChangeServer);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblCurrentDatabase);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPO);
            this.Controls.Add(this.btnJob);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update \"FSC YN\" field";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJob;
        private System.Windows.Forms.Button btnPO;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCurrentDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Button btnChangeServer;
        private System.Windows.Forms.Label lblInfo;
    }
}