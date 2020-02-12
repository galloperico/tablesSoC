using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace tablesSoC
{
    public partial class Form1 : Form
    {
        string connString = @"Data Source=MXD64L17S2\SQLEXPRESS;Initial Catalog=displayGraphics;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlDataAdapter dataAdapter;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExportOpen_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Test Cases";

                for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                    {
                        worksheet.Cells[rowIndex + 1, colIndex + 1] =
                            dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    workbook.SaveAs(saveFileDialog1.FileName);
            //    Process.Start("excel.exe", saveFileDialog1.FileName);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetData("Select * from gauge_destination");

            string[] ignSt = { "0x4 (Run)", "0x8 (Start)" };
            string NotRdytoDrvMde = null;
            string SoCDisplayed = null;
            string SoCGuageDestFlag = null;
            string AmbientTheme = null;
            string Litval = null;
            string final = null;

            for (int rowIndex = 0; rowIndex <= 14; rowIndex++) //leer la base de datos
            {
                for (int colIndex = 1; colIndex < dataGridView2.Columns.Count; colIndex++) //colIndex = 1 ignore ID field
                {
                    switch (colIndex) //convertir a señales CAN
                    {
                        case 1:
                            if (dataGridView2[colIndex, rowIndex].Value.ToString() == "No")
                                NotRdytoDrvMde = "0x1 (On)";
                            else
                                NotRdytoDrvMde = "0x0 (Off)";
                            break;
                        case 2:
                            if (dataGridView2[colIndex, rowIndex].Value.ToString() != "Not Displayed")
                                SoCDisplayed = "0x0 (SelDrvMde01 Go)";
                            else
                                SoCDisplayed = "0x1 (SelDrvMde02 != Go)";
                            break;
                        case 3:
                            if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Flag")
                                SoCGuageDestFlag = "0x1 (Flag)";
                            else if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Home")
                                SoCGuageDestFlag = "0x3 (Home)";
                            else if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Work")
                                SoCGuageDestFlag = "0x4 (Work)";
                            else if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Charge Port")
                                SoCGuageDestFlag = "0x2 (Charge Port)";
                            else if (dataGridView2[colIndex, rowIndex].Value.ToString() == "None")
                                SoCGuageDestFlag = "0x0 (No Trip)";
                            else
                                SoCGuageDestFlag = "0x5 (Not Used)";
                            break;
                        case 4:
                            if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Light")
                            {
                                AmbientTheme = "0x1 (Auto Day)";
                                Litval = "0x0 (Night)";
                            }
                            else if (dataGridView2[colIndex, rowIndex].Value.ToString() == "Dark Night")
                            {
                                AmbientTheme = "0x2 (Auto Night)";
                                Litval = "0x3 (Twilight)";
                            }
                            else
                            {
                                AmbientTheme = "0x4 (Manual Night Bright)";
                                Litval = "0xFF (Invalid)";
                            }
                            break;
                    }
                }

                for (int k = 0; k < ignSt.Length; k++) //repetir el test case por cada power mode
                {
                    final += "*)" + " " + "Set VOPS Configuration" + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "Ignition_Status = " + ignSt[k] + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "PwPckTqRdy_B_Dsply = " + NotRdytoDrvMde + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "PwPckTqRdy_B_Dsply_UB = 0x1 (Fresh)" + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "ActvDrvMde_D2_Stat = " + SoCDisplayed + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "StopoverType_D_Stat = " + SoCGuageDestFlag + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "DrvDsplyPalette_D_Stat = " + AmbientTheme + "," + "\n";
                    final += "*)" + " " + "Send signal periodically: " + "Litval = " + Litval + "," + "\n";
                    final += "*)" + " " + "Populate results";
                }

                // this part up to the end could be outside of both for loops
                var countSt = final.Split(new char[] { '*' });
                int lines = countSt.Length / ignSt.Length; //it is repeated per power mode

                for (int i = 1; i < countSt.Length; i++)
                {
                    int m = (i - 1) / lines;
                    int n = i - (lines * m);
                    countSt[i] = $"{n}" + countSt[i];

                    if ((n - 1) % lines == 0)
                        dataGridView1.Rows.Add(); //create a new row in the datagrid every lines lines
                }

                for (int j = dataGridView1.Rows.Count - 3; j < dataGridView1.Rows.Count - 1; j++) //must play with row numbers
                { 
                    if (j % 2 == 0) //separate the string array in two, maybe I should have used substring or slice
                    {
                        for (int i = 1; i < (countSt.Length / 2) + 1; i++)
                        {
                            dataGridView1[1, j].Value += countSt[i];
                            dataGridView1[0, j].Value = j;
                        }
                    }
                    else
                    {
                        for (int i = (countSt.Length / 2) + 1; i < countSt.Length; i++)
                        {
                            dataGridView1[1, j].Value += countSt[i];
                            dataGridView1[0, j].Value = j;
                        }
                    }
                }
                final = ""; // this is not necessary, the end 
            }
        }

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, connString);
                table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
