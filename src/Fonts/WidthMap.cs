﻿using PdfToSvg.DocumentModel;
using PdfToSvg.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Fonts
{
    internal abstract class WidthMap
    {
        public abstract double GetWidth(CharacterCode ch);


        public static WidthMap Parse(PdfDictionary font)
        {
            if (font.TryGetName(Names.Subtype, out var subtype))
            {
                // TODO More types that can be implemented?
                if (subtype == Names.Type0)
                {
                    return Type0WidthMap.Parse(font);
                }

                if (subtype == Names.Type1)
                {
                    return Type1WidthMap.Parse(font);
                }

                if (subtype == Names.Type3)
                {
                    return Type3WidthMap.Parse(font);
                }
            }

            return new EmptyWidthMap();
        }
    }
}
