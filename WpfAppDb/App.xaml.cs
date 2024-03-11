using Autofac;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfAppDb.Services;
using WpfAppDb.Services.Interfaces;
using WpfAppDb.ViewModels;
using WpfAppDb.ViewModels.Interfaces;
using WpfAppDb.Views;

namespace WpfAppDb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();
            #region Register IOC Container
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<TeacherViewModel>().As<ITeacherViewModel>();
            builder.RegisterType<TeacherViews>(); 
            #endregion
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<TeacherViews>();
                mainWindow.Show();
            }

        }
    }

}
