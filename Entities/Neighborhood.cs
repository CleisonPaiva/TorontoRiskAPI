using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace TorontoRiskAPI.Models
{
    [Table("neighborhood_risk")]
    public class Neighborhood
    {
        [Key]
        [Column("AREA_S_CD")]
        public string Id { get; set; } = string.Empty;

        [Column("AREA_NAME")]
        public string? Name { get; set; }

        [Column("risk_count")]
        public long RiskCount { get; set; }

        [Column("geometry")]
        public Geometry? Geometry { get; set; }
    }
}
