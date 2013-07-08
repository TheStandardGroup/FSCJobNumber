using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace FSCJobNumbers
{
    public partial class frmMain : Form
    {
        static private System.Windows.Forms.Cursor frmCursor;
        static private Workbook wb = null;
        static private Worksheet ws = null;
        static private string sValues = "";
        static private string sUpdateType = "";
        //static private string sDatabase = "SGproving_dosrun";
        static private string sDatabase = "SGlive_dosrun";
        static public string sSelectedSheet = "";
        Microsoft.Office.Interop.Excel.Application app = null;
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnJob.Click += new EventHandler(btnJob_Click);
            btnPO.Click += new EventHandler(btnPO_Click);
            btnRun.Click += new EventHandler(btnRun_Click);
            btnClear.Click += new EventHandler(btnClear_Click);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            btnExit.Click += new EventHandler(btnExit_Click);
            btnJob.TabIndex = 1;
            btnPO.TabIndex = 2;
            btnRun.TabIndex = 3;
            btnRefresh.TabIndex = 4;
            btnClear.TabIndex = 5;
            btnExit.TabIndex = 6;
            dataGridView1.TabIndex = 7;
            this.BackColor = Color.FromArgb(28, 63, 119);
            this.ForeColor = Color.White;
            btnRun.Enabled = false;
            btnRefresh.Enabled = false;
            setButtonColor(btnChangeServer);
            setButtonColor(btnClear);
            setButtonColor(btnExit);
            setButtonColor(btnJob);
            setButtonColor(btnPO);
            setButtonColor(btnRefresh);
            setButtonColor(btnRun);
            lblDatabase.Text = sDatabase;
            updateLblInfo("Ready");
        }

        public static void setButtonColor(System.Windows.Forms.Button btn) {
            btn.BackColor = Color.FromArgb(231, 185, 1);
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Popup;
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            closeExcelApp();
            System.Windows.Forms.Application.Exit();
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            frmCursor = System.Windows.Forms.Cursors.WaitCursor;
            FillDataGrid();
            frmCursor = System.Windows.Forms.Cursors.Default;
        }

        void closeExcelApp() {
            if (app != null) {
                wb.Close();
                app.Quit();
                app = null;
            }
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            frmCursor = System.Windows.Forms.Cursors.WaitCursor;
            FSCYN.reset();
            closeExcelApp();
            btnRun.Enabled = false;
            btnRun.ForeColor = System.Drawing.Color.FromName("ControlDarkDark");
            btnRefresh.Enabled = false;
            btnRefresh.ForeColor = System.Drawing.Color.FromName("ControlDarkDark");
            dataGridView1.DataSource = null;
            wb = null;
            ws = null;
            sUpdateType = "";
            sValues = "";
            frmCursor = System.Windows.Forms.Cursors.Default;
            btnJob.Enabled = true;
            btnPO.Enabled = true;
            updateLblInfo("ready");
        }

        void btnPO_Click(object sender, EventArgs e)
        {
            frmCursor = System.Windows.Forms.Cursors.WaitCursor;
            FSCYN.reset();
            closeExcelApp();
            string sColumnHeader = GetUpdateValues();

            if (sColumnHeader == "PO#" || sColumnHeader.ToLower() == "po#")
            {
                ParseColumnValues();
                sUpdateType = "PO";
                btnJob.Enabled = false;
                btnPO.Enabled = false;
                FillDataGrid();
            }
            else
                MessageBox.Show("File does not contain a worksheet with valid PO NUMBERS.  Please select a different file", "File Open Error", MessageBoxButtons.OK);

            frmCursor = System.Windows.Forms.Cursors.Default;
        }

        void btnJob_Click(object sender, EventArgs e)
        {
            frmCursor = System.Windows.Forms.Cursors.WaitCursor;
            FSCYN.reset();
            closeExcelApp();
            string sColumnHeader = GetUpdateValues();

            if (sColumnHeader == "Job#" || sColumnHeader.ToLower() == "job#")
            {
                ParseColumnValues();
                sUpdateType = "JOB";
                btnPO.Enabled = false;
                btnJob.Enabled = false;
                FillDataGrid();
            }
            else
                MessageBox.Show("File does not contain a worksheet with valid JOB NUMBERS.  Please select a different file", "File Open Error", MessageBoxButtons.OK);

            frmCursor = System.Windows.Forms.Cursors.Default;
        }

        void btnRun_Click(object sender, EventArgs e)
        {
            frmCursor = System.Windows.Forms.Cursors.WaitCursor;
            bool bUpdate = RunUpdate();
            frmCursor = System.Windows.Forms.Cursors.Default;
        }

        private bool RunUpdate()
        {
            bool bSuccess = false;
            btnRun.Enabled = false;
            btnRun.ForeColor = System.Drawing.Color.FromName("ControlDarkDark");
            updateLblInfo("Updating the database");
            
            try
            {
                int iUpdatedRows = FSCYN.UpdateFSCYNValue(sUpdateType, sValues, sDatabase);
                updateLblInfo("Database Updated");
                //if (iUpdatedRows > 0)
                //{
                //    bSuccess = true;
                //    MessageBox.Show("Update successful - " + iUpdatedRows + " records updated.", "Update Results", MessageBoxButtons.OK);
                //}

                //else
                //    MessageBox.Show("ERROR - there was a problem with the update. Please contact system administrator.", "Update Results", MessageBoxButtons.OK);
            }
            catch
            {
                updateLblInfo("Failed to update the database");
                MessageBox.Show("ERROR - there was a problem with the update. Please contact system administrator.", "Update Results", MessageBoxButtons.OK);
            }

            return bSuccess;
        }

        private void FillDataGrid()
        {
            updateLblInfo("Loading data from database");
            System.Data.DataTable dt = FSCYN.GetDataTable(sUpdateType, sValues, sDatabase);

            if (dt != null && dt.Rows.Count > 0)
            {

                dataGridView1.DataSource = dt;
                string[] vis = new String[2];
                vis[0] = "FSC YN";
                if (sUpdateType == "JOB")
                    vis[1] = "JOB NUMBER";
                else
                    vis[1] = "ORDER NO";
                setColumnsVisible(vis);
                updateLblInfo("Data loaded");
                //int iDifference = iBefore - iAfter;
                //int iWidth = dataGridView1.Width;
                //dataGridView1.Width = (iWidth - iDifference);
                btnRun.Enabled = true;
                btnRun.ForeColor = System.Drawing.Color.FromName("ControlText");
                btnRefresh.Enabled = true;
                btnRefresh.ForeColor = System.Drawing.Color.FromName("ControlText");
            }
            else
                updateLblInfo("Error Loading Data");
        }

        public void setColumnsVisible(string[] vis)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
                if (dataGridView1.Columns[i].Name != vis[0])
                {
                    if (dataGridView1.Columns[i].Name != vis[1])
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
                }
            }
        }

        static public string ParseColumnValues()
        {
            Range rngUsed = ws.UsedRange;

            for (int i = 2; i <= rngUsed.Rows.Count; i++)
            {
                Range rng = rngUsed.get_Range((object)rngUsed.Cells[i, 1], (object)rngUsed.Cells[i, 1]);

                if (!String.IsNullOrEmpty(rng.Cells.Text.ToString()) && rng.Cells.Text.ToString() != "" && rng.Cells.Text.ToString().Length > 0)
                    sValues = string.Format("{0}{1},", sValues, rng.Cells.Text.ToString());
                //sValues = sValues + rng.Cells.Text.ToString() + ",";
            }

            if (sValues.Length > 1)
                sValues = sValues.Substring(0, (sValues.Length - 1));

            return sValues;
        }

        private string GetUpdateValues()
        {
            string sColumnHeader = "ERROR";
            string sFilePath = OpenExcelWorkbook();

            if (sFilePath == "ERROR")
                MessageBox.Show("Could not open file.  Please select a different file", "File Open Error", MessageBoxButtons.OK);
            else
            {
                if (wb != null)
                {
                    frmSelectSheet frmSheetSelect = new frmSelectSheet();
                    frmSheetSelect.wb = wb;
                    frmCursor = System.Windows.Forms.Cursors.Default;
                    frmSheetSelect.ShowDialog();
                    frmCursor = System.Windows.Forms.Cursors.WaitCursor;

                    if (!String.IsNullOrEmpty(sSelectedSheet) && sSelectedSheet != "" && sSelectedSheet.Length > 0)
                    {
                        bool bFoundSheet = false;

                        for (int i = 1; i <= wb.Worksheets.Count; i++)
                        {
                            if (((Worksheet)wb.Worksheets[i]).Name == sSelectedSheet)
                            {
                                ws = (Worksheet)wb.Worksheets[i];
                                bFoundSheet = true;
                                break;
                            }
                        }

                        if (bFoundSheet)
                        {
                            Range rng = (Range)ws.Cells[1, 1];
                            sColumnHeader = rng.Text.ToString();
                        }
                    }
                }
                else
                    MessageBox.Show("Could not open file.  Please select a different file", "File Open Error", MessageBoxButtons.OK);
                
            }

            return sColumnHeader;
        }

        private string OpenExcelWorkbook()
        {
            string sFilePath = OpenExcelFile();

            if (File.Exists(sFilePath))
            {
                app = new Microsoft.Office.Interop.Excel.ApplicationClass();
                app.Workbooks.Open(sFilePath, (object)0, (object)true, (object)5, (object)"", (object)"", (object)true, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, 0, true, 1, 1);
                wb = (Workbook)app.Workbooks.Application.ActiveWorkbook;
                
            }

            return sFilePath;
        }

        private string OpenExcelFile()
        {
            string sFilePath = "ERROR";
            OpenFileDialog fiDialog = new OpenFileDialog();
            fiDialog.Title = "Select Excel File";
            fiDialog.InitialDirectory = @"C:\";
            fiDialog.FileName = "";
            fiDialog.Filter = "Excel Files (*.xls)|*.xls*|All Files(*.*)|*.*";
            fiDialog.FilterIndex = 1;
            fiDialog.RestoreDirectory = true;

            if (fiDialog.ShowDialog() == DialogResult.OK)
            {
                sFilePath = fiDialog.FileName;
                System.Windows.Forms.Application.DoEvents();
            }

            return sFilePath;
        }

        public string getDbName() {
            return sDatabase;
        }

        public void setDbName(string n) {
            sDatabase = n;
            btnRun.Enabled = false;
            lblDatabase.Text = n;
        }

        private void btnChangeServer_Click(object sender, EventArgs e)
        {
            frmChange frm = new frmChange(this);
            frm.ShowDialog();
            
        }

        public void updateLblInfo(string info) {
            lblInfo.Text = info;
            lblInfo.Location =(new System.Drawing.Point(this.Width/2-lblInfo.Width/2,lblInfo.Location.Y));
            this.Update();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeExcelApp();
        }
    }
}
