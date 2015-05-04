using System;
using System.Collections.Generic;
using System.Web.UI;
using Shop.MVP.Core.Models;
using Shop.MVP.Core.Presenters;
using Shop.MVP.Core.Views;

namespace Shop.Web.Mvp
{
  public partial class Catalogo : Page , ICatalogoView
  {
    private CatalogoPresenter _presenter;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
        _presenter.OnViewLoaded();
      
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      _presenter = new CatalogoPresenter(this);
      // inizializzo il viewmodel e lo passo al presenter
      if (IsPostBack)
      {
        var viewModel = new List<CategoryAssignedProductViewModel>();
        _presenter.OnViewLoaded();
      }
    }

    public IEnumerable<CategoryAssignedProductViewModel> Products 
    {
      set
      {
        lvCatalog.DataSource = value;
        lvCatalog.DataBind();
      }      
/*
      private get; 
*/
    }
  }
}