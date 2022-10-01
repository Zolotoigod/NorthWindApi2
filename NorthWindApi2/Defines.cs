namespace NorthWindApi2
{
    public static class Defines
    {
        public const string Total = "totalCount";
        
        public struct LogMessage
        {
            public const string AppStart = "Application started, access point {0}";
            public const string AppStop = "Application stopped";
        }

        public struct ErrorMessage
        {
            public const string NotFoundTemplate = "{0} id-<{1}> not found";
        }

        public static readonly List<string> LoggerFilters = new()
        {
            "Microsoft.Hosting.Lifetime",
        };
    }
}
