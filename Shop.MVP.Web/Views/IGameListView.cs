using System;
using System.Collections.Generic;

namespace Shop.Web.Mvp.Views
{
  /// <summary>
  /// 
  /// </summary>
  public interface IGameListView<T>
  {

    event EventHandler Load;

    IEnumerable<T> Games { get; set; }

  }

}