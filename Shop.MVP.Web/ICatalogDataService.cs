using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ez.Newsletter.MagentoApi;

namespace Shop.Web.Mvp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICatalogDataService" in both code and config file together.
    [ServiceContract]
    public interface ICatalogDataService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "products/")]
        List<CategoryAssignedProduct> GetProducts();
    }
}
