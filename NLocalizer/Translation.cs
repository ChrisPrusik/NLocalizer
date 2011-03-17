/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: Translation.cs 3210 2010-10-03 03:06:53Z unknown $

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
using System.Threading;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace NLocalizer
{
    /// <summary>
    /// Main translation object with all translation strings of application.
    /// </summary>
    public class Translation : SortedDictionary<string, TranslationClasses>
    {
        private string currentLanguage = "";
        /// <summary>
        /// Gets or sets the current language of application.
        /// </summary>
        /// <value>The current language.</value>
        public string CurrentLanguage
        {
            get
            {
                if (currentLanguage != "" && Exists(currentLanguage))
                    return currentLanguage;
                else if (locales.ContainsKey(Thread.CurrentThread.CurrentUICulture.Name) &&
                    Exists(locales[Thread.CurrentThread.CurrentUICulture.Name]))
                    return locales[Thread.CurrentThread.CurrentUICulture.Name];
                else
                    return "";
            }
            set
            {
                currentLanguage = value;
            }
        }

        private TranslationLocales locales = new TranslationLocales();
        /// <summary>
        /// Gets the locales of translations.
        /// </summary>
        /// <value>The locales.</value>
        public TranslationLocales Locales 
        { 
            get 
            { 
                return locales; 
            } 
        }

        private List<string> codeUsings = new List<string>();
        /// <summary>
        /// Gets the code usings of application to translate.
        /// </summary>
        /// <value>The code usings.</value>
        public List<string> CodeUsings 
        { 
            get 
            { 
                return codeUsings; 
            } 
        }

        private List<string> codeModules = new List<string>();
        /// <summary>
        /// Gets the code modules (dll files) of application to translate.
        /// </summary>
        /// <value>The code modules.</value>
        public List<string> CodeModules 
        { 
            get 
            { 
                return codeModules; 
            } 
        }

        private List<string> staticClasses = new List<string>();
        /// <summary>
        /// Gets the static classes of application to translate.
        /// </summary>
        /// <value>The static classes.</value>
        public List<string> StaticClasses 
        {
            get
            {
                return staticClasses;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Translation"/> class and Init() this default values.
        /// </summary>
        public Translation()
        {
            Init();
        }

        /// <summary>
        /// Inits this instance default values.
        /// </summary>
        public void Init()
        {
            Clear();
            locales.Add("pl-PL", "Polish");
            locales.Add("en-US", "English");
            locales.Add("en-GB", "English");

            codeModules.Add("System.dll"); 
            codeModules.Add("System.Windows.Forms.dll");
            codeModules.Add("NLocalizer.dll");

            codeUsings.Add("System");
            codeUsings.Add("System.Windows.Forms");
            codeUsings.Add("System.Reflection");
            codeUsings.Add("NLocalizer");

            staticClasses.Add("Messages"); 
        }

        /// <summary>
        /// Clears all translation.
        /// </summary>
        public void ClearAll()
        {
            Clear();
            codeModules.Clear();
            codeUsings.Clear();
            staticClasses.Clear();
            locales.Clear();
            currentLanguage = "";
        }

        /// <summary>
        /// Check if exists the specified language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public bool Exists(string language)
        {
            return ContainsKey(language);
        }

        /// <summary>
        /// Check if exists the specified class in language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public bool Exists(string language, string className)
        {
            return Exists(language) && this[language].ContainsKey(className);
        }

        /// <summary>
        /// Check if exists the specified property of class and language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public bool Exists(string language, string className, string propertyName)
        {
            return Exists(language, className) && this[language][className].ContainsKey(propertyName);
        }

        /// <summary>
        /// Sets the translation text of class and property in specified language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="valueText">The value text.</param>
        public void SetText(string language,
            string className, string propertyName, string valueText)
        {
            if (ContainsKey(language) == false)
                Add(language, new TranslationClasses());
            if (this[language].ContainsKey(className) == false)
                this[language].Add(className, new TranslationProperties());
            this[language][className][propertyName] = valueText;
        }

        /// <summary>
        /// Gets the translation text of class and property in specified language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public string GetText(string language, string className, string propertyName)
        {
            try
            {
                if (Exists(language, className, propertyName))
                    return this[language][className][propertyName];
                else if (Exists("English", className, propertyName))
                    return this["English"][className][propertyName];
                else if (Exists("Neutral", className, propertyName))
                    return this["Neutral"][className][propertyName];
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the translation text of class and property in current language.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public string GetText(string className, string propertyName)
        {
            return GetText(CurrentLanguage, className, propertyName);
        }

        /// <summary>
        /// Writes the all translation into files in specified directory name.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        public void Write(string directoryName)
        {
            LangWriter.Write(directoryName, this);
        }

        /// <summary>
        /// Writes all this translation into files in application directory.
        /// </summary>
        public void Write()
        {
            LangWriter.Write(this);
        }

        /// <summary>
        /// Reads all translation from files in application directory.
        /// </summary>
        public void Read()
        {
            LangReader.Read(this);
        }

        /// <summary>
        /// Reads all translation from files in specified directory.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        public void Read(string directoryName)
        {
            LangReader.Read(directoryName, this);
        }

        /// <summary>
        /// Reads the specified language from lines.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="lines">The lines.</param>
        public void Read(string language, string[] lines)
        {
            LangReader.Read(language, lines, this);
        }

        /// <summary>
        /// Generates the translation code in C# into StringBuilder.
        /// </summary>
        /// <returns></returns>
        public StringBuilder GenerateCode()
        {
            return RuntimeCompiler.ToCSharpCode(this);
        }

        /// <summary>
        /// Generates the translation code in C# into StringBuilder.
        /// </summary>
        /// <param name="runtimeNamespace">The runtime namespace.</param>
        /// <param name="runtimeClassName">Name of the runtime class.</param>
        /// <returns></returns>
        public StringBuilder GenerateCode(string runtimeNamespace, string runtimeClassName)
        {
            return RuntimeCompiler.ToCSharpCode(this, runtimeNamespace, runtimeClassName);
        }

        /// <summary>
        /// Compiles the translation.
        /// </summary>
        /// <returns></returns>
        public CompilerResults Compile()
        {
            return RuntimeCompiler.Compile(this);
        }

        /// <summary>
        /// Compiles the translation.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <returns></returns>
        public CompilerResults Compile(string directoryName)
        {
            return RuntimeCompiler.Compile(this, directoryName);
        }

        /// <summary>
        /// Compiles the translation.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        /// <param name="runtimeNamespace">The runtime namespace.</param>
        /// <param name="runtimeClassName">Name of the runtime class.</param>
        /// <returns></returns>
        public CompilerResults Compile(string directoryName, string runtimeNamespace, string runtimeClassName)
        {
            return RuntimeCompiler.Compile(this, directoryName, runtimeNamespace, runtimeClassName);
        }
    }
}
