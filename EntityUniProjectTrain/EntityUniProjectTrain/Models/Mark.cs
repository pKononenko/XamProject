using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityUniProjectTrain
{
    [Table(name: "Mark")]
    public class Mark
    {
        public Mark()
        { }

        [Key]
        [DataType("int")]
        [Column(name: "MarkId")]
        public int MarkId { get; set; }

        [Required]
        [DataType("varchar2")]
        [Column(name: "MarkType")]
        public string MarkType { get; set; }

        [Required]
        [DataType("varchar2")]
        [Column(name: "MarkTitle")]
        public string MarkTitle { get; set; }

        [DataType("varchar2")]
        [Column(name: "MarkText")]
        public string MarkText { get; set; }

        [DataType("varchar2")]
        [Column(name: "Sym")]
        public string Sym { get; set; }

        public virtual ICollection<NotationMark> NotationMark { get; set; }
    }
}
