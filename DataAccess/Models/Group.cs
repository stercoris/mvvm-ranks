using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Group")]
    public class Group
    {
        [Key] public int Id { get; set; }

        [Comment("Displayable name of group"),                          Required, MaxLength(15)]
        public string Name { get; set; } = "Новая группа";
        [Comment("Short description of the group, cant be nullable"),   Required, MaxLength(250)]
        public string About { get; set; } = "Описание";
        [Comment("Short description of the group, cant be nullable"), Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        #nullable enable
        [Comment("Displayable picture"), /*Required*/]
        public string? Picture { get; set; }
        [Comment("Students of this group"), /*Required*/]
        public List<Student>? Students { get; set; }
    }
}
