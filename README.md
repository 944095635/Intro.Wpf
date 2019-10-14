# INTRO
此项目专门用于保存我平时开发WPF使用库、文件等。




# 1.0 mvvm light
```XML
Nuget 安装  mvvm light 
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
