/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: RuntimeCompilerTest.cs 3185 2010-10-01 00:44:06Z unknown $

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
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NLocalizer.Tests
{
    [TestClass]
    public class RuntimeCompilerTest
    {
        [TestMethod]
        public void CodeTest()
        {
            Translation translation = new Translation();
            translation.Read(@"..\..\..\NLocalizer.Tests");
            StringBuilder code = translation.GenerateCode();
            File.WriteAllText(@"..\..\..\NLocalizer.Tests\RuntimeTranslator.cs", code.ToString());
        }

        [TestMethod]
        public void CompileTest()
        {
            Translation translation = new Translation();
            translation.Read(@"..\..\..\NLocalizer.Tests\Bin\Debug");
            CompilerResults compiler = translation.Compile(@"..\..\..\NLocalizer.Tests\Bin\Debug");
            Assert.IsNotNull(compiler);
            Assert.IsNotNull(compiler.CompiledAssembly);
            Assert.AreEqual(0, compiler.Errors.Count);
        }

        [TestMethod]
        public void ShowTestFormTest()
        {
            Translator.Translation.Read(@"..\..\..\NLocalizer.Tests\Bin\Debug");
            object form = Translator.Create("TestForm");
            Assert.IsNotNull(form);
            Assert.IsTrue(form is Form);
        }

    }
}
