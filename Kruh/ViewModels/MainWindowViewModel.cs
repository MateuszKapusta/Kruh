using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kruh.ViewModels
{

  public class MainWindowViewModel : BindableBase
  {
    private readonly IDialogService dialogService;
    public MainWindowViewModel(IDialogService dialogService)
    {
      this.dialogService = dialogService;

      dialogService.ShowDialog(nameof(LoginDialogViewModel).Replace("ViewModel", ""),null,  InitiateApplication, nameof(LoginDialogViewModel).Replace("ViewModel","Window"));
      //_=Application.Current.Dispatcher.InvokeAsync(()=>dialogService.ShowDialog(nameof(LoginDialogViewModel).Replace("ViewModel", ""), InitiateApplication));
    }

    private void InitiateApplication(IDialogResult dialogResult)
    {
      switch (dialogResult.Result)
      {
        case ButtonResult.OK:
          break;
        default:
          Application.Current.Shutdown();
          break;
      }
    }
  }
}
