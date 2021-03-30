﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public List<Student> Students { get; set; }
    }
}
