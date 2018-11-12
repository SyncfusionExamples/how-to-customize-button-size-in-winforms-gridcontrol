using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Grouping;


namespace DataGrid
{
    public partial class Form1 : Form
    {
        DataCollection dataSource;
        public Form1()
        {
            InitializeComponent();

            this.gridGroupingControl1.ShowGroupDropArea = false;
            this.gridGroupingControl1.AllowProportionalColumnSizing = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;

            #region DataSource
            dataSource = new DataCollection();
            Random rand = new Random();
            int r = rand.Next(100);
            for (int i = 0; i < 100; i++)
            {
                dataSource.Add(new Data(r.ToString(), "Category" + r.ToString(), "Desc" + r.ToString(), r.ToString() + "Data", "Value" + r.ToString(), "Name" + i.ToString(),""));
                r = rand.Next(100);
            }
            this.gridGroupingControl1.DataSource = dataSource;
            #endregion

            //this.gridGroupingControl1.TableDescriptor.Columns.Add("PushButton");
            this.gridGroupingControl1.TableDescriptor.Columns["Edit"].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.PushButton;
            this.gridGroupingControl1.TableDescriptor.Columns["Delete"].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.PushButton;

            //Event Triggering
            this.gridGroupingControl1.TableControl.DrawCellButton += TableControl_DrawCellButton;
            
        }        
        //Event Customization
        private void TableControl_DrawCellButton(object sender, GridDrawCellButtonEventArgs e)
        {
            if (e.Style.CellType == GridCellTypeName.PushButton)
            {
                Bitmap bitmap = new Bitmap(30,20);
                Rectangle rect = e.Button.Bounds;
                //To get the column name of the cell
                string columnName = (e.Style as GridTableCellStyleInfo).TableCellIdentity.Column.Name;
                if (columnName == "Edit")
                {
                    //To set size for the image
                    bitmap = new Bitmap(SystemIcons.Error.ToBitmap(), new Size(40, 20));
                }
                else if (columnName == "Delete")
                {
                    //To set size for the image
                    bitmap = new Bitmap(SystemIcons.Exclamation.ToBitmap(), new Size(20, 20));
                }
                //To draw image with its fixed size
                e.Graphics.DrawImage(bitmap, rect.X + 30, rect.Y, bitmap.Width, bitmap.Height);
                e.Cancel = true;
            }
        }
    }
}

