using VanArsdel.DataGenerator.Domains.Retail;

namespace VanArsdel.DataGenerator.Generators;

public static class ProductCategoryGenerator
{
    public static List<ProductCategory> GenerateProductCategories()
    {

        var categories = new List<ProductCategory>();
        
        foreach (var (top, subs) in ProductCategoryDefinitions)
        {
            var parentId = Guid.NewGuid();
            categories.Add(new ProductCategory
            {
                ProductCategoryId = parentId,
                ParentCategoryId = null,
                Name = top
            });

            categories.AddRange(subs.Select(sub => new ProductCategory
            {
                ProductCategoryId = Guid.NewGuid(),
                ParentCategoryId = parentId, 
                Name = sub
            }));
        }


        return categories;
    }
}