using Microsoft.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Demo08.Localization
{
    public class ExampleStringLocalizer : IStringLocalizer
    {
        public LocalizedString this[string name]
        {
            get
            {
                return new LocalizedString(name, "J'suis " + name);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                return new LocalizedString(name, String.Format("J'suis with args " + name, arguments));
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new ExampleStringLocalizer();
        }
    }
}
