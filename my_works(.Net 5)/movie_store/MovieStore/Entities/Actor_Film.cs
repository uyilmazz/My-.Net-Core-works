using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{

    public class Actor_Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}