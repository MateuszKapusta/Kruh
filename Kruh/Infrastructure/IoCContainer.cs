using Kruh.ViewModels;
using Kruh.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompModel = System.ComponentModel;

namespace Kruh.Infrastructure
{
  public static class IoCContainer
  {

    public static void Register(IContainerRegistry containerRegistry)
    {
      //Dialogs
      containerRegistry.RegisterDialog<LoginDialog, LoginDialogViewModel>(nameof(LoginDialog));

    }

  }
}
