using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Packaging;

namespace Cake.PackageType.Module
{
    /// <summary>
    /// <see cref="IPackageInstaller"/> implementation for the Hello package manager.
    /// </summary>
    public class HelloPackageInstaller : IPackageInstaller
    {
        private readonly ICakeLog _log;
        private readonly ICakeEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloPackageInstaller"/> class.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="fileSystem">The file system.</param>
        public HelloPackageInstaller(ICakeLog log, ICakeEnvironment environment, IFileSystem fileSystem)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        /// <summary>
        /// Determines whether this instance can install the specified resource.
        /// </summary>
        /// <param name="package">The package resource.</param>
        /// <param name="type">The package type.</param>
        /// <returns>
        ///   <c>true</c> if this installer can install the
        ///   specified resource; otherwise <c>false</c>.
        /// </returns>
        public bool CanInstall(PackageReference package, Core.Packaging.PackageType type)
        {
            if (package is null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            return package.Scheme.Equals("hello", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Installs the specified resource.
        /// </summary>
        /// <param name="package">The package resource.</param>
        /// <param name="type">The package type.</param>
        /// <param name="path">The location where to install the resource.</param>
        /// <returns>The installed files.</returns>
        public IReadOnlyCollection<IFile> Install(PackageReference package, Core.Packaging.PackageType type, DirectoryPath path)
        {
            if (package is null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (type == Core.Packaging.PackageType.Addin)
            {
                throw new InvalidOperationException("Hello Module does not support Addins.");
            }

            if (type != Core.Packaging.PackageType.Tool)
            {
                throw new InvalidOperationException("Unknown resource type.");
            }

            _log.Information("Hello: Installing {0}", package.Package);

            var tempFolderPath = _environment.GetSpecialPath(SpecialPath.LocalTemp);
            var tempFilePath = tempFolderPath.CombineWithFilePath("hello-from-module.txt");

            var tempFile = _fileSystem.GetFile(tempFilePath);

            using (var stream = tempFile.Open(FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(
                        $"Hello from Cake.PackageType.Module {DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            
            return new List<IFile>
            {
                tempFile,
            };
        }
    }
}
