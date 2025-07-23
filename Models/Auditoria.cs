﻿namespace Web_Api_Contable.Models
{
    public class Auditoria
    {
        public int id_auditoria { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public string proceso { get; set; }
        public string identificacion { get; set; }
        public string autorizaciones { get; set; }
        public string observaciones { get; set; }
        public string detalle { get; set; }
        public string ip { get; set; }
        public Auditoria()
        {
            id_auditoria = 0;
            fecha = DateTime.MinValue;
            usuario = string.Empty;
            proceso = string.Empty;
            identificacion = string.Empty;
            autorizaciones = string.Empty;
            observaciones = string.Empty;
            detalle = string.Empty;
            ip = string.Empty;
        }
        
    }
}
