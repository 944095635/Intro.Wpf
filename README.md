# INTRO
此项目专门用于保存我平时开发WPF使用库、文件等。

# 项目搭建
```XML
.net framework 优先选择4.5+ 可以使用内置的 WindowChrome

项目必要的文件夹
-Common
-Image
-Model
-Style
-Service
-View
-ViewModel
```

# MVVM框架 mvvm light
```XAML
Nuget 安装  MvvmLight

//申明ViewModel加载器
<vm:ViewModelLocator
        xmlns:vm="clr-namespace:XXX.ViewModel"
        x:Key="Locator"
        d:IsDataSource="True" />

//绑定ViewModel
DataContext="{Binding Source={StaticResource Locator}, Path=Main}"
```

## 代码段 mvvm light
#### mvvminpc 属性
```C#
private bool _myProperty;
/// <summary>
/// 属性.
/// </summary>
public bool MyProperty
{
    get { return _myProperty; }
    set { Set(ref _myProperty, value); }
}
```
#### mvvmrelay 命令
```C#
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
});
```
#### mvvmrelaycanexecute 命令(附带Canexecute)
```C#        
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
}, () => false);
```
#### mvvmrelaygeneric 命令(带参)
```C# 
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand<string>((e) =>
{
    //代码
});
```


# 页面跳转 Frame Navigation Service
```XML
在mvvm中如何实现UI跳转呢？
使用 NavigationService
```

```C# 
///如果需要在cs中使用需要注册
SimpleIoc.Default.Register(() => CreateNavigationService());
///创建导航规则
private INavigationService CreateNavigationService()
{
    NavigationService navigationService = new NavigationService();
    navigationService.Configure("login", new Uri("/DMSkin;component/View/LoginView.xaml", UriKind.Relative));
    navigationService.Configure("main", new Uri("/DMSkin;component/View/MainView.xaml", UriKind.Relative));
    return navigationService;
}

///必须要在Frame中增加
<Frame x:Name="MainFrame" NavigationUIVisibility="Hidden" />

///如果想要在View层使用
DataContext="{Binding Source={StaticResource Locator}}"

///Window的CS代码或者ViewModel中使用
ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo("login");
ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo("main");
```

# 其他
```XAML
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
