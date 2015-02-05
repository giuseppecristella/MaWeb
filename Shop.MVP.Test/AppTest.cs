namespace Shop.MVP.Test
{
  public class AppTest  
  {
    public static string Type { get; set; }
    public static Configuration.Configuration Configuration { get; set; }
    static AppTest()
    {
      // instanzio un oggetto e lo assegno ad una proprietà statica, così posso lavorare su un singleton
      // es. AppTest.Configuration
      //CacheManager = new AspnetCacheManager();
      Type = string.Empty;
      Configuration = new Configuration.Configuration();
    }
  }
}
