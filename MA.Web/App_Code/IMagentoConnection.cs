public interface IMagentoConnection
{
  string password { get; set; }
  string sessionId { get; }
  string url { get; set; }
}
