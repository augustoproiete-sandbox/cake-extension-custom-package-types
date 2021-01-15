#addin "nuget:?package=Cake.PackageType.Addin&version=1.0.0-rc0002&prerelease"

Task("ExampleHelloAddin")
    .Does(() =>
{
    Information("Addin: Start");

    Hello();

    Information("Addin: End");
});

RunTarget("ExampleHelloAddin");
