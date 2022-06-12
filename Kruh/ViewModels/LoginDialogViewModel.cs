using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruh.ViewModels
{
  public class LoginDialogViewModel : BindableBase, IDialogAware
  {
    #region Properties

    private string Password { get; set; }

    private string login;
    public string Login
    {
      get { return login; }
      set { SetProperty(ref login, value); }
    }

    private string title = "Login";
    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    public event Action<IDialogResult> RequestClose;

    #endregion

    #region Commands

    private DelegateCommand onLoginCommand;
    public DelegateCommand OnLoginCommand =>
        onLoginCommand ?? (onLoginCommand = new DelegateCommand(OnLogin, CanExecuteLoginCommand))
        .ObservesProperty(()=> Login);

    private DelegateCommand<string> onPasswordChangedCommand;
    public DelegateCommand<string> OnPasswordChangedCommand =>
        onPasswordChangedCommand ?? (onPasswordChangedCommand = new DelegateCommand<string>(OnPasswordChanged));

    bool CanExecuteLoginCommand()
    {
      if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
        return false;
      
      return true;
    }

    #endregion

    public LoginDialogViewModel()
    {

    }

    void OnPasswordChanged(string password)
    {
      this.Password = password;
      OnLoginCommand.RaiseCanExecuteChanged();
    }


    void OnLogin()
    {

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
