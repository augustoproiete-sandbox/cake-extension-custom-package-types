#module "nuget:?package=Cake.PackageType.Module&version=0.1.0"
#tool hello:?package=MyAwesomePackage&version=1.2.3

Task("ExampleHelloModule")
    .Does(() =>
{
    Information("Module: Start");

    Information("Hello Module!");

    Information("Module: End");
});

RunTarget("ExampleHelloModule");
