using Kruh.Services.RequestService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kruh.Extensions;

namespace Kruh.ViewModels
{
  public class LoginDialogViewModel : BindableBase, IDialogAware
  {
    #region Properties

    private string password;

    private string login;
    public string Login
    {
      get { return login; }
      set { SetProperty(ref login, value); }
    }

    public string Title => "Login";

    public event Action<IDialogResult> RequestClose;

    #endregion

    #region Commands

    private DelegateCommand onLoginCommand;
    public DelegateCommand OnLoginCommand =>
        onLoginCommand ?? (onLoginCommand = new DelegateCommand(async ()=> await OnLogin(), CanExecuteLoginCommand))
        .ObservesProperty(()=> Login);

    private DelegateCommand<string> onPasswordChangedCommand;
    public DelegateCommand<string> OnPasswordChangedCommand =>
        onPasswordChangedCommand ?? (onPasswordChangedCommand = new DelegateCommand<string>(OnPasswordChanged));

    bool CanExecuteLoginCommand()
    {
      if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(password))
        return false;
      
      return true;
    }

    private readonly IRequestService requestService;
    private readonly IDialogService dialogService;

    #endregion

    public LoginDialogViewModel(
      IRequestService requestService
      , IDialogService dialogService)
    {
      this.requestService = requestService;
      this.dialogService = dialogService;
    }

    void OnPasswordChanged(string password)
    {
      this.password = password;
      OnLoginCommand.RaiseCanExecuteChanged();
    }


    async Task OnLogin()
    {
      try
      {
        var result = await requestService.LoginIn(Login, password);
        if(result)
        {
          CloseDialog(new DialogResult(ButtonResult.OK));
        }
        else
        {
          dialogService.ShowMessage("Logowanie się nie powiodło");
        }
      }
      catch(Exception ex)
      {
        dialogService.ShowMessage($"Wystąpił błąd podczas logowania: { ex.Message}", "Błąd");
      }
    }

    protected void CloseDialog(IDialogResult result)
    {
      RequestClose?.Invoke(result);
    }

    public bool CanCloseDialog()
    {
      return true;
    }


    public void OnDialogClosed()
    {
     
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
      
    }
  }
}
