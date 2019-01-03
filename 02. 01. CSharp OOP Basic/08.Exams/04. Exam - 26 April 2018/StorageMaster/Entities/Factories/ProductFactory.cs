using System;
using System.Collections.Generic;
using System.Text;

public class ProductFactory
{
    public Product CreateProduct(string type , double price)
    {
        Type productType = Type.GetType(type);
        if (productType == null || type == "Product")
        {
            throw new InvalidOperationException("Invalid product type!");
        }

        Product product = null;
        try
        {
            product = (Product)Activator.CreateInstance(productType, new object[] { price });
        }
        catch (Exception e)
        {
            throw new InvalidCastException(e.InnerException.Message);
        }

        return product;
    }
}

