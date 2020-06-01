using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityUniProjectTrain
{
    [Table(name: "NotationMark")]
    public class NotationMark
    {
        public NotationMark()
        { }

        [Key]
        [DataType("int")]
        [Column(name: "MarkId")]
        public int MarkId { get; set; }

        [Key]
        [DataType("int")]
        [Column(name: "NotationId")]
        public int NotationId { get; set; }

        // FK
        [ForeignKey(name: "MarkId")]
        public virtual Mark Mark { get; set; }

        [ForeignKey(name: "NotationId")]
        public virtual Notation Notation { get; set; }
    }
}
