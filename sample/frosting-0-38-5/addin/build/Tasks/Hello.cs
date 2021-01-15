using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.PackageType.Addin;

[TaskName("Hello")]
public sealed class Hello : FrostingTask<Context>
{
    public override void Run(Context context)
    {
        context.Information("Hello World");

        context.Hello();
    }
}
