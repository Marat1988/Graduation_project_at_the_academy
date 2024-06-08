using Autofac.Integration.Mvc;
using Autofac;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin.Security;
using Store.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Store.Repository;
using Store.Service;
using Store.Repository.Suppliers;
using Store.Repository.Products;
using Store.Repository.Recyclers;
using Store.Repository.Orders;

namespace Store
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Регистрация IAuthenticationManager
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication)
                .As<IAuthenticationManager>()
                .InstancePerRequest();

            // Регистрация UserManager
            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>())
                .As<AppUserManager>()
                .InstancePerRequest();

            // Регистрация RoleManager
            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>())
                .As<AppRoleManager>()
                .InstancePerRequest();

            //Группы товара
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<GroupService>();
            //Поставщики товара
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<SupplierService>();
            //Продукты
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>();
            //Корзина
            builder.RegisterType<RecyclerRepository>().As<IRecyclerRepository>();
            builder.RegisterType<RecyclerService>();
            //Заявки
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
