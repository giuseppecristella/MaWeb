﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ez.Newsletter.MagentoApi;


namespace MagentoBusinessDelegate
{
    public class Cart
    {
        private List<Product> _products;
        private decimal _total;

        public Cart()
        {
            _products = new List<Product>();
        }

        public IEnumerable<Product> Products
        {
            get { return _products; }
        }

        public decimal Total
        {
            get
            {
                return this.Products.Sum(p => int.Parse(p.qty) * decimal.Parse(p.price.Replace(".", ","), CultureInfo.GetCultureInfo("it-IT").NumberFormat));
            }
        }

        public List<Product> DeleteProducts(List<Product> productsToDelete)
        {
            _products = _products.Except(productsToDelete).ToList();
            return _products;
        }

        public void AddProductAndUpdateTotal(Product product)
        {
            if (!_products.Contains(product))
            {
                _products.Add(product);
            }
           // _total += decimal.Parse(product.price.Replace(".", ","));
        }
    }
}
