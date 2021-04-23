using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DatVeMayBay.Data.Context;
using DatVeMayBay.Data.Infrastructure;
using DatVeMayBay.Data.Repository;
using DatVeMayBay.Model;
using DatVeMayBay.Service;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DatVeMayBay.Web.App_Start.AutoFacOwin))]

namespace DatVeMayBay.Web.App_Start
{
    public class AutoFacOwin
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            AutoFacConfiguration();
        }

        public void AutoFacConfiguration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SQLFactoryImpl>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<DatVeMayBayDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ChuyenBayRepo>().As<IChuyenBayRepo>().InstancePerRequest();
            builder.RegisterType<ChuyenBayService>().As<IChuyenBayService>().InstancePerRequest();
            builder.RegisterType<HoaDonRepo>().As<IHoaDonRepo>().InstancePerRequest();
            builder.RegisterType<HoaDonService>().As<IHoaDonService>().InstancePerRequest();
            builder.RegisterType<KhachHangRepo>().As<IKhachHangRepo>().InstancePerRequest();
            builder.RegisterType<KhachHangService>().As<IKhachHangService>().InstancePerRequest();
            builder.RegisterType<MayBayRepo>().As<IMayBayRepo>().InstancePerRequest();
            builder.RegisterType<MayBayService>().As<IMayBayService>().InstancePerRequest();
            builder.RegisterType<NhanVienRepo>().As<INhanVienRepo>().InstancePerRequest();
            builder.RegisterType<NhanVienService>().As<INhanVienService>().InstancePerRequest();
            builder.RegisterType<SanBayRepo>().As<ISanBayRepo>().InstancePerRequest();
            builder.RegisterType<SanBayService>().As<ISanBayService>().InstancePerRequest();
            builder.RegisterType<TaiKhoanRepo>().As<ITaiKhoanRepo>().InstancePerRequest();
            builder.RegisterType<TaiKhoanService>().As<ITaiKhoanService>().InstancePerRequest();
            builder.RegisterType<VeRepo>().As<IVeRepo>().InstancePerRequest();
            builder.RegisterType<VeService>().As<IVeService>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
