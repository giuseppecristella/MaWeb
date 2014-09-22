using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagentoComunication;


/// <summary>
/// Summary description for CacheManager
/// </summary>
public class CacheManager: ICacheManager
{
  public bool Contains(string key)
  {
    return HttpContext.Current.Cache["sessionId"] != null;
  }
}