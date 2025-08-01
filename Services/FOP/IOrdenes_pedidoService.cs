using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MOTOR_WORKFLOW.Models;
using Web_Api_Contable.Entities.FOP;
using Web_Api_Contable.Models;

namespace Web_Api_Contable.Services.FOP

{
    public interface IOrdenes_pedidoService
    {

        public int insert(OrdenPedido obj, List<detalleOrdenPedido> detalleItems,Auditoria auditoria);
        public void update(int nroOrdenPedido, [FromBody] OrdenPedidoRequest request);
        public void delete(int nroOrdenPedido);
        public void anular(int nroOrdenPedido,[FromBody] Auditoria auditoria);
        public List<Ordenes_pedido> getOrdenByFecha(DateTime fechaDesde, DateTime fechaHasta, int tipoSeleccion);
        public List<HistorialOrdenDePedido> getHistorialByNro(int nroOrdenPedido);

    }
}

