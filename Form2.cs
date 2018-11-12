using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.gridControl1.RowCount = 15;
            this.gridControl1.ColCount = 6;
            gridControl1.RowCount = 100;
            gridControl1.ColCount = 11;
            this.gridControl1.DefaultRowHeight = 30;
            CreateTable();
            for (int i = 1; i <= this.gridControl1.RowCount; i++)
            {
                for (int j = 1; j <= this.gridControl1.ColCount; j++)
                {
                    this.gridControl1[i, j].CellValue = dt.Rows[i - 1][j - 1];
                }
            }
            for (int i = 1; i <= gridControl1.RowCount; i++)
            {
                gridControl1[i, 3].CellType = GridCellTypeName.PushButton;
            }
            for (int i = 1; i <= gridControl1.RowCount; i++)
            {
                gridControl1[i, 7].CellType = GridCellTypeName.PushButton;
            }
            //Event triggering
            this.gridControl1.DrawCellButton += GridControl1_DrawCellButton;
        }

        private void GridControl1_DrawCellButton(object sender, GridDrawCellButtonEventArgs e)
        {
            if (e.Style.CellType == GridCellTypeName.PushButton)
            {
                Bitmap bitmap = new Bitmap(30, 20);
                Rectangle rect = e.Button.Bounds;
                if (e.ColIndex == 3)
                {
                    bitmap = new Bitmap(SystemIcons.Error.ToBitmap(), new Size(30, 25));
                }
                if (e.ColIndex == 7)
                {
                    bitmap = new Bitmap(SystemIcons.Exclamation.ToBitmap(), new Size(20, 20));
                }
                e.Graphics.DrawImage(bitmap, rect.X + 30, rect.Y, bitmap.Width, bitmap.Height);
                e.Cancel = true;
            }
        }
        #region "Create DataTable"
        string[] name1 = new string[] { "John", "Peter", "Smith", "Jay", "Krish", "Mike" };
        string[] country = new string[] { "UK", "USA", "Pune", "India", "China", "England" };
        string[] city = new string[] { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" };
        string[] scountry = new string[] { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" };
        DataTable dt = new DataTable();
        Random r = new Random();
        int col = 0;
        private DataTable CreateTable()
        {
            if (col == 0)
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("Id");
                dt.Columns.Add("Date");
                dt.Columns.Add("Country");
                dt.Columns.Add("Ship City");
                dt.Columns.Add("Ship Country");
                dt.Columns.Add("Freight");
                dt.Columns.Add("Postal code");
                dt.Columns.Add("Salary");
                dt.Columns.Add("PF");
                dt.Columns.Add("EMI");
            }
            for (int l = 0; l < dt.Columns.Count; l++)

                for (int i = 0; i < this.gridControl1.RowCount; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < this.gridControl1.ColCount; j++)
                    {
                        dr[0] = name1[r.Next(0, 5)];
                        dr[1] = "E" + r.Next(30);
                        dr[2] = new DateTime(2012, 5, 23);
                        dr[3] = country[r.Next(0, 5)];
                        dr[4] = city[r.Next(0, 5)];
                        dr[5] = scountry[r.Next(0, 5)];
                        dr[6] = r.Next(1000, 2000);
                        dr[7] = r.Next(10 + (r.Next(600000, 600100)));
                        dr[8] = r.Next(14000, 20000);
                        dr[9] = r.Next(r.Next(2000, 4000));
                        dr[10] = r.Next(300, 1000);
                    }
                    dt.Rows.Add(dr);
                }
            return dt;
        }
        #endregion
    }
}

