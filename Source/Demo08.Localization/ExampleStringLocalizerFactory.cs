using Microsoft.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo08.Localization
{
    public class ExampleStringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new ExampleStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new ExampleStringLocalizer();
        }
    }
}
