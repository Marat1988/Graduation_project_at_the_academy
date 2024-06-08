using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public static string userAnonymous = "Anonymous";

        public AppIdentityDbContext() : base("name=IdentityDb") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineOrder> LineOrders { get; set; }
        public DbSet<Recycler> Recyclers { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            //Администратор по-умочанию
            string roleAdmin = "Administrators";
            string roleUser = "Users";
            string userName = "Admin";
            string password = "mypassword";
            string email = "pirat03071988@mail.ru";
            //Аноним по-умолчанию
            string userNameAnonymous = AppIdentityDbContext.userAnonymous;
            string passwordUserAnonymous = "mypassword";
            string emailAnonymous = "anonym@mail.ru";

            roleMgr.Create(new AppRole(roleUser)); //Создаем роль пользователей
            roleMgr.Create(new AppRole(roleAdmin)); //Создаем роль админа

            //Заполнение начальными данными группы товаров
            List<Group> groups = new List<Group>()
            {
                new Group { Name = "КРЕМА И СР-ВА ДЛЯ УМЫВАНИЯ" },
                new Group { Name = "ГРИБЫ, МАСЛИНЫ, ОЛИВКИ" }
            };
            context.Groups.AddRange(groups);

            //Заполнение начальными данными поставщиков товара
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier { Name = "НЕВСКАЯ КОСМЕТИКА АО" },
                new Supplier { Name = "TAPIO" }
            };
            context.Suppliers.AddRange(suppliers);
            //Создаем админа
            AppUser userAdmin = userMgr.FindByName(userName);
            if (userAdmin == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                userAdmin = userMgr.FindByName(userName);
            }
            //Создаем анономима
            AppUser userAnonymous = userMgr.FindByName(userNameAnonymous);
            if (userAnonymous == null)
            {
                userMgr.Create(new AppUser { UserName = userNameAnonymous, Email = emailAnonymous }, passwordUserAnonymous);
                userAnonymous = userMgr.FindByName(userNameAnonymous);
            }

            //Заполнение начальными данными товаров
            List<Product> products = new List<Product>()
            {
                new Product { Name = "НК ВАЗЕЛИН 40мл КОСМЕТИЧ.В/УП КРЕМ-ГЕЛЬ", Price = 89.08M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ВЕЛЮР НЕВСКИЙ 50мл КРЕМ Д/РУК В/УП", Price = 89.08M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ДЕТСКИЙ 40мл ВИТ.А+В5 КРЕМ/УП", Price = 78.54M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ДЕТСКИЙ 40мл ЗАЩИТНЫЙ 2 в 1 КРЕМ/УПЬ", Price = 78.54M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ЖЕНЬШЕНЕВЫЙ 40мл Д/ЗРЕЛ.ОМОЛ.КРЕМ/УП", Price = 108.53M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ЖЕНЬШЕНЕВЫЙ 25мл ВОКРУГ ГЛАЗ КРЕМ/УП", Price = 108.53M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК КАЛЕНДУЛА 40мл УВЛАЖН/ЛИЦА КРЕМ/УП", Price = 89.08M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ЖЕНЬШЕНЕВАЯ 35мл СЫВОРОТКА Д/ЛИЦА/УП", Price = 165.42M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ДЕТСКИЙ 40мл ЛЕГКИЙ, УВЛАЖ.КРЕМ/УП", Price = 78.54M, Photo = null, Group = groups[0], Supplier = suppliers[0] },
                new Product { Name = "НК ПАНТЕНОЛ 50мл КРЕМ/РУК/УПАК", Price = 98.08M, Photo = null, Group = groups[0], Supplier = suppliers[0] },

                new Product { Name = "МАСЛИНЫ 314мл С КОСТОЧКОЙ Ж/Б/Tapio", Price = 89.00M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
                new Product { Name = "ОЛИВКИ 314мл КРУПН.БЕЗ КОСТОЧКИ Ж/Б/Tapio", Price = 94.50M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
                new Product { Name = "ШАМПИНЬОНЫ  850мл РЕЗАНЫЕ Ж/Б/Tapio", Price = 175.33M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
                new Product { Name = "ШАМПИНЬОНЫ  425мл РЕЗАНЫЕ Ж/Б/Tapio", Price = 89.84M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
                new Product { Name = "ШАМПИНЬОНЫ   425мл ЦЕЛЫЕ СТЕРИЛ.Ж/Б/Tapio", Price = 123.02M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
                new Product { Name = "МАСЛИНЫ 314мл КРУПН.БЕЗ КОСТОЧКИ Ж/Б/Tapio", Price = 94.50M, Photo = null, Group = groups[1], Supplier = suppliers[1] },
            };
            context.Products.AddRange(products);
            //Добавляем в роль админа
            if (!userMgr.IsInRole(userAdmin.Id, roleAdmin))
            {
                userMgr.AddToRoles(userAdmin.Id, new string[] { roleAdmin, roleUser });
            }
            //Добавляем в роль анонима
            if (!userMgr.IsInRole(userAnonymous.Id, roleUser))
            {
                userMgr.AddToRole(userAnonymous.Id, roleUser);
            }
        }
    }
}