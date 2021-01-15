#load "nuget:?package=Cake.PackageType.Recipe&version=0.1.0"

Task("ExampleHelloRecipe")
    .Does(() =>
{
    Information("Recipe: Start");

    SayHello(System.Environment.UserName);
    SayBye(System.Environment.UserName);

    Information("Recipe: End");
});

RunTarget("ExampleHelloRecipe");
