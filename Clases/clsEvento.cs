using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.WebPages.Instrumentation;

using Natillera.Models;

namespace Natillera.Clases
{
    public class clsEvento
    {
        private Examen_3_EventosEntities DBExamen3_eventos = new Examen_3_EventosEntities();

        public Evento evento { get; set; }

        public List<Evento> ListarEventos()
        {
            return DBExamen3_eventos.Eventos
                    .OrderBy(p => p.NombreEvento)
                    .ToList();
        }

        public Evento ConsultarxID(int id)
        {
            return DBExamen3_eventos.Eventos.FirstOrDefault(p => p.idEventos == id);
        }

        public List<Evento> Consultar_EventosxTipo(string tipo)
        {
            return DBExamen3_eventos.Eventos
                .Where(p => p.TipoEvento == tipo)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public List<Evento> Consultar_EventosxFecha(DateTime fecha)
        {
            return DBExamen3_eventos.Eventos
                .Where(p => p.FechaEvento == fecha)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public List<Evento> Consultar_EventosxNombre(string nombre)
        {
            return DBExamen3_eventos.Eventos
                .Where(p => p.NombreEvento == nombre)
                .OrderBy(p => p.NombreEvento)
                .ToList();
        }

        public string Insertar()
        {
            try
            {
                DBExamen3_eventos.Eventos.Add(evento);
                DBExamen3_eventos.SaveChanges();
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
                DBExamen3_eventos.Eventos.AddOrUpdate(evento);
                DBExamen3_eventos.SaveChanges();
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
                DBExamen3_eventos.Eventos.Remove(eve);
                DBExamen3_eventos.SaveChanges();
                return "Se eliminó exitosamente el evento";
            }
            catch (Exception)
            {
                return "Error al eliminar el evento";
            }
        }
    }
}