namespace MagentoRepository.Repository
{
  public struct Filter
  {
    public string FilterOperator;
    public string Key;
    public string Value;
  }

  public class LogicalOperator
  {
    public static readonly string Eq = "eq";
    public static readonly string Neq = "neq";
    public static readonly string Gthen = "eq";
  }
}