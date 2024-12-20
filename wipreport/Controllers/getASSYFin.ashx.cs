using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using wipreport.Class;
using wipreport.Models;

namespace wipreport.Controllers
{
    /// <summary>
    /// Descripción breve de getASSYFin
    /// </summary>
    public class getASSYFin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            siixsem_stocktake_dbEntities m_db = new siixsem_stocktake_dbEntities();
            String pathReport = "";
            excel m_excel = new excel();
            String json = "{";
            CUtils utils = new CUtils();

            DataTable report = utils.ToDataTable(m_db.getAssyFin().ToList());

            String fileName = "WIP_ASSY_FIN_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

            m_excel.write_fileOLEFinAssy(report, fileName, context.Server.MapPath("~/Reports/FINANCE/ASSY"), ref pathReport);
            json += "\"result\":\"true\",";
            json += "\"html\":\"" + fileName + "\"";
            json += "}";
            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}