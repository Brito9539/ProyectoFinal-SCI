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
using SCI.DesktopClient.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using SCI.Data;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para EntradasView.xaml
    /// </summary>
    public partial class EntradasView : UserControl
    {
        EntradaViewModel evm = new EntradaViewModel();
        List<entrada> entradas = new List<entrada>();

        public EntradasView()
        {
            InitializeComponent();
            DataContext = new EntradaViewModel();

            entradas = evm.context.context.entrada.ToList();

        }

        public void generarReporte()
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            int i = 2;

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            xlWorkSheet.Cells[1, 1] = "MatriculaUsuario";
            xlWorkSheet.Cells[1, 2] = "Articulo";
            xlWorkSheet.Cells[1, 3] = "MatriculaSolicitante";
            xlWorkSheet.Cells[1, 4] = "Hora";
            xlWorkSheet.Cells[1, 5] = "Fecha";
            xlWorkSheet.Cells[1, 6] = "Cantidad";

            foreach (var entrada in entradas)
            {
                xlWorkSheet.Cells[i, 1] = entrada.USUARIO_Matricula;
                xlWorkSheet.Cells[i, 2] = entrada.idProducto;
                xlWorkSheet.Cells[i, 3] = "15161602";
                xlWorkSheet.Cells[i, 4] = "7:30";
                xlWorkSheet.Cells[i, 5] = entrada.fecha;
                xlWorkSheet.Cells[i, 6] = entrada.cantidad;
                i++;
            }

            xlWorkBook.SaveAs("D:\\ReporteEntradas.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);


        }
    }
}
