using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PagoDAL
    {
        public static int GenerarPagoEfectivo(int disco, string email, decimal monto, DetallePagoEfectivo detalle)
        {
            Pago pago = new Pago();
            using (FunClubEntities db = new FunClubEntities())
            {
                int codpago = db.Pagoes.ToList().Count > 0 ? db.Pagoes.Max(a => a.CodPago) + 1 : 1;
                pago.CodPago = codpago;
                pago.Estado = "1";
                pago.FechaAlta = DateTime.Now;
                pago.FechaPago = DateTime.Now;
                pago.TerminalAlta = "1";
                pago.Monto = monto;
                pago.DetallePagoEfectivoes = new List<DetallePagoEfectivo>();
                pago.DetallePagoEfectivoes.Add(detalle);

                db.Pagoes.Add(pago);

                db.SaveChanges();

                return pago.CodPago;

            }
        }

        public static int GenerarPagoTarjetaDebito(int disco, string email, decimal monto, DetallePagoTarjetaDebito detalle)
        {
            Pago pago = new Pago();
            using (FunClubEntities db = new FunClubEntities())
            {
                int codpago = db.Pagoes.ToList().Count > 0 ? db.Pagoes.Max(a => a.CodPago) + 1 : 1;
                pago.CodPago = codpago;
                pago.Estado = "1";
                pago.FechaAlta = DateTime.Now;
                pago.FechaPago = DateTime.Now;
                pago.TerminalAlta = "1";
                pago.Monto = monto;
                pago.DetallePagoTarjetaDebitoes = new List<DetallePagoTarjetaDebito>();
                pago.DetallePagoTarjetaDebitoes.Add(detalle);

                db.Pagoes.Add(pago);

                db.SaveChanges();

                return pago.CodPago;

            }
        }

            public static int GenerarPagoTarjetaCredito(int disco, string email, decimal monto, DetallePagoTarjetaCredito detalle)
            {
                Pago pago = new Pago();
                using (FunClubEntities db = new FunClubEntities())
                {
                    int codpago = db.Pagoes.ToList().Count > 0 ? db.Pagoes.Max(a => a.CodPago) + 1 : 1;
                    pago.CodPago = codpago;
                    pago.Estado = "1";
                    pago.FechaAlta = DateTime.Now;
                    pago.FechaPago = DateTime.Now;
                    pago.TerminalAlta = "1";
                    pago.Monto = monto;
                    pago.DetallePagoTarjetaCreditoes = new List<DetallePagoTarjetaCredito>();
                    pago.DetallePagoTarjetaCreditoes.Add(detalle);

                    db.Pagoes.Add(pago);

                    db.SaveChanges();

                    return pago.CodPago;

                }


            }
        }

    }
    
