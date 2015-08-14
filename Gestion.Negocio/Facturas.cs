﻿using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Gestion.Negocio
{
    public class Facturas
    {
        public static int Add(Factura entity)
        {
            int factura_id = 0;
            bool resultado = true;

            try
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    IFacturaRepository _repository = new FacturaRepository();
                    factura_id = _repository.Add(entity);

                    if(factura_id > 0)
                    {
                        foreach(var row in entity.alicuotas)
                        {
                            row.factura_id = factura_id;

                            int res = FacturasAlicuotas.Add(row);
                            if(res == 0)
                            {
                                resultado = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        resultado = false;
                    }

                    if (resultado == true)
                        scope.Complete();
                                            
                }
    
            }
            catch(Exception e)
            {
                
                throw e;
            }

            return factura_id;
        }


        public static IEnumerable<Factura> FindAll()
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static int UpdateComprobanteAfip(Factura factura)
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.UpdateComprobanteAfip(factura);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static Factura FindById(int id)
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
