using System;
using System.Linq;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Exel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            if (excel == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Workbook workbook = excel.Workbooks.Open(txtFileName.Text);
            Worksheet worksheet = workbook.ActiveSheet;

            Range range = worksheet.UsedRange;

            for (int row = 1; row <= range.Rows.Count; row++)
            {
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    string cellValue = range.Cells[row, col].Value.ToString();

                    if (cellValue != null)
                    {
                        txtOutput.Text += cellValue + "\t";
                    }
                }

                txtOutput.Text += "\r\n";
            }

            workbook.Close();
            excel.Quit();
        }

        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            if (excel == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Workbook workbook = excel.Workbooks.Open(txtFileName.Text);
            Worksheet worksheet = workbook.ActiveSheet;

            string[] lines = txtInput.Text.Split('\n').Select(x => x.Trim()).ToArray();

            for (int row = 0; row < lines.Length; row++)
            {
                string[] cells = lines[row].Split('\t').Select(x => x.Trim()).ToArray();

                for (int col = 0; col < cells.Length; col++)
                {
                    worksheet.Cells[row + 1, col + 1] = cells[col];
                }
            }

            workbook.Save();
            workbook.Close();
            excel.Quit();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }
    }

}

