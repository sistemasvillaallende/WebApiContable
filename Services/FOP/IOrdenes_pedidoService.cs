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
        public List<Ordenes_pedido> read();
        public Ordenes_pedido getByPk(int Nro_orden_pedido);
        public int insert(OrdenPedido obj, List<detalleOrdenPedido> detalleItems,Auditoria auditoria);
        public void update(int nroOrdenPedido, [FromBody] OrdenPedidoRequest request);
        public void delete(int nroOrdenPedido);
        public List<Ordenes_pedido> readOrdenesByProveedor(int cod_proveedor);
        public List<Ordenes_pedido> readOrdenesByCuit(string cuit);
    }
}

