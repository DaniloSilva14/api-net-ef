﻿using System.ComponentModel.DataAnnotations;
using Model = FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
