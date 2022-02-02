using MangaOYomu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp
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

        private void btnToExcel_Click(object sender, RoutedEventArgs e)
        {
            var allTitles = DataAccess.GetMangaTitles().OrderBy(p => p.Name).ToList();

            var app = new Excel.Application();

            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = app.Worksheets.Item[1];
            worksheet.Name = "Titles";

            int startRowIndex = 1;

            worksheet.Cells[1][startRowIndex] = "Название";
            worksheet.Cells[2][startRowIndex] = "Описание";
            for (int i = 0; i < allTitles.Count(); i++)
            {
                startRowIndex++;

                worksheet.Cells[1][startRowIndex] = allTitles[i].Name;
                worksheet.Cells[2][startRowIndex] = allTitles[i].Description;

            }

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }

        private void btnToWord_Click(object sender, RoutedEventArgs e)
        {
            var allTitles = DataAccess.GetMangaTitles().OrderBy(p => p.Name).ToList();

            var app = new Word.Application();
            Word.Document document = app.Documents.Add();

            var tabParagraph = document.Paragraphs.Add();
            Word.Range tabRange = tabParagraph.Range;

            Word.Table table = document.Tables.Add(tabRange, allTitles.Count, 2);
            table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            for (int i = 0; i < allTitles.Count; i++)
            {
                var cellRange = table.Cell(i + 1, 1).Range;
                cellRange.Text = allTitles[i].Name;

                cellRange = table.Cell(i + 1, 2).Range;
                cellRange.Text = allTitles[i].Description;
            }

            app.Visible = true;
        }
    }
}
