#addin "nuget:?package=Cake.PackageType.Addin&version=0.1.0"

Task("ExampleHelloAddin")
    .Does(() =>
{
    Information("Addin: Start");

    Hello();

    Information("Addin: End");
});

RunTarget("ExampleHelloAddin");
