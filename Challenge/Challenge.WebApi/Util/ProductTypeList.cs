using Challenge.External.Models;

namespace Challenge.WebApi.Util
{
    public class ProductTypeList
    {
        public static List<ProductType> GetList()
        {
            var list = new List<ProductType>()
            {
                new ProductType()
                {
                    ProductTypeId = 1,
                    Description = "Product Type 1",
                    Discount = 5
                },
                new ProductType()
                {
                    ProductTypeId = 2,
                    Description = "Product Type 2",
                    Discount = 2
                },
                new ProductType()
                {
                    ProductTypeId = 3,
                    Description = "Product Type 3",
                    Discount = 0
                },
                new ProductType()
                {
                    ProductTypeId = 4,
                    Description = "Product Type 4",
                    Discount = 10
                }
            };

            return list;
        }
    }
}
