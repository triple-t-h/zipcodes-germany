const ZIPCODES_GERMANY = require("./zipcodes-germany-cleaned-up");

class ZipcodesGermany {

    static getPlaces(postcode) {
        return !/(\d){5}/.test(postcode)
            ? "failure: The postal code in Germany is a 5-digit number."
            : this._getZipcodesGermany(postcode, "postcode", "places");
    }

    static getPostcodes(places) {
        return !/\w+/i.test(places)
            ? "failure: hmm…"
            : this._getZipcodesGermany(places, "places", "postcode");
    }

    static _getZipcodesGermany(searched, searchName, resultName) {
        var result = ZIPCODES_GERMANY.filter(function(obj) {
            var s = new RegExp("\\b" + searched + "\\b", "i");
            return s.test(obj[searchName]);            
        });
        return result.map(function(element) {
            return element[resultName];
        });
    }
}

console.log(ZipcodesGermany.getPlaces("19386"));
console.log(ZipcodesGermany.getPostcodes("Hamburg"));