public class FeatureCollectionDto<T>
{
    public string Type { get; set; } = "FeatureCollection";
    public IEnumerable<FeatureDto<T>> Features { get; set; } = [];
}
