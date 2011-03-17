/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: LangReader.cs 3189 2010-10-01 01:38:48Z unknown $

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NLocalizer
{
    /// <summary>
    /// Helper which read language files from application directory
    /// </summary>
    public static class LangReader
    {
        /// <summary>
        /// Reads language files from application directory into the specified translation.
        /// </summary>
        /// <param name="translation">The translation.</param>
        public static void Read(Translation translation)
        {
            Read(Path.GetDirectoryName(Application.ExecutablePath), translation);
        }

        /// <summary>
        /// Reads language files from specified directory into specified translation.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="translation">The translation.</param>
        public static void Read(string directoryName, Translation translation)
        {
            foreach (string fileName in Directory.GetFiles(directoryName, "*.lang"))
                Read(Path.GetFileNameWithoutExtension(fileName),
                    File.ReadAllLines(fileName), translation);
        }

        /// <summary>
        /// Reads language from lines into the specified translation.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="lines">The lines.</param>
        /// <param name="translation">The translation.</param>
        public static void Read(string language, string[] lines, Translation translation)
        {
            for (int pos = 0; pos < lines.Length; pos++)
            {
                string line = lines[pos].Trim();
                if (line.ToLower().StartsWith("locale "))
                {
                    line = line.Substring("locale ".Length).Trim();
                    string[] items = line.Split(',');
                    foreach (string item in items)
                        if (item.Trim() != "")
                            translation.Locales[item.Trim()] = language;
                }
                else if (line.ToLower().StartsWith("module "))
                {
                    line = line.Substring("module ".Length).Trim();
                    string[] items = line.Split(',');
                    foreach (string item in items)
                        if (item.Trim() != "" && translation.CodeModules.Contains(item.Trim()) == false)
                            translation.CodeModules.Add(item.Trim());
                }
                else if (line.ToLower().StartsWith("using "))
                {
                    line = line.Substring("using ".Length).Trim();
                    string[] items = line.Split(',');
                    foreach (string item in items)
                        if (item.Trim() != "" && translation.CodeUsings.Contains(item.Trim()) == false)
                            translation.CodeUsings.Add(item.Trim());
                }
                else if (line.ToLower().StartsWith("static "))
                {
                    line = line.Substring("static ".Length).Trim();
                    string[] items = line.Split(',');
                    foreach (string item in items)
                        if (item.Trim() != "" && translation.StaticClasses.Contains(item.Trim()) == false)
                            translation.StaticClasses.Add(item.Trim());
                }
                else if (line.Trim() != "" && line.StartsWith(";") == false)
                {
                    string className = "";
                    string propertyName = "";
                    string valueText = "";
                    Decode(language, line, ref className, ref propertyName, ref valueText);
                    translation.SetText(language, className, propertyName, valueText);
                }
            }
        }

        /// <summary>
        /// Decode the specified line of language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="line">The line.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="valueText">The value text.</param>
        public static void Decode(string language, string line,
            ref string className, ref string propertyName, ref string valueText)
        {
            if (line.StartsWith("(") == false)
                throw new Exception(String.Format("Expected ( in line: {0}", line));

            line = line.Substring(1).Trim();
            if (line.IndexOf(")") < 0)
                throw new Exception(String.Format("Expected ) in line: {0}", line));
            className = line.Substring(0, line.IndexOf(")")).Trim();

            line = line.Substring(line.IndexOf(")") + 1).Trim();
            if (line.IndexOf("=") < 0)
                throw new Exception(String.Format("Expected = in line: {0}", line));
            propertyName = line.Substring(0, line.IndexOf("=")).Trim();
            line = line.Substring(line.IndexOf("=") + 1).Trim();
            valueText = line;
        }
    }
}
