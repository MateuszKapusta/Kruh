﻿using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruh.ViewModels
{
  public class UserViewModel : BindableBase, INavigationAware
  {
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {

      return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
      
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      
    }
  }
}
