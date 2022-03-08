using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    static class Constants
    {
        static public readonly string NotApplicable = "N/A";
        static public readonly string XMLVersion = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
        static public readonly string PeopleStart = "<people>\n";
        static public readonly string PeopleEnd = "</people>";
        static public readonly string PersonStart = "<person>\n";
        static public readonly string PersonEnd = "</person>";
        static public readonly string FirstnameStart = "<firstname>";
        static public readonly string FirstnameEnd = "</firstname>\n";
        static public readonly string LastnameStart = "<lastname>";
        static public readonly string LastnameEnd = "</lastname>\n";
        static public readonly string PhoneStart = "<phone>";
        static public readonly string PhoneEnd = "</phone>\n";
        static public readonly string LandLineStart = "<landline>";
        static public readonly string LandLineEnd = "</landline>\n";
        static public readonly string MobileStart = "<mobile>";
        public static readonly string MobileEnd = "</mobile>\n";
        static public readonly string AddressStart = "<address>\n";
        static public readonly string AddressEnd = "</address>\n";
        static public readonly string StreetStart = "<street>";
        static public readonly string StreetEnd = "</street>\n";
        static public readonly string CityStart = "<city>";
        static public readonly string CityEnd = "</city>\n";
        static public readonly string ZipStart = "<zip>";
        static public readonly string ZipEnd = "</zip>\n";
        static public readonly string FamilyStart = "<family>\n";
        static public readonly string FamilyEnd = "</family>\n";
        static public readonly string FNameStart = "<name>";
        static public readonly string FNameEnd = "</name>\n";
        static public readonly string BornStart = "<born>";
        static public readonly string BornEnd = "</born>\n";
    }
}
