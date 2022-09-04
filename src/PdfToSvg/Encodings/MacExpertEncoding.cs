﻿// Copyright (c) PdfToSvg.NET contributors.
// https://github.com/dmester/pdftosvg.net
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Encodings
{
    internal class MacExpertEncoding : SingleByteEncoding
    {
        // Extracted from PDF spec 1.7 page 673.
        // Unicode char codes looked up in Adobe Glyph List:
        // https://raw.githubusercontent.com/adobe-type-tools/agl-aglfn/master/glyphlist.txt

        private static readonly string?[] chars = new[]
        {
            nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar,
            nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar,
            nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar,
            nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, nullchar,
            "\u0020", "\uf721", "\uf6f8", "\uf7a2", "\uf724", "\uf6e4", "\uf726", "\uf7b4",
            "\u207d", "\u207e", "\u2025", "\u2024", "\u002c", "\u002d", "\u002e", "\u2044",
            "\uf730", "\uf731", "\uf732", "\uf733", "\uf734", "\uf735", "\uf736", "\uf737",
            "\uf738", "\uf739", "\u003a", "\u003b", nullchar, "\uf6de", nullchar, "\uf73f",
            nullchar, nullchar, nullchar, nullchar, "\uf7f0", nullchar, nullchar, "\u00bc",
            "\u00bd", "\u00be", "\u215b", "\u215c", "\u215d", "\u215e", "\u2153", "\u2154",
            nullchar, nullchar, nullchar, nullchar, nullchar, nullchar, "\ufb00", "\ufb01",
            "\ufb02", "\ufb03", "\ufb04", "\u208d", nullchar, "\u208e", "\uf6f6", "\uf6e5",
            "\uf760", "\uf761", "\uf762", "\uf763", "\uf764", "\uf765", "\uf766", "\uf767",
            "\uf768", "\uf769", "\uf76a", "\uf76b", "\uf76c", "\uf76d", "\uf76e", "\uf76f",
            "\uf770", "\uf771", "\uf772", "\uf773", "\uf774", "\uf775", "\uf776", "\uf777",
            "\uf778", "\uf779", "\uf77a", "\u20a1", "\uf6dc", "\uf6dd", "\uf6fe", nullchar,
            nullchar, "\uf6e9", "\uf6e0", nullchar, nullchar, nullchar, nullchar, "\uf7e1",
            "\uf7e0", "\uf7e2", "\uf7e4", "\uf7e3", "\uf7e5", "\uf7e7", "\uf7e9", "\uf7e8",
            "\uf7ea", "\uf7eb", "\uf7ed", "\uf7ec", "\uf7ee", "\uf7ef", "\uf7f1", "\uf7f3",
            "\uf7f2", "\uf7f4", "\uf7f6", "\uf7f5", "\uf7fa", "\uf7f9", "\uf7fb", "\uf7fc",
            nullchar, "\u2078", "\u2084", "\u2083", "\u2086", "\u2088", "\u2087", "\uf6fd",
            nullchar, "\uf6df", "\u2082", nullchar, "\uf7a8", nullchar, "\uf6f5", "\uf6f0",
            "\u2085", nullchar, "\uf6e1", "\uf6e7", "\uf7fd", nullchar, "\uf6e3", nullchar,
            nullchar, "\uf7fe", nullchar, "\u2089", "\u2080", "\uf6ff", "\uf7e6", "\uf7f8",
            "\uf7bf", "\u2081", "\uf6f9", nullchar, nullchar, nullchar, nullchar, nullchar,
            nullchar, "\uf7b8", nullchar, nullchar, nullchar, nullchar, nullchar, "\uf6fa",
            "\u2012", "\uf6e6", nullchar, nullchar, nullchar, nullchar, "\uf7a1", nullchar,
            "\uf7ff", nullchar, "\u00b9", "\u00b2", "\u00b3", "\u2074", "\u2075", "\u2076",
            "\u2077", "\u2079", "\u2070", nullchar, "\uf6ec", "\uf6f1", "\uf6f3", nullchar,
            nullchar, "\uf6ed", "\uf6f2", "\uf6eb", nullchar, nullchar, nullchar, nullchar,
            nullchar, "\uf6ee", "\uf6fb", "\uf6f4", "\uf7af", "\uf6ea", "\u207f", "\uf6ef",
            "\uf6e2", "\uf6e8", "\uf6f7", "\uf6fc", nullchar, nullchar, nullchar, nullchar,
        };

        private static readonly string?[] glyphNames = GetGlyphNameLookup(chars);

        public MacExpertEncoding() : base(chars, glyphNames) { }
    }
}
