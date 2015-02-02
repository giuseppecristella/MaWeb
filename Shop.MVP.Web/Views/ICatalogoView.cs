using System.Collections.Generic;
using Shop.Web.Mvp.Models;

namespace Shop.Web.Mvp.Views
{
  public interface ICatalogoView
  {
    IEnumerable<CategoryAssignedProductViewModel> Products { set; }
  }

}
