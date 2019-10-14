# INTRO
此项目专门用于保存我平时开发WPF使用库、文件等。

# 项目搭建
```XML
.net framework 优先选择4.5+ 可以使用内置的 WindowChrome

项目必要的文件夹
-Image
-Model
-Style
-View
-ViewModel
```



# 1.0 mvvm light
```XAML
Nuget 安装  MvvmLight

//申明ViewModel加载器
<vm:ViewModelLocator
xmlns:vm="clr-namespace:AIYI.ViewModel"
x:Key="Locator"
d:IsDataSource="True" />

//绑定ViewModel
DataContext="{Binding Source={StaticResource Locator}, Path=Main}"
```

## mvvm light 代码段
#### 1.1 mvvminpc 属性
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
#### 1.2 mvvmrelay 命令
```C#
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
});
```
#### 1.3 mvvmrelaycanexecute 命令(附带Canexecute)
```C#        
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
}, () => false);
```
#### 1.4 mvvmrelaygeneric 命令(带参)
```C# 
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand<string>((e) =>
{
    //代码
});
```

# 2.0 其他
```XAML
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
