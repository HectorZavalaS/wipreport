//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wipreport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_ASSY_FIN_RPT
    {
        public string SCANED_SERIAL { get; set; }
        public string MODEL { get; set; }
        public string ROUTE { get; set; }
        public string DJ_GROUP { get; set; }
        public int QTY { get; set; }
        public string SEMIFINISH { get; set; }
        public string TYPE { get; set; }
        public string QR { get; set; }
        public string USER_READ { get; set; }
        public string QUARANTINE { get; set; }
        public string VALIDATED_BY_QA { get; set; }
        public string USER_VALIDATE { get; set; }
        public Nullable<System.DateTime> DATE_VALIDATED { get; set; }
        public string STATUS { get; set; }
        public System.DateTime DATE_IN { get; set; }
        public Nullable<System.DateTime> DATE_OUT { get; set; }
        public string VALIDATED_BY_FIN { get; set; }
        public string FIN_USER { get; set; }
        public Nullable<int> FIN_QTY { get; set; }
        public Nullable<System.DateTime> FIN_DATE_VALIDATED { get; set; }
    }
}
