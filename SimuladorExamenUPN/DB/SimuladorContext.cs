﻿using SimuladorExamenUPN.DB.Maps;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.DB
{
    public class SimuladorContext : DbContext
    {
        public virtual IDbSet<Tema> Temas { get; set; }
        public virtual IDbSet<Pregunta> Preguntas { get; set; }
        public virtual IDbSet<Alternativa> Alternativas { get; set; }
        public virtual IDbSet<Categoria> Categorias { get; set; }
        public virtual IDbSet<Examen> Examenes { get; set; }
        public virtual IDbSet<ExamenPregunta> ExamenPreguntas { get; set; }
        public virtual IDbSet<TemaCategoria> TemaCategorias{ get; set; }
        public virtual IDbSet<Usuario> Usuarios { get; set; }

        public SimuladorContext()
        {
            Database.SetInitializer<SimuladorContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TemaMap());
            modelBuilder.Configurations.Add(new PreguntaMap());
            modelBuilder.Configurations.Add(new AlternativaMap());            
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new ExamenMap());
            modelBuilder.Configurations.Add(new ExamenPreguntaMap());
            modelBuilder.Configurations.Add(new TemaCategoriaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}