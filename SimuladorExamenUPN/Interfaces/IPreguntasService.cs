using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface IPreguntasService
    {
        Pregunta GetPreguntaById(int PreguntaId);
        List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas);
        void GuardarPreguntas(Examen examen, List<Pregunta> preguntas);
        void CrearPregunta(Pregunta pregunta);
        void EditarPregunta(Pregunta pregunta);
        void EliminarPregunta(int PreguntaId);
    }
}
