using System.Configuration;

namespace Shop.MVP.Test.Configuration
{
  public class Configuration
  {
    public string TestEnvironment
    {
      get
      {
        return ConfigurationManager.AppSettings["Environment"];
      }
    }
  }
}