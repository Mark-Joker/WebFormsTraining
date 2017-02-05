using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using DAL;


namespace WebFormsApp
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Product GetProduct([QueryString("productId")] int? productId)
        {
            ICatalogDataService catDataService = new NoDbCatalogDataService();
            var products = catDataService.GetAllProducts();
            Product product = null;

            if (productId.HasValue && productId > 0)
                product = products.SingleOrDefault(p => p.ProductID == productId);

            return product;
        }
    }
}