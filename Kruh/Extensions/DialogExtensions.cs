using Kruh.ViewModels;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruh.Extensions
{
  public static class DialogExtensions
  {
    public static void ShowMessage(this IDialogService dialogService, string message, string title = "Komunikat")
    {
      DialogParameters parameters = new DialogParameters();
      parameters.Add(nameof(title), title);
      parameters.Add(nameof(message), message);
      dialogService.ShowDialog(nameof(MessageDialogViewModel).Replace("ViewModel", ""), parameters, null);
    }

    public static void ShowChoice(this IDialogService dialogService, string message, string title, Action<IDialogResult> callBack)
    {
      DialogParameters parameters = new DialogParameters();
      parameters.Add(nameof(title), title);
      parameters.Add(nameof(message), message);
      dialogService.ShowDialog(nameof(ChoiceDialogViewModel).Replace("ViewModel", ""), parameters, callBack);
    }
  }
}
