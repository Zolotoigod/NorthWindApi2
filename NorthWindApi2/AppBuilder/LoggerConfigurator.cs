namespace NorthWindApi2.AppBuilder
{
    public static class LoggerConfigurator
    {
        public static WebApplicationBuilder ConfigureLogger(this WebApplicationBuilder builder)
        {
            foreach (string sheme in Defines.LoggerFilters)
            {
                builder.Host.ConfigureLogging(logging => logging.AddFilter(sheme, LogLevel.Warning));
            }

            return builder;
        }
    }
}
