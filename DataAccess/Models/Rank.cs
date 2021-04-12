using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Comment("Displayed name of the rank"), MaxLength(20), Required]

        #nullable enable
        public string? Name { get; set; }
        [Comment("Base64 picture of the rank, can be nullable"), /*Required*/]
        public string? Picture { get; set; }
        [Comment("Students of the group, can be nullable"), /*Required*/]
        public List<Student>? Students { get; set; }
    }
}
