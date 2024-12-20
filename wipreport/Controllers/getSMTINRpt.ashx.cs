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
    /// Descripción breve de getSMTINRpt
    /// </summary>
    public class getSMTIN : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            siixsem_wip_control_dbEntities m_db = new siixsem_wip_control_dbEntities();
            String pathReport = "";
            excel m_excel = new excel();
            String json = "{";
            CUtils utils = new CUtils();

            DataTable report = utils.ToDataTable(m_db.getSMTIN().ToList());

            String fileName = "WIP_SMT_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

            m_excel.write_fileOLE(report, fileName, context.Server.MapPath("~/Reports/SMT"), ref pathReport);
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