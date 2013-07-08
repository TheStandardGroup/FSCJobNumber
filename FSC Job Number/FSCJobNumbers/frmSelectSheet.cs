using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Text;
using System.Windows.Forms;

namespace FSCJobNumbers
{
    public partial class frmSelectSheet : Form
    {
        //static private System.Windows.Forms.Cursor frmCursor;
        public Workbook wb;

        public frmSelectSheet()
        {
            InitializeComponent();       
        }

        private void frmSelectSheet_Load(object sender, EventArgs e)
        {
            //frmCursor = System.Windows.Forms.Cursors.Default;
            lvSheets.MouseDoubleClick += new MouseEventHandler(lvSheets_MouseDoubleClick);
            lvSheets.TabIndex = 1;
            btnSelect.TabIndex = 2;
            SelectSheets();
            lvSheets.Focus();
            this.BackColor = Color.FromArgb(28, 63, 119);
            this.ForeColor = Color.White;
            frmMain.setButtonColor(btnSelect);
        }

        void lvSheets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSheets.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection selectedItems = lvSheets.SelectedItems;
                frmMain.sSelectedSheet = selectedItems[0].Text;               
                this.Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvSheets.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection selectedItems = lvSheets.SelectedItems;
                frmMain.sSelectedSheet = selectedItems[0].Text;
                this.Close();
            }
        }

        private void SelectSheets()
        {
            lvSheets.MultiSelect = false;
            ListViewItem[] lvItem = new ListViewItem[wb.Worksheets.Count];

            if (wb.Worksheets.Count > 0)
            {
                for (int i = 0; i < wb.Worksheets.Count; i++)
                {
                    try
                    {
                        Worksheet ws = (Worksheet)wb.Worksheets[i + 1];
                        lvItem[i] = new ListViewItem();
                        lvItem[i].Text = ws.Name;
                        lvItem[i].Tag = (object)i.ToString();
                        lvSheets.Items.Add(lvItem[i]);
                    }
                    catch(Exception ex)
                    {
                    }
                }
            }
        }
    }
}
