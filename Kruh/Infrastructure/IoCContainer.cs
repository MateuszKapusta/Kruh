using Kruh.Services.RequestService;
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
      //Services
      containerRegistry.RegisterSingleton<IRequestService, RequestService>();

      //Navigation
      containerRegistry.RegisterForNavigation<UserView>();
      containerRegistry.RegisterForNavigation<DetailsView>();

      //Dialogs
      containerRegistry.RegisterDialogWindow<BaseDialogWindow>();
      containerRegistry.RegisterDialogWindow<LoginDialogWindow>(nameof(LoginDialogWindow));
      containerRegistry.RegisterDialog<LoginDialog, LoginDialogViewModel>(nameof(LoginDialog));
      containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>(nameof(MessageDialog));
      containerRegistry.RegisterDialog<ChoiceDialog, ChoiceDialogViewModel>(nameof(ChoiceDialog));

    }

  }
}
