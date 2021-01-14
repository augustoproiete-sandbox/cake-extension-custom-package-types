// Copyright 2021 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Cake.Common;
using Cake.Common.Diagnostics;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.PackageType.Addin
{
    /// <summary>
    /// Hello aliases
    /// </summary>
    [CakeAliasCategory("PackageType")]
    [CakeNamespaceImport("Cake.PackageType.Addin")]
    public static class HelloAliases
    {
        /// <summary>
        /// Run the Hello alias.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Hello();
        /// 
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Hello")]
        public static void Hello(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var username = context.Environment.GetEnvironmentVariable(
                context.IsRunningOnWindows() ? "USERNAME" : "USER");

            context.Hello(new HelloSettings
            {
                Name = username ?? "(Unknown)",
            });
        }

        /// <summary>
        /// Run the Hello alias using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Display a name</para>
        /// <code>
        /// <![CDATA[
        /// var settings = new HelloSettings
        /// {
        ///     Name = "Augusto",
        /// };
        /// 
        /// Hello(settings);
        /// 
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Hello")]
        public static void Hello(this ICakeContext context, HelloSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddInInformation.LogVersionInformation(context.Log);

            context.Information(string.Empty);
            context.Information(
                $"Hello {settings.Name} from {AddInInformation.AssemblyName} v{AddInInformation.AssemblyVersion} ({AddInInformation.InformationalVersion})");
        }
    }
}
