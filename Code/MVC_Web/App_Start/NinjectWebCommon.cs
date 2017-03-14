//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVC_Web.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVC_Web.App_Start.NinjectWebCommon), "Stop")]

//namespace MVC_Web.App_Start
//{
//    using System;
//    using System.Web;
//    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
//    using Ninject;
//    using Ninject.Web.Common;
//    using MVC_BLL;
//    using MVC_DAL;

//    public static class NinjectWebCommon
//    {
//        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

//        /// <summary>
//        /// Starts the application
//        /// </summary>
//        public static void Start() 
//        {
//            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
//            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
//            bootstrapper.Initialize(CreateKernel);
//        }
        
//        /// <summary>
//        /// Stops the application.
//        /// </summary>
//        public static void Stop()
//        {
//            bootstrapper.ShutDown();
//        }
        
//        /// <summary>
//        /// Creates the kernel that will manage your application.
//        /// </summary>
//        /// <returns>The created kernel.</returns>
//        private static IKernel CreateKernel()
//        {
//            var kernel = new StandardKernel();
//            try
//            {
//                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
//                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

//                RegisterServices(kernel);
//                return kernel;
//            }
//            catch
//            {
//                kernel.Dispose();
//                throw;
//            }
//        }

//        /// <summary>
//        /// Load your modules or register your services here!
//        /// </summary>
//        /// <param name="kernel">The kernel.</param>
//        private static void RegisterServices(IKernel kernel)
//        {
//            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["StoreContext"].ToString();

//            //Generic BLL Bindings
//            kernel.Bind<IUserService>().To<UserService>();
//            kernel.Bind<ICategoryService>().To<CategoryService>();
//            kernel.Bind<IProductService>().To<ProductService>();
//            kernel.Bind<ILoggerService>().To<LoggerService>();

//            //DAL Bindings With Entity Framework
//            kernel.Bind<IUserRepositery>().To<UserRepositery>();
//            kernel.Bind<ICategoryRepositery>().To<CategoryRepositery>();
//            kernel.Bind<IProductRepositery>().To<ProductRepositery>();
//            kernel.Bind<ILoggerRepositery>().To<LoggerRepositery>();

//            //DAL Bindings With Ado.Net
//            //kernel.Bind<ICategoryRepositery>().To<CategoryRepositery_Ado>().WithConstructorArgument("connectionstring", connectionstring);
//            //kernel.Bind<IProductRepositery>().To<ProductRepositery_Ado>().WithConstructorArgument("connectionstring", connectionstring);
//            //kernel.Bind<ILoggerRepositery>().To<LoggerRepositery_Ado>().WithConstructorArgument("connectionstring", connectionstring);

//            //Binding StoreContext Model
//            kernel.Bind<StoreContext>().ToSelf().InRequestScope();
            
//        }        
//    }
//}
