using System;
using System.Collections.Generic;
using MagentoComunication.Helpers;
using MagentoRepository.Repository;
using Shop.MVP.Core.Models;
using Shop.MVP.Core.Views;

namespace Shop.MVP.Core.Presenters
{
  public class CatalogoPresenter
  {
    private ICatalogoView _view;
    private readonly IRepository _repository;

    public CatalogoPresenter(ICatalogoView catalogoView)
      : this(catalogoView, RepositoryFactory.GetRepositoryService()) { }

    public CatalogoPresenter(ICatalogoView view, IRepository repository)
    {
      if (view == null)
      {
        throw new ArgumentNullException("view");
      }
      if (repository == null)
      {
        throw new ArgumentNullException("repository");
      }
      _view = view;
      _repository = repository;
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnViewLoaded()
    {
      // Assegna le proprietà della view 
      var products = _repository.GetProductsByCategoryId(ConfigurationHelper.RootCategory);

      var assignedProductsVm = new List<CategoryAssignedProductViewModel>();
      foreach (var p in products)
      {
        assignedProductsVm.Add(new CategoryAssignedProductViewModel
        {
          Description = string.Empty,
          Name = p.name,
          ImageUrl = p.imageurl,
          Price = p.price,
          Url = string.Empty
        });
      }
      _view.Products = assignedProductsVm;
    }

    public void OnPostBack(List<CategoryAssignedProductViewModel> viewModel)
    {

    }
  }
}
