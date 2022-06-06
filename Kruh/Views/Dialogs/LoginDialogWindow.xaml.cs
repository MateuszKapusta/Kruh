using MahApps.Metro.Controls;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kruh.Views
{
  /// <summary>
  /// Interaction logic for LoginDialogWindow.xaml
  /// </summary>
  public partial class LoginDialogWindow : MetroWindow, IDialogWindow
  {
    public LoginDialogWindow()
    {
      InitializeComponent();
    }

    public IDialogResult Result { get; set; }
  }
}
