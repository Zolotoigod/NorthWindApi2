
namespace NorthWindEFRepository
{
    public static class Defines
    {
        public readonly struct ErrorMesage
        {
            public const string ItemNotFoundTemplate = "{0} id-<{1}> not found!";
        }

        public readonly struct EntityNames
        {
            public const string Product = "Product";
            public const string Category = "Category";
            public const string Employee = "Employee";
            public const string BlogArticle = "Blog article";
            public const string Picture = "Picture";
            public const string Comment = "Comment";
            public const string Link = "link";
        }
    }
}
