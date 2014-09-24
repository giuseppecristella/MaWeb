namespace MagentoRepository.Connection
{
  public interface IMagentoConnection
  {
    string password { get; set; }
    string SessionId { get; }
    string url { get; set; }
    string userId { get; set; }
  }
}
