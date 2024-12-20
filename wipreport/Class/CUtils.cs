using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace wipreport.Class
{
    public class CUtils
    {
        private excel m_excel;

        public CUtils()
        {

        }
        public bool getHTMLFromFile(String ruta, ref String html, ref string info)
        {
            DataTable tmp, dthoja;
            int periodo = 0, diasAcum = 0;
            String fecha_i_periodo, fecha_f_periodo, fecha_i_incid, fecha_f_incid, fecha_lim;
            html = "";
            //String html

            bool result = false;

            m_excel = new excel(ruta);
            m_excel.loadBookExcel();
            tmp = m_excel.Book;
            foreach (DataRow hoja in tmp.Rows)
            {
                dthoja = m_excel.ReadSheet(Convert.ToString(hoja["TABLE_NAME"]));
                if (dthoja.Rows.Count > 0)
                {
                    int i = 0;
                    html = "<table class='layout'>";
                    foreach (DataRow fila in dthoja.Rows)
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString(fila[0])) && !String.IsNullOrEmpty(Convert.ToString(fila[1])) && !String.IsNullOrEmpty(Convert.ToString(fila[2])))
                            {
                                periodo = Convert.ToInt32(fila[0]);
                                fecha_i_periodo = Convert.ToString(fila[1]);
                                fecha_f_periodo = Convert.ToString(fila[2]);
                                diasAcum = Convert.ToInt32(fila[5]);
                                fecha_i_incid = Convert.ToString(fila[6]);
                                fecha_f_incid = Convert.ToString(fila[7]);
                                fecha_lim = Convert.ToString(fila[8]);

                            }
                        }
                        catch (Exception ex)
                        {
                            result = false;
                            info = ex.Message + " - " + ex.InnerException;
                        }
                        i++;
                    }
                    if (i == dthoja.Rows.Count) result = true;
                }
            }
            return result;
        }
        public bool createDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return false;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ocurrio un error al crear el directorio:" + e.Message);
                return false;
            }
            finally { }
            return true;
        }
        public void translateM(ref String month)
        {
            month = month.Replace("January", "Enero");
            month = month.Replace("February", "Febrero");
            month = month.Replace("March", "Marzo");
            month = month.Replace("April", "Abril");
            month = month.Replace("May", "Mayo");
            month = month.Replace("June", "Junio");
            month = month.Replace("July", "Julio");
            month = month.Replace("August", "Agosto");
            month = month.Replace("September", "Septiembre");
            month = month.Replace("October", "Octubre");
            month = month.Replace("November", "Noviembre");
            month = month.Replace("December", "Diciembre");
            month = month.Replace("01", "Enero");
            month = month.Replace("02", "Febrero");
            month = month.Replace("03", "Marzo");
            month = month.Replace("04", "Abril");
            month = month.Replace("05", "Mayo");
            month = month.Replace("06", "Junio");
            month = month.Replace("07", "Julio");
            month = month.Replace("08", "Agosto");
            month = month.Replace("09", "Septiembre");
            month = month.Replace("10", "Octubre");
            month = month.Replace("11", "Noviembre");
            month = month.Replace("12", "Diciembre");
            month = month.Replace("1", "Enero");
            month = month.Replace("2", "Febrero");
            month = month.Replace("3", "Marzo");
            month = month.Replace("4", "Abril");
            month = month.Replace("5", "Mayo");
            month = month.Replace("6", "Junio");
            month = month.Replace("7", "Julio");
            month = month.Replace("8", "Agosto");
            month = month.Replace("9", "Septiembre");
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //String fieldName = prop.Name.Replace("_", " ");
                //int r = 0;
                //try
                //{
                //    if(int.TryParse(fieldName.ElementAt(fieldName.Length-1).ToString(), out r))
                //        fieldName = fieldName.Substring(0, fieldName.Length - 1);
                //}
                //catch (Exception ex) { }
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public String getASSYstatement()
        {
            return "SELECT [Extent1].[LOCATOR] AS[LOCATOR], [Extent1].[MAGAZINE] AS[MAGAZINE], [Extent1].[SCANED_SERIAL] AS[SCANED_SERIAL], [Extent1].[MODEL] AS[MODEL]," +
                   "[Extent1].[ROUTE] AS[ROUTE], [Extent1].[DJ_GROUP] AS[DJ_GROUP], [Extent1].[QTY] AS[QTY], [Extent1].[SEMIFINISH] AS[SEMIFINISH], [Extent1].[REVIEW] AS[REVIEW], " +
                   "[Extent1].[TYPE] AS[TYPE], [Extent1].[QR] AS[QR], [Extent1].[USER_READ] AS[USER_READ], [Extent1].[QUARANTINE] AS[QUARANTINE], [Extent1].[VALIDATED_BY_QA] AS[VALIDATED_BY_QA], " +
                   "[Extent1].[USER_VALIDATE] AS[USER_VALIDATE], [Extent1].[DATE_VALIDATED] AS[DATE_VALIDATED], [Extent1].[STATUS] AS[STATUS], [Extent1].[DATE_IN] AS[DATE_IN], " +
                   "[Extent1].[DATE_OUT] AS[DATE_OUT] " +
                   "FROM(SELECT " +
                   "[WIP_RPT].[LOCATOR] AS[LOCATOR], [WIP_RPT].[MAGAZINE] AS[MAGAZINE], [WIP_RPT].[SCANED_SERIAL] AS[SCANED_SERIAL], [WIP_RPT].[MODEL] AS[MODEL], " +
                   "[WIP_RPT].[ROUTE] AS[ROUTE], [WIP_RPT].[DJ_GROUP] AS[DJ_GROUP], [WIP_RPT].[QTY] AS[QTY], [WIP_RPT].[SEMIFINISH] AS[SEMIFINISH], [WIP_RPT].[REVIEW] AS[REVIEW], " +
                   "[WIP_RPT].[TYPE] AS[TYPE], [WIP_RPT].[QR] AS[QR], [WIP_RPT].[USER_READ] AS[USER_READ], [WIP_RPT].[QUARANTINE] AS[QUARANTINE], " +
                   "[WIP_RPT].[VALIDATED_BY_QA] AS[VALIDATED_BY_QA], [WIP_RPT].[USER_VALIDATE] AS[USER_VALIDATE], [WIP_RPT].[DATE_VALIDATED] AS[DATE_VALIDATED], " +
                   "[WIP_RPT].[STATUS] AS[STATUS], [WIP_RPT].[DATE_IN] AS[DATE_IN], [WIP_RPT].[DATE_OUT] AS[DATE_OUT]" +
                   "FROM[dbo].[WIP_RPT] AS[WIP_RPT]) AS[Extent1]";
        }

    }
}