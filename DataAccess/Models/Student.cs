using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.DataAccess.Models
{
    [Table("Student")]
    public class Student
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Comment("First name of the user"), MaxLength(20), Required]
        public string Name { get; set; } = "Имя";

        [Comment("Short description of the user, cant be nullable"), Required, MaxLength(250)]
        public string About { get; set; } = "Описание";

        [Comment("Group of the user, cant be nullable"), Required]
        public Group Group { get; set; }
        
        #nullable enable
        [Comment("Second name of the user"), MaxLength(20), /*Required*/]
        public string? SecondName { get; set; }
        [Comment("Base64 picture of the user, can be nullable"), /*Required*/]
        public string? Picture { get; set; }

        [Comment("Rank of the user, cant be nullable"), /*Required*/]
        public Rank? Rank { get; set; }


    }
}
