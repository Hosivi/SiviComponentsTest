namespace SiviComponents.DataGrid;

public class FilterMetadata<TModel>
{
  public List<Func<TModel,bool>> Filters { get; set; }
}