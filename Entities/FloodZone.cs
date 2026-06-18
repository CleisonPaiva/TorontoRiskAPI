using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace TorontoRiskAPI.Models
{
    [Table("flood_zones")]
    public class FloodZone
    {
        [Key]
        [Column("AREA_ID")]
        public int Id { get; set; }

        [Column("geometry")]
        public Geometry? Geometry { get; set; }
    }
}
