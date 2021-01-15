| README.md |
|:---|

<h1 align="center">Cake Extensions with Custom NuGet Package Types</h1>
<div align="center">

Proof-of-concept using [custom package types](https://docs.microsoft.com/en-us/nuget/create-packages/set-package-type) for Cake Addin, Module, and Recipe.

</div>

## Extensions

| Type | NuGet package | Package type | Stable | Prerelease |
| --- | --- | --- | --- | --- |
| Addin | [Cake.PackageType.Addin](https://www.nuget.org/packages/Cake.PackageType.Addin) | `CakeAddin`   | [![Cake.PackageType.Addin NuGet version stable](https://img.shields.io/nuget/v/Cake.PackageType.Addin?color=blue&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Addin) | [![Cake.PackageType.Addin NuGet version prerelease](https://img.shields.io/nuget/vpre/Cake.PackageType.Addin?color=orange&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Addin) |
| Module | [Cake.PackageType.Module](https://www.nuget.org/packages/Cake.PackageType.Module) | `CakeModule` | [![Cake.PackageType.Module NuGet version stable](https://img.shields.io/nuget/v/Cake.PackageType.Module?color=blue&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Module) | [![Cake.PackageType.Module NuGet version prerelease](https://img.shields.io/nuget/vpre/Cake.PackageType.Module?color=orange&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Module) |
| Recipe | [Cake.PackageType.Recipe](https://www.nuget.org/packages/Cake.PackageType.Recipe) | `CakeRecipe` | [![Cake.PackageType.Recipe NuGet version stable](https://img.shields.io/nuget/v/Cake.PackageType.Recipe?color=blue&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Recipe) | [![Cake.PackageType.Recipe NuGet version prerelease](https://img.shields.io/nuget/vpre/Cake.PackageType.Recipe?color=orange&label=&style=flat-square)](https://www.nuget.org/packages/Cake.PackageType.Recipe) |

## Usage

### Addin

Call the `Hello()` alias in order to run the add-in using the default settings:

```csharp
#addin nuget:?package=Cake.PackageType.Addin&version=0.1.0

Task("Example")
    .Does(() =>
{
    Hello();
});

RunTarget("Example");
```

### Module

Use the `hello` scheme in a `#tool` directive in order to execute the module:

```csharp
#module nuget:?package=Cake.PackageType.Module&version=0.1.0
#tool hello:?package=MyAwesomePackage&version=1.2.3
```

### Recipe

Call the `SayHello(string name)` and `SayBye(string name)` helper methods included in the recipe:

```csharp
#load nuget:?package=Cake.PackageType.Recipe&version=0.1.0

Task("Example")
    .Does(() =>
{
    SayHello("Augusto");
    SayBye("Augusto");
});

RunTarget("Example");
```

## Working Examples

In the [sample](sample) folder you can find working examples using different versions of Cake Tool and Frosting.


## Release History

Click on the [Releases](https://github.com/augustoproiete-sandbox/cake-extension-custom-package-types/releases) tab on GitHub.

---

_Copyright &copy; 2021 C. Augusto Proiete & Contributors - Provided under the [MIT License](LICENSE)._
