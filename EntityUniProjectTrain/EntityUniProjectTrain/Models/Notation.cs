using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityUniProjectTrain
{
    [Table(name:"Notations")]
    public class Notation
    {
        public Notation()
        { }

        [Key]
        [DataType("int")]
        [Column(name:"NotationId")]
        public int NotationId { get; set; }

        [Required]
        [DataType("varchar2")]
        [Column(name: "NotationType")]
        public string NotationType { get; set; }

        [Required]
        [DataType("datetime")]
        [Column(name: "DateOfCreation")]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [Required]
        [DataType("varchar2")]
        [Column(name: "NotationName")]
        public string NotationName { get; set; }

        [DataType("varchar2")]
        [Column(name: "Deadline")]
        public DateTime Deadline { get; set; }

        [DataType("varchar2")]
        [Column(name: "CompletedBool")]
        public bool CompletedBool { get; set; }

        [DataType("varchar2")]
        [Column(name: "NotationText")]
        public string NotationText { get; set; }

        public virtual ICollection<NotationMark> NotationMark { get; set; }
    }
}
