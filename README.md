# Intro.Wpf
此项目专门用于保存我平时开发WPF使用库、文件等。

# mvvm light
```XML
Nuget 安装  mvvm light 
```

# mvvm light 代码段
```C#
///mvvminpc 属性
private bool _myProperty;
/// <summary>
/// 属性.
/// </summary>
public bool MyProperty
{
      get { return _myProperty; }
      set { Set(ref _myProperty, value); }
}

///mvvmrelay 命令
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
});
        
///mvvmrelaycanexecute 命令(附带Canexecute)
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand(() =>
{
    //代码
}, () => false);
        


///mvvmrelaygeneric 命令(带参)
/// <summary>
/// 命令Command
/// </summary>
public ICommand MyCommand => new RelayCommand<string>((e) =>
{
    //代码
});
```


```XAML
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
