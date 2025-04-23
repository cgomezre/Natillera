using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.WebPages.Instrumentation;

using Examen3.Models;

namespace Examen3.Clases
{
    public class clsEvento
    {
        private NATILLERAEntities bdNatilla = new NATILLERAEntities();

        public Evento evento { get; set; }

        public List<Evento> ListarEventos()
        {
            return bdNatilla.Eventos
                    .OrderBy(p => p.NombreEvento)
                    .ToList();
        }

        public Evento ConsultarxID(int id)
        {
            return bdNatilla.Eventos.FirstOrDefault(p => p.idEventos == id);
        }

        public List<Evento> Consultar_EventosxTipo(string tipo)
        {
            return bdNatilla.Eventos
                .Where(p => p.TipoEvento == tipo)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public List<Evento> Consultar_EventosxFecha(DateTime fecha)
        {
            return bdNatilla.Eventos
                .Where(p => p.FechaEvento == fecha)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public List<Evento> Consultar_EventosxNombre(string nombre)
        {
            return bdNatilla.Eventos
                .Where(p => p.NombreEvento == nombre)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public string Insertar()
        {
            try
            {
                bdNatilla.Eventos.Add(evento);
                bdNatilla.SaveChanges();
                return "Se agrego exitosamente el evento con nombre: " + evento.NombreEvento + " y id: " + evento.idEventos;
            }
            catch (Exception ex)
            {
                return "Error al agregar el evento. El error es:" + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Evento eve = ConsultarxID(evento.idEventos);
                if (eve == null)
                {
                    return "El evento no existe";
                }
                bdNatilla.Eventos.AddOrUpdate(evento);
                bdNatilla.SaveChanges();
                return "Se actualizo exitosamente el evento con ID: " + evento.idEventos;
            }
            catch (Exception)
            {
                return "Error al actualizar el evento con ID: " + evento.idEventos;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                Evento eve = ConsultarxID(id);
                if (eve == null)
                {
                    return "El evento no existe";
                }
                bdNatilla.Eventos.Remove(eve);
                bdNatilla.SaveChanges();
                return "Se eliminó exitosamente el evento";
            }
            catch (Exception)
            {
                return "Error al eliminar el evento";
            }
        }
    }
}