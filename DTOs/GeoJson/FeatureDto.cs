public class FeatureDto<T>
{
    public string Type { get; set; } = "Feature";
    public T? Properties { get; set; }
    public object? Geometry { get; set; }
}
