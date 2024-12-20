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
    /// Descripción breve de getAssyInRpt
    /// </summary>
    public class getAssyInRpt : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            siixsem_wip_assy_ctrl_dbEntities m_db = new siixsem_wip_assy_ctrl_dbEntities();
            String pathReport = "";
            excel m_excel = new excel();
            String json = "{";
            CUtils utils = new CUtils();
            String querySQL = utils.getASSYstatement();
            List<WIP_RPT> list = m_db.Database.SqlQuery<WIP_RPT>(querySQL).ToList();

            DataTable report = utils.ToDataTable(list.ToList());

            String fileName = "WIP_ASSY_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

            m_excel.write_fileOLE(report, fileName, context.Server.MapPath("~/Reports/ASSY"), ref pathReport);
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