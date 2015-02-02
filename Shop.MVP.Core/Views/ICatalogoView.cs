using System.Collections.Generic;
using Shop.MVP.Core.Models;

namespace Shop.MVP.Core.Views
{
  public interface ICatalogoView
  {
    IEnumerable<CategoryAssignedProductViewModel> Products { set; }
  }
}
