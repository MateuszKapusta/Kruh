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

namespace Kruh.Infrastructure
{
  public static class IoCContainer
  {
    public static readonly DependencyProperty AutoWireViewModelProperty =
    DependencyProperty.Register(
      name: "AutoWireViewModel",
      propertyType: typeof(bool),
      ownerType: typeof(IoCContainer),
      typeMetadata: new FrameworkPropertyMetadata(
          defaultValue: default(bool),
          flags: FrameworkPropertyMetadataOptions.None,
          propertyChangedCallback: OnAutoWireViewModelChanged)
    );

    public static bool GetAutoWireViewModel(DependencyObject bindable)
    {
      return (bool)bindable.GetValue(IoCContainer.AutoWireViewModelProperty);
    }

    public static void SetAutoWireViewModel(DependencyObject bindable, bool value)
    {
      bindable.SetValue(IoCContainer.AutoWireViewModelProperty, value);
    }


    private static IContainer _container;

    static IoCContainer()
    {
      var builder = new ContainerBuilder();

      //ViewModel
      builder.RegisterType<MainWindowViewModel>().AsSelf();

      _container = builder.Build();
    }



    private static void OnAutoWireViewModelChanged(DependencyObject bindable, DependencyPropertyChangedEventArgs e)
    {
      var view = bindable as FrameworkElement;
      if (view == null)
      {
        return;
      }

      var viewType = view.GetType();
      var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
      var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
      var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

      var viewModelType = Type.GetType(viewModelName);
      if (viewModelType == null)
      {
        return;
      }

      var viewModel = Activator.CreateInstance(viewModelType);

      view.DataContext = viewModel;
    }

  }
}
