using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace TorontoRiskAPI.Models
{
    [Table("schools")]
    public class School
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("website")]
        public string? Website { get; set; }

        [Column("addr:street")]
        public string? AddrStreet { get; set; }

        [Column("at_risk")]
        public bool AtRisk { get; set; }

        [Column("geometry")]
        public Point? Geometry { get; set; }
    }
}
