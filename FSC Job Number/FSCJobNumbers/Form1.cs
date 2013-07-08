using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;

namespace FSCJobNumbers
{
    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Excel.Workbook wb;
        Microsoft.Office.Interop.Excel.Worksheet ws;
        //int iSheet = -1;
        static public string sUpdateType = "";
        static public string sWorkSheet = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFile.KeyPress += new KeyPressEventHandler(txtFile_KeyPress);
            txtFile.ModifiedChanged += new EventHandler(txtFile_ModifiedChanged);
            txtFile.TextChanged += new EventHandler(txtFile_TextChanged);
            cbSheet.TextChanged += new EventHandler(cbSheet_TextChanged);
            radioJobs.TabIndex = 0;
            radioOrderLines.TabIndex = 1;
            txtFile.TabIndex = 2;
            btnBrowse.TabIndex = 3;
            cbSheet.TabIndex = 4;
            btnRunUpdate.TabIndex = 5;
            btnExit.TabIndex = 6;
            txtFile.Text = "";
            txtFile.BackColor = System.Drawing.Color.FromName("Window");
            txtFile.Focus();
            DisableSheetOptions();
            this.BackColor = Color.FromArgb(28, 63, 119);
            this.ForeColor = Color.White;
            frmMain.setButtonColor(btnBrowse);
            frmMain.setButtonColor(btnExit);
            frmMain.setButtonColor(btnLoadRecords);
            frmMain.setButtonColor(btnRunUpdate);
        }

        private void ChangeUpdateType(string sChangeTo, bool bKeepValues)
        {
            if (sChangeTo == "Jobs")
            {
                radioJobs.Checked = true;
                radioOrderLines.Checked = false;
                sUpdateType = "Jobs";
            }
            else
            {
                radioJobs.Checked = false;
                radioOrderLines.Checked = true;
                sUpdateType = "OrderLines";
            }

            if (bKeepValues)
            {
                if (!String.IsNullOrEmpty(cbSheet.Text) && cbSheet.Text != "" && cbSheet.Text.Length > 1 && cbSheet.Items.Count > 1)
                {
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[cbSheet.Text];
                    GetResultSetForDGV();
                }       
            }
            else
            {
                txtFile.Text = "";
                txtFile.BackColor = System.Drawing.Color.FromName("Window");
                txtFile.Focus();
                DisableSheetOptions();
            }
        }

        void txtFile_TextChanged(object sender, EventArgs e)
        {
            DisableSheetOptions();
        }

        void txtFile_ModifiedChanged(object sender, EventArgs e)
        {
            DisableSheetOptions();
        }

        void cbSheet_ValueMemberChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbSheet.Text) && cbSheet.Text != "" && cbSheet.Text.Length > 1 && cbSheet.Items.Count > 1)
            {
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[cbSheet.Text];
                GetResultSetForDGV();
            }         
        }

        void cbSheet_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbSheet.Text) && cbSheet.Text != "" && cbSheet.Text.Length > 1 && cbSheet.Items.Count > 1)
            {
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[cbSheet.Text];
                GetResultSetForDGV();
            }
        }

        private void FillDGVResultSet(DataGridView dgv, string sQuery)
        {
            DataTable dt = FSCYN.GetDataTable(sQuery, "", "");
            panel1.Enabled = true;
            Size sz = new Size(620, 450);
            panel1.Size = sz;
            panel1.Visible = true;
            dgv.Enabled = true;
            dgv.Visible = true;
            dgv.DataSource = dt;
            int iHeight = panel1.Height;
            int y = panel1.Location.Y + iHeight + 20;
            Point pt = new Point(82, y);
            btnRunUpdate.Location = pt;
            btnRunUpdate.ForeColor = System.Drawing.Color.FromName("ControlText");
            btnRunUpdate.Enabled = true;
            pt = new Point(332, y);
            btnExit.Location = pt;        
        }

        private void GetResultSetForDGV()
        {
            string sColumnHeader = "";
            string sQuery = "";
            string sInCollection = FSCYN.ParseColumnValues(ws, out sColumnHeader);

            if (radioJobs.Checked == true && radioOrderLines.Checked == false)
            {
                if (sColumnHeader == "Job#" || sColumnHeader.ToLower() == "job#")
                {
                    sQuery = FSCYN.GetQuery("Jobs", sInCollection, "");
                    FillDGVResultSet(dgvResultSetJob, sQuery);          
                }
                else
                    InvalidExcelFile();
            }
            else if (radioJobs.Checked == false && radioOrderLines.Checked == true)
            {
                if (sColumnHeader == "PO#" || sColumnHeader.ToLower() == "po#")
                {
                    sQuery = FSCYN.GetQuery("OrderLines", sInCollection, "");
                    FillDGVResultSet(dgvResultSetOrderLines, sQuery);   
                }
                else
                    InvalidExcelFile();
            }
            else
                InvalidExcelFile();
        }

        void txtFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chCR = Convert.ToChar(13);

            if (e.KeyChar.ToString() == chCR.ToString())
                CheckFile(txtFile.Text);
            else
            {
                cbSheet.Text = "";
                cbSheet.BackColor = System.Drawing.Color.FromName("Control");
                cbSheet.Enabled = false;
            }
        }

        private void CheckFile(string sFile)
        {
            if (File.Exists(sFile))
            {
                EnableSheetOptions();
            }               
            else
                DisableSheetOptions();
        }

        private void DisableSheetOptions()
        {
            lblSheetFake.Visible = false;
            lblSheet.Visible = true;
            cbSheet.Text = "";
            cbSheet.Enabled = false;
            cbSheet.BackColor = System.Drawing.Color.FromName("Control");
            EmptyCbSheetList();
            ws = null;

            if (dgvResultSetJob.Rows.Count > 0)
                RemoveDataGridViewRows(dgvResultSetJob);

            if (dgvResultSetOrderLines.Rows.Count > 0)
                RemoveDataGridViewRows(dgvResultSetOrderLines);

            dgvResultSetJob.Enabled = false;
            dgvResultSetJob.Visible = false;
            dgvResultSetOrderLines.Enabled = false;
            dgvResultSetOrderLines.Visible = false;
            Size sz = new Size(620, 10);
            panel1.Visible = false;
            panel1.Enabled = false;
            btnRunUpdate.ForeColor = System.Drawing.Color.FromName("ControlDarkDark");
            btnRunUpdate.Enabled = false;
            Point pt = new Point(82, 142);
            btnRunUpdate.Location = pt;
            pt = new Point(332, 142);
            btnExit.Location = pt;        
        }

        private void EnableSheetOptions()
        {
            lblSheetFake.Visible = false;
            lblSheet.Visible = true;
            cbSheet.Text = "";
            cbSheet.Enabled = true;
            cbSheet.BackColor = System.Drawing.Color.FromName("Window");
            FillCbSheetList();      
        }

        private void RemoveDataGridViewRows(DataGridView dgv)
        {
            foreach (DataGridViewRow dgvRow in dgv.Rows)
                dgv.Rows.Remove(dgvRow);
        }

        private void FillCbSheetList()
        {
            wb = FSCYN.GetExcelWorkbook(txtFile.Text);

            foreach (Microsoft.Office.Interop.Excel.Worksheet sheets in wb.Worksheets)
                cbSheet.Items.Add((object)sheets.Name);
        }

        private void EmptyCbSheetList()
        {
            cbSheet.Items.Clear();
            cbSheet.Text = "";
        }

        private string GetFilePath()
        {
            string sFilePath = "";
            OpenFileDialog fiDialog = new OpenFileDialog();
            fiDialog.Title = "Select Excel File";
            fiDialog.InitialDirectory = @"C:\";
            fiDialog.FileName = txtFile.Text;
            fiDialog.Filter = "Excel Files (*.xls)|*.xls*|All Files(*.*)|*.*";
            //fiDialog.Filter = "Excel 97-2003(*.xls)|*.xls|Excel 2007 (*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fiDialog.FilterIndex = 1;
            fiDialog.RestoreDirectory = true;

            if (fiDialog.ShowDialog() == DialogResult.OK)
            {
                sFilePath = fiDialog.FileName;
                Application.DoEvents();
            }

            return sFilePath;
        }

        private void InvalidExcelFile()
        {
            string sSelected= "";
            string sNotSelected= "";
            bool bError = false;
            bool bClear = false;

            if (radioJobs.Checked == true && radioOrderLines.Checked == false)
            {
                sSelected = "\"Job Numbers\"";
                sNotSelected = "\"Order Line Items\"";
            }
            else if (radioJobs.Checked == false && radioOrderLines.Checked == true)
            {
                sSelected = "\"Order Line Items\"";
                sNotSelected = "\"Job Numbers\"";
            }
            else
            {
                bClear = true;
                bError = true;
            }
               

            if (bError)
            {
                MessageBox.Show("The Column Header for " + cbSheet.Text + " does not match the \"Update Type\" selected - Invalid File." +
                    "No \"Update Type\" has been selected.", "Invalid File\\\"Update Type\"", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("The Column Header for " + cbSheet.Text + " does not match the \"Update Type\" selected - Invalid File." +
                    "  Change the \"Update Type\" from " + sSelected + " to " + sNotSelected + "?", "Invalid File\\\"Update Type\"", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (radioJobs.Checked == true)
                        ChangeUpdateType("OrderLines", true);
                    else
                        ChangeUpdateType("Jobs", true);
                }
                else
                {
                    bClear = true;
                }
            }
        }

        private void GetSheet()
        {
            frmSelectSheet formSelectSheet = new frmSelectSheet();
            //formSelectSheet.sFilePath = txtFile.Text;
            formSelectSheet.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtFile.Text = GetFilePath();
            CheckFile(txtFile.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadRecords_Click(object sender, EventArgs e)
        {

        }

        //private void btnLoadRecords_Click(object sender, EventArgs e)
        //{
        //    string sColumnHeader = "";
        //    string sInCollection = FSCYN.ParseColumnValues(ws, out sColumnHeader);
        //    string sQuery = "";

        //    if (radioJobs.Checked == true && radioOrderLines.Checked == false)
        //    {
        //        if (sColumnHeader == "Job#" || sColumnHeader.ToLower() == "job#")
        //            sQuery = FSCYN.GetQuery("Jobs", sInCollection);
        //        else
        //            InvalidExcelFile();
        //    }

        //    else if (radioJobs.Checked == false && radioOrderLines.Checked == true)
        //    {
        //        if (sColumnHeader == "PO#" || sColumnHeader.ToLower() == "po#")
        //            sQuery = FSCYN.GetQuery("OrderLines", sInCollection);
        //        else
        //            InvalidExcelFile();
        //    }
        //    else
        //        InvalidExcelFile();
        //}
    }
}

//private void FillDGVResultSet()
//{               
//    string sColumnHeader = "";
//    string sInCollection = FSCYN.ParseColumnValues(txtFile.Text, cbSheet.Text, out sColumnHeader);
//    string sQuery = "";
//    DataTable dt = new DataTable();
//    //DataGridView dgv = new DataGridView();

//    if (radioJobs.Checked == true && radioOrderLines.Checked == false)
//    {
//        if (sColumnHeader == "Job#" || sColumnHeader.ToLower() == "job#")
//        {
//            sQuery = FSCYN.GetQuery("Jobs", sInCollection);
//            dt = FSCYN.GetDataTable(sQuery);
//            dgvResultSetJob.Enabled = true;
//            dgvResultSetJob.DataSource = dt;
//            dgvResultSetJob.Visible = true;
//        }            
//        else
//            InvalidExcelFile();
//    }
//    else if (radioJobs.Checked == false && radioOrderLines.Checked == true)
//    {
//        if (sColumnHeader == "PO#" || sColumnHeader.ToLower() == "po#")
//        {
//            sQuery = FSCYN.GetQuery("OrderLines", sInCollection);
//            dt = FSCYN.GetDataTable(sQuery);
//            dgvResultSetOrderLines.Enabled = true;
//            dgvResultSetOrderLines.DataSource = dt;          
//            dgvResultSetOrderLines.Visible = true;
//        }                 
//        else
//            InvalidExcelFile();
//    }
//    else
//        InvalidExcelFile();

//    dgv.Enabled = true;
//    dgv.Visible = true;
//    //iWidth = dgv.Size.Width;
//    iHeight = dgv.Size.Height;
//    y = dgv.Location.Y + iHeight + 50;
//    btnRunUpdate.Location.Y = y;
//    btnExit.Location.Y = y;
//}