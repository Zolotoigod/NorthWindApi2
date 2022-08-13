
namespace NorthWindEFRepository
{
    public static class Defines
    {
        // can add more bytes for more accuracy
        public static readonly byte[] AccessDBServiceBytes = new byte[]
        {
            21, 28, 47, 0, 2, 0, 0, 0, 13, 0, 14, 0, 20, 0, 33, 0, 255, 255, 255, 255,
            66, 105, 116, 109, 97, 112, 32, 73
        };

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
