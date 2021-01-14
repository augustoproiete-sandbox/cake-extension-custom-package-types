using System;
using Cake.Core.Annotations;
using Cake.Core.Composition;
using Cake.Core.Packaging;

[assembly: CakeModule(typeof(Cake.PackageType.Module.HelloModule))]

namespace Cake.PackageType.Module
{
    /// <summary>
    /// Module type to add support for the Hello package manager.
    /// </summary>
    public class HelloModule : ICakeModule
    {
        /// <inheritdoc />
        public void Register(ICakeContainerRegistrar registrar)
        {
            if (registrar == null)
            {
                throw new ArgumentNullException(nameof(registrar));
            }

            registrar.RegisterType<HelloPackageInstaller>().As<IPackageInstaller>();
        }
    }
}
