using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ZipcodesGermanyExample
{
    internal class ZipcodesGermany
    {
        private static XElement _xmlDocument;

        internal static string GetPlaces(string postcode)
        {
            return !Regex.IsMatch($"{postcode}", @"\d{5}")
                ? "failure: The postal code in Germany is a 5-digit number."
                : GetZipcodesGermany(postcode, "postcode", "places");
        }

        internal static string GetPostcodes(string places)
        {
            return !Regex.IsMatch($"{places}", @"\w+", RegexOptions.IgnoreCase)
                ? "failure: hmm…"
                : GetZipcodesGermany(places, "places", "postcode");
        }

        private static string GetZipcodesGermany(string searched, string searchNode, string resultNode)
        {
            _xmlDocument = _xmlDocument ?? XElement.Load("zipcodes-germany-cleaned-up.xml");

            Regex rgx = new Regex($"{searched}", RegexOptions.IgnoreCase);
            
            IEnumerable<XElement> nodes = _xmlDocument.Elements();
            IEnumerable<string> plzPlaces = from node in nodes
                                            where rgx.IsMatch(node.Element(searchNode).Value)
                                            select node.Element(resultNode).Value;

            return plzPlaces.FirstOrDefault();
        }
    }
}