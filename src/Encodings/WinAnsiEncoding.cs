﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Encodings
{
    internal class WinAnsiEncoding : SingleByteEncoding
    {
        // Extracted from PDF spec 1.7 page 661-664.
        // Unicode char codes lookued up in Adobe Glyph List:
        // https://raw.githubusercontent.com/adobe-type-tools/agl-aglfn/master/glyphlist.txt

        // Also see note 3 on page 664, saying that all unused codes above 40 should be
        // mapped to the bullet char.

        // Soft hyphen (00AD) is replaced with normal hyphen to allow being displayed.

        private static readonly string chars =
            "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000" +
            "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000" +
            "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000" +
            "\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000" +
            "\u0020\u0021\u0022\u0023\u0024\u0025\u0026\u0027" +
            "\u0028\u0029\u002a\u002b\u002c\u002d\u002e\u002f" +
            "\u0030\u0031\u0032\u0033\u0034\u0035\u0036\u0037" +
            "\u0038\u0039\u003a\u003b\u003c\u003d\u003e\u003f" +
            "\u0040\u0041\u0042\u0043\u0044\u0045\u0046\u0047" +
            "\u0048\u0049\u004a\u004b\u004c\u004d\u004e\u004f" +
            "\u0050\u0051\u0052\u0053\u0054\u0055\u0056\u0057" +
            "\u0058\u0059\u005a\u005b\u005c\u005d\u005e\u005f" +
            "\u0060\u0061\u0062\u0063\u0064\u0065\u0066\u0067" +
            "\u0068\u0069\u006a\u006b\u006c\u006d\u006e\u006f" +
            "\u0070\u0071\u0072\u0073\u0074\u0075\u0076\u0077" +
            "\u0078\u0079\u007a\u007b\u007c\u007d\u007e\u2022" +
            "\u20ac\u2022\u201a\u0192\u201e\u2026\u2020\u2021" +
            "\u02c6\u2030\u0160\u2039\u0152\u2022\u017d\u2022" +
            "\u2022\u2018\u2019\u201c\u201d\u2022\u2013\u2014" +
            "\u02dc\u2122\u0161\u203a\u0153\u2022\u017e\u0178" +
            "\u00a0\u00a1\u00a2\u00a3\u00a4\u00a5\u00a6\u00a7" +
            "\u00a8\u00a9\u00aa\u00ab\u00ac\u002d\u00ae\u00af" +
            "\u00b0\u00b1\u00b2\u00b3\u00b4\u00b5\u00b6\u00b7" +
            "\u00b8\u00b9\u00ba\u00bb\u00bc\u00bd\u00be\u00bf" +
            "\u00c0\u00c1\u00c2\u00c3\u00c4\u00c5\u00c6\u00c7" +
            "\u00c8\u00c9\u00ca\u00cb\u00cc\u00cd\u00ce\u00cf" +
            "\u00d0\u00d1\u00d2\u00d3\u00d4\u00d5\u00d6\u00d7" +
            "\u00d8\u00d9\u00da\u00db\u00dc\u00dd\u00de\u00df" +
            "\u00e0\u00e1\u00e2\u00e3\u00e4\u00e5\u00e6\u00e7" +
            "\u00e8\u00e9\u00ea\u00eb\u00ec\u00ed\u00ee\u00ef" +
            "\u00f0\u00f1\u00f2\u00f3\u00f4\u00f5\u00f6\u00f7" +
            "\u00f8\u00f9\u00fa\u00fb\u00fc\u00fd\u00fe\u00ff";

        public WinAnsiEncoding() : base(chars) { }
    }
}
