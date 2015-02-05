using System.Configuration;

namespace Shop.Web.Mvp.Infrastructure.Configuration
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