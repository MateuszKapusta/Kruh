using Kruh.Infrastructure;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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
    #region Commands
    private DelegateCommand onUsersCommand;
    public DelegateCommand OnUsersCommand =>
        onUsersCommand ?? (onUsersCommand = new DelegateCommand(OnUsers));

    private DelegateCommand onDetailsCommand;
    public DelegateCommand OnDetailsCommand =>
        onDetailsCommand ?? (onDetailsCommand = new DelegateCommand(OnDetails));

    #endregion


    private readonly IDialogService dialogService;
    private readonly IRegionManager regionManager;
    public MainWindowViewModel(
      IDialogService dialogService
      , IRegionManager regionManager)
    {
      this.dialogService = dialogService;
      this.regionManager = regionManager;

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

    void OnUsers()
    {
      regionManager.RequestNavigate(RegionNames.MainRegion, nameof(UserViewModel).Replace("Model",""));
    }

    void OnDetails()
    {
      regionManager.RequestNavigate(RegionNames.MainRegion, nameof(DetailsViewModel).Replace("Model", ""));
    }

  }
}
