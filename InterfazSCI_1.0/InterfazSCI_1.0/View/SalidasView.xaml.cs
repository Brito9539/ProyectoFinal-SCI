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
using SCI.Data;
using SCI.DesktopClient.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para SalidasView.xaml
    /// </summary>
    public partial class SalidasView : UserControl
    {

        SalidaViewModel svm = new SalidaViewModel();
        producto articulo = new producto();
        List<salida> salidas = new List<salida>();

        public SalidasView()
        {
            InitializeComponent();

            salidas = svm.context.context.salida.ToList();
        }


        public void generarReporte()
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            int i = 2;

            salida salidaaux = new salida();

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
            //usu = uvm.context.context.usuario.Where(u => u.Matricula == txtMatri.Text).FirstOrDefault();
            foreach (var salida in salidas)
            {
                xlWorkSheet.Cells[i, 1] = salida.USUARIO_Matricula;
                articulo = svm.context.context.producto.Where(s => s.idProducto == salida.PRODUCTO_idProducto).FirstOrDefault();
                xlWorkSheet.Cells[i, 2] = articulo.Nombre;
                xlWorkSheet.Cells[i, 3] = salida.USUARIO_Matricula1;
                xlWorkSheet.Cells[i, 4] = "7:30";
                xlWorkSheet.Cells[i, 5] = salida.fecha;
                xlWorkSheet.Cells[i, 6] = salida.cantidad;
                i++;
            }

            xlWorkBook.SaveAs("F:\\ReporteSalidas.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);


        }

        private void BtnGenerarReporte_Click_1(object sender, RoutedEventArgs e)
        {
            generarReporte();
        }
    }
}