using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{

    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public double Price { get; set; }

        public List<Actor_Film> Actor_Films { get; set; }
    }
}