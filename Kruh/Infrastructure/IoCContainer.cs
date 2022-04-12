using Autofac;
using Autofac.Core;
using Kruh.ViewModels;
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
    public static readonly DependencyProperty AutoWireViewModelProperty =
      DependencyProperty.RegisterAttached(
        name: "AutoWireViewModel",
        propertyType: typeof(bool),
        ownerType: typeof(IoCContainer),
        new PropertyMetadata(
            defaultValue: default(bool),
            propertyChangedCallback: OnAutoWireViewModelChanged)
    );

    public static bool GetAutoWireViewModel(DependencyObject bindable)
    {
      return (bool)bindable.GetValue(AutoWireViewModelProperty);
    }

    public static void SetAutoWireViewModel(DependencyObject bindable, bool value)
    {
      bindable.SetValue(AutoWireViewModelProperty, value);
    }


    private static IContainer _container;

    static IoCContainer()
    {
      var builder = new ContainerBuilder();

      //ViewModel
      builder.RegisterType<MainWindowViewModel>().AsSelf();

      _container = builder.Build();
    }



    private static void OnAutoWireViewModelChanged(DependencyObject view, DependencyPropertyChangedEventArgs e)
    {
      if (CompModel.DesignerProperties.GetIsInDesignMode(view))
      {
        return;
      }

      var viewType = view.GetType();
      var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
      var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
      var viewModelName = string.Format(
        CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

      var viewModelType = Type.GetType(viewModelName);
      if (viewModelType == null)
      {
        return;
      }

      var scope = _container.BeginLifetimeScope();
      var viewModel = scope.Resolve(viewModelType);
      ((FrameworkElement)view).DataContext = viewModel;

      if(view is Window viewWindow)
      {
        viewWindow.Closed += (obj,arg) => scope.Dispose();
      }
      else 
      {
        throw new NotImplementedException();
      }
      
    }

  }
}
