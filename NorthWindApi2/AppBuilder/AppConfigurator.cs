namespace NorthWindApi2.AppBuilder
{
    public static class AppConfigurator
    {
        public static WebApplicationBuilder ConfigurateApp(this WebApplicationBuilder builder)
        {
            builder.ConfigurateService()
                    .ConfigureDB()
                    .ConfigureLogger();

            return builder;
        }
    }
}
