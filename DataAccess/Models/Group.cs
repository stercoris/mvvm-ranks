﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "Новая группа";
        public string Picture { get; set; }
        public string About { get; set; } = "Описание";
        public DateTime Birthday { get; set; }
        public List<Student> Students { get; set; }
    }
}
