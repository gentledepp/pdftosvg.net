﻿using PdfToSvg.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Parsing
{
    internal static class Exceptions
    {
        public static Exception EncryptedPdf()
        {
            return new EncryptedPdfException();
        }

        public static Exception CircularXref(long byteOffsetXRef)
        {
            return new PdfParserException("Circular xref in pdf.", byteOffsetXRef);
        }

        public static Exception MissingTrailer(long byteOffsetXRef)
        {
            return new PdfParserException("Missing or corrupt trailer in xref.", byteOffsetXRef);
        }

        public static Exception UnexpectedToken(BufferedReader reader, Lexeme unexpectedLexeme)
        {
            reader.Seek(unexpectedLexeme.Position - 20, SeekOrigin.Begin);
            var extractPosition = reader.Position;

            var extractBytes = new byte[30];
            var extractLength = reader.Read(extractBytes, 0, extractBytes.Length);
            var extract = Encoding.ASCII.GetString(extractBytes, 0, extractLength);

            reader.Position = unexpectedLexeme.Position;

            var tokenName = unexpectedLexeme.Token == Token.EndOfInput ? "end of input" : "token " + unexpectedLexeme.Token;

            var errorMessage = string.Format(
                "Unexpected {0} at position {1}.\r\nContext: \"{2}\u2192{3}\"",
                tokenName, unexpectedLexeme.Position,
                extract.Substring(0, (int)(unexpectedLexeme.Position - extractPosition)),
                extract.Substring((int)(unexpectedLexeme.Position - extractPosition))
            );

            return new PdfParserException(errorMessage, unexpectedLexeme.Position);
        }

        public static Exception HeaderNotFound()
        {
            return new PdfParserException("The specified file is not a valid PDF file. No file header was found.", 0);
        }

        public static Exception XRefTableNotFound()
        {
            return new PdfParserException("The specified file is not a valid PDF file. No XRef table was found.", 0);
        }

        public static Exception UnexpectedCharacter(BufferedReader reader, char unexpectedChar)
        {
            var errorPosition = reader.Position;
            reader.Seek(-20, SeekOrigin.Current);
            var extractPosition = reader.Position;

            var extractBytes = new byte[30];
            var extractLength = reader.Read(extractBytes, 0, extractBytes.Length);
            var extract = Encoding.ASCII.GetString(extractBytes, 0, extractLength);

            reader.Position = errorPosition;

            var charName =
                unexpectedChar == BufferedReader.EndOfStreamMarker ? "end of input" :
                string.Format("character '{0}' (0x{0:x4})", unexpectedChar);

            var errorMessage = string.Format(
                "Unexpected {0} at position {1}.\r\nContext: \"{2}\u2192{3}\"",
                charName, errorPosition,
                extract.Substring(0, (int)(errorPosition - extractPosition)),
                extract.Substring((int)(errorPosition - extractPosition))
            );

            return new PdfParserException(errorMessage, errorPosition);
        }
    }
}
