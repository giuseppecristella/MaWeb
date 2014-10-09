namespace MagentoRepository.Connection
{
  public interface IMagentoConnection
  {
    string Password { get; set; }
    string SessionId { get; }
    string Url { get; set; }
    string UserId { get; set; }
    bool Login();
  }
}
