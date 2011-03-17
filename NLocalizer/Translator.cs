/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: Translator.cs 3188 2010-10-01 01:34:14Z unknown $

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
using System.Reflection;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Windows.Forms;

namespace NLocalizer
{
    /// <summary>
    /// Main static class of application translation
    /// </summary>
    public static class Translator
    {
        // Language / (ClassName)ControlName.PropertyName = ValueText
        private static Translation translation = new Translation();
        /// <summary>
        /// Gets the translation of current application.
        /// </summary>
        /// <value>The translation.</value>
        public static Translation Translation 
        { 
            get { return translation; } 
        }

        private static string runtimeNamespace = "NLocalizer";
        /// <summary>
        /// Gets the runtime namespace of compiled class.
        /// </summary>
        /// <value>The runtime namespace.</value>
        public static string RuntimeNamespace
        {
            get { return runtimeNamespace; }
        }

        private static string runtimeClassName = "RuntimeTranslator";
        /// <summary>
        /// Gets the name of the runtime compiled class.
        /// </summary>
        /// <value>The name of the runtime class.</value>
        public static string RuntimeClassName
        {
            get { return runtimeClassName; }
        }

        private static CompilerResults compilerResults = null;
        /// <summary>
        /// Gets the translation compile results.
        /// </summary>
        /// <value>The compiler results.</value>
        public static CompilerResults CompilerResults
        {
            get { return compilerResults; }
        }

        /// <summary>
        /// Compiles if necessary.
        /// </summary>
        public static void CompileIfNecessary()
        {
            if (compilerResults == null || compilerResults.CompiledAssembly == null)
                compilerResults = RuntimeCompiler.Compile(translation, runtimeNamespace, runtimeClassName);
        }

        /// <summary>
        /// Gets the runtime compiled class (compile if necessary).
        /// </summary>
        /// <returns></returns>
        public static Type GetRuntimeClass()
        {
            CompileIfNecessary();
            return RuntimeCompiler.GetCompiledClass(compilerResults, runtimeNamespace, runtimeClassName);
        }

        /// <summary>
        /// Translates the specified obj into language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="obj">The obj.</param>
        public static void Translate(string language, object obj)
        {
            RuntimeCompiler.Translate(GetRuntimeClass(), language, obj, translation);
        }

        /// <summary>
        /// Translates the specified obj into current language.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public static void Translate(object obj)
        {
            Translate();
            RuntimeCompiler.Translate(GetRuntimeClass(), obj, translation);
        }

        /// <summary>
        /// Translates all static classes into current language.
        /// </summary>
        public static void Translate()
        {
            RuntimeCompiler.Translate(GetRuntimeClass(), translation);
        }

        /// <summary>
        /// Translates all static classes into specified language.
        /// </summary>
        /// <param name="language">The language.</param>
        public static void Translate(string language)
        {
            RuntimeCompiler.Translate(GetRuntimeClass(), language, translation);
        }

        /// <summary>
        /// Restores all static classes into neutral language.
        /// </summary>
        public static void Restore()
        {
            RuntimeCompiler.Restore(GetRuntimeClass(), translation);
        }

        /// <summary>
        /// Restores the specified obj into neutral language.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public static void Restore(object obj)
        {
            RuntimeCompiler.Restore(GetRuntimeClass(), obj, translation);
        }

        /// <summary>
        /// Shows the className as form.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        public static void ShowDialog(string className)
        {
            RuntimeCompiler.ShowDialog(GetRuntimeClass(), className);
        }

        /// <summary>
        /// Creates the specified class name.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public static object Create(string className)
        {
            return RuntimeCompiler.Create(GetRuntimeClass(), className);
        }
    }
}