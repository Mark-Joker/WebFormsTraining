using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class ProductsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IList<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            ICatalogDataService catDataService = new NoDbCatalogDataService();
            var products = catDataService.GetAllProducts();

            if (categoryId.HasValue && categoryId > 0)
                products = products.Where(p => p.CategoryID == categoryId).ToList();

            return products;
        }
    }
}