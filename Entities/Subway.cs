using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace TorontoRiskAPI.Models
{
    [Table("subways")]
    public class Subway
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("network")]
        public string? Network { get; set; }

        [Column("addr:street")]
        public string? AddrStreet { get; set; }

        [Column("at_risk")]
        public bool AtRisk { get; set; }

        [Column("geometry")]
        public Point? Geometry { get; set; }
    }
}
