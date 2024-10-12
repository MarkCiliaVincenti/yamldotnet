using Codebelt.Extensions.AspNetCore.Text.Yaml.Converters;
using Codebelt.Extensions.YamlDotNet.Formatters;
using System.Threading;

namespace Codebelt.Extensions.AspNetCore.Text.Yaml
{
    internal static class Bootstrapper
    {
        private static readonly Lock PadLock = new();
        private static bool _initialized;

        internal static void Initialize()
        {
            if (!_initialized)
            {
                lock (PadLock)
                {
                    if (!_initialized)
                    {
                        _initialized = true;
                        YamlFormatterOptions.DefaultConverters += list =>
                        {
                            list.AddProblemDetailsConverter();
                        };
                    }
                }
            }
        }
    }
}
