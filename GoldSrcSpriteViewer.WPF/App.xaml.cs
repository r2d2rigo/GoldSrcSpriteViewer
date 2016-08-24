using GoldSrcSpriteViewer.Core.Services;
using GoldSrcSpriteViewer.WPF.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GoldSrcSpriteViewer.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer container;
        private UnityServiceLocator locator;

        public App()
        {
            this.container = new UnityContainer();
            this.container.RegisterType<ISpriteFrameConverter, SpriteFrameConverter>();

            this.locator = new UnityServiceLocator(this.container);

            ServiceLocator.SetLocatorProvider(() => this.locator);
        }
    }
}
