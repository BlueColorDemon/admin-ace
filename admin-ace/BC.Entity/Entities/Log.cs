namespace BC.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Desc { get; set; }

        [Column(TypeName = "text")]
        public string Data { get; set; }

        public int? UserId { get; set; }

        public DateTime Time { get; set; }

        public virtual User User { get; set; }
    }
}
