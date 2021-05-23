﻿using PdfToSvg.DocumentModel;
using PdfToSvg.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Fonts
{
    internal class Type0WidthMap : WidthMap
    {
        private Dictionary<uint, double> widthMap;
        
        private Type0WidthMap() { }

        public new static Type0WidthMap Parse(PdfDictionary font)
        {
            var widthMap = new Dictionary<uint, double>();

            if (font.TryGetArray<PdfDictionary>(Names.DescendantFonts, out var descendantFonts))
            {
                // CIDFont
                // PDF Specification 1.7, Table 117, page 278
                // PDF Specification 1.7, 9.7.4.3, page 279

                foreach (var descendantFont in descendantFonts)
                {
                    if (descendantFont.TryGetArray(Names.W, out var w))
                    {
                        uint? cfirst = null;
                        uint? clast = null;

                        foreach (var item in w)
                        {
                            if (item is object[] rangeArray)
                            {
                                if (cfirst != null)
                                {
                                    var offset = 0u;

                                    foreach (var width in rangeArray)
                                    {
                                        var charCode = cfirst.Value + offset;

                                        if (width is int intWidth)
                                        {
                                            widthMap[charCode] = intWidth;
                                        }
                                        else if (width is double realWidth)
                                        {
                                            widthMap[charCode] = realWidth;
                                        }

                                        offset++;
                                    }
                                }

                                cfirst = null;
                                clast = null;
                            }
                            else if (item is int integer)
                            {
                                if (cfirst == null)
                                {
                                    cfirst = unchecked((uint)integer);
                                }
                                else if (clast == null)
                                {
                                    clast = unchecked((uint)integer);
                                }
                                else
                                {
                                    for (var i = cfirst.Value; i <= clast.Value; i++)
                                    {
                                        widthMap[i] = integer;
                                    }

                                    cfirst = null;
                                    clast = null;
                                }
                            }
                            else if (item is double real)
                            {
                                if (cfirst != null && clast != null)
                                {
                                    for (var i = cfirst.Value; i <= clast.Value; i++)
                                    {
                                        widthMap[i] = real;
                                    }
                                }

                                cfirst = null;
                                clast = null;
                            }
                        }

                        break;
                    }
                }
            }

            return new Type0WidthMap
            {
                widthMap = widthMap,
            };
        }

        public override double GetWidth(CharacterCode ch)
        {
            if (widthMap.TryGetValue(ch.Code, out var width))
            {
                return width;
            }

            return 0;
        }
    }
}
