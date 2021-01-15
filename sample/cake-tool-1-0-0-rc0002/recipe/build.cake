#load "nuget:?package=Cake.PackageType.Recipe&version=1.0.0-rc0002&prerelease"

Task("ExampleHelloRecipe")
    .Does(() =>
{
    Information("Recipe: Start");

    SayHello(System.Environment.UserName);
    SayBye(System.Environment.UserName);

    Information("Recipe: End");
});

RunTarget("ExampleHelloRecipe");
