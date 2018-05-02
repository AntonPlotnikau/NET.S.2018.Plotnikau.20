namespace DI
{
    /// <summary>
    /// configuration module
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public class ConfigModule : Ninject.Modules.NinjectModule
    {
        /// <summary>
        /// Dependency injection.
        /// </summary>
        public override void Load()
        {         
            this.Bind<Logger.ILogger>().To<Logger.NLogger>().WithConstructorArgument("Parser");
            this.Bind<Parser.IStorage>().To<Parser.FileStorage>().WithConstructorArgument(@"E:\training\NET.S.2018.Plotnikau.20\test.txt");
            this.Bind<Serializer.ISerializer>().To<Serializer.UriSerializer>().WithConstructorArgument(@"E:\training\NET.S.2018.Plotnikau.20\test.xml");
        }
    }
}