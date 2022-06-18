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
  public class MessageDialogViewModel : BindableBase, IDialogAware
  {
    public string Title { get; set; }
    public string Message { get; set; }

    public event Action<IDialogResult> RequestClose;

    private DelegateCommand onClickOkCommand;
    public DelegateCommand OnClickOkCommand =>
        onClickOkCommand ?? (onClickOkCommand = new DelegateCommand(OnClickOk));

    void OnClickOk()
    {
      RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
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
      Title = parameters.GetValue<string>("title");
      Message = parameters.GetValue<string>("message");
    }
  }
}
