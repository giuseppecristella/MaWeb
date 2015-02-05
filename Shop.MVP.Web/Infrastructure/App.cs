namespace Shop.Web.Mvp.Infrastructure
{
  public class App 
  {
    public string Type { get; set; }
    

    static App()
    {
      // instanzio un oggetto e lo assegno ad una proprietà statica, così posso lavorare su un singleton
      // es. App.Configuration
      //CacheManager = new AspnetCacheManager();
      
    }
  }
}
