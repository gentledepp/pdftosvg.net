﻿// Copyright (c) PdfToSvg.NET contributors.
// https://github.com/dmester/pdftosvg.net
// Licensed under the MIT License.

using PdfToSvg.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Encodings
{
    internal static class EncodingFactory
    {
        public static SingleByteEncoding? Create(object? definition, SingleByteEncoding defaultBaseEncoding)
        {
            if (definition is PdfName encodingName)
            {
                if (encodingName == Names.WinAnsiEncoding)
                {
                    return SingleByteEncoding.WinAnsi;
                }

                if (encodingName == Names.MacExpertEncoding)
                {
                    return SingleByteEncoding.MacExpert;
                }

                if (encodingName == Names.MacRomanEncoding)
                {
                    return SingleByteEncoding.MacRoman;
                }
            }
            else if (definition is PdfDictionary encodingDict)
            {
                return CustomEncoding.Create(encodingDict, defaultBaseEncoding);
            }

            return null;
        }
    }
}
