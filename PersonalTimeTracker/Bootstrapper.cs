﻿using Microsoft.Practices.Unity;
using Prism.Unity;
using PersonalTimeTracker.Views;
using System.Windows;

namespace PersonalTimeTracker
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
