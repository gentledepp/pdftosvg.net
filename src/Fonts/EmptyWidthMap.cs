﻿using PdfToSvg.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Fonts
{
    internal class EmptyWidthMap : WidthMap
    {
        public override double GetWidth(CharacterCode ch)
        {
            return 0;
        }
    }
}
