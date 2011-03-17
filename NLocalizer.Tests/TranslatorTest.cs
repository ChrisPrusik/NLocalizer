/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: TranslatorTest.cs 3185 2010-10-01 00:44:06Z unknown $

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

*******************************************************************************/
using NLocalizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NLocalizer.Tests
{
    [TestClass]
    public class TranslatorTest
    {

        [TestMethod]
        public void FormTest()
        {
            Translator.Translation.Clear();
            Translator.Translation.Read(@"..\..\..\NLocalizer.Tests");
            Translator.Translation.CurrentLanguage = "Polish";
            using (TestForm form = new TestForm())
            {
                Assert.AreEqual("TestForm", form.Text);
                Assert.AreEqual("toolStripMenuItem1", form.toolStripMenuItem1.Text);
                //form.ShowDialog();
                Translator.Translate("Polish", form);
                Assert.AreEqual("Mój pierwszy formularz", form.Text);
                Assert.AreEqual("Pierwsze menu", form.toolStripMenuItem1.Text);
                //form.ShowDialog();
                Translator.Translate("English", form);
                Assert.AreEqual("My first form", form.Text);
                Assert.AreEqual("First menu", form.toolStripMenuItem1.Text);
                //form.ShowDialog();
                Translator.Restore(form);
                //form.ShowDialog();
                Assert.AreEqual("TestForm", form.Text);
                Assert.AreEqual("toolStripMenuItem1", form.toolStripMenuItem1.Text);
            }
        }

        [TestMethod]
        public void FormTypeTest()
        {
            Translator.Translation.Clear();
            Translator.Translation.Read(@"..\..\..\NLocalizer.Tests");
            Translator.Translation.CurrentLanguage = "Polish";
            Assert.IsNotNull(typeof(TestForm));
        }
    }
}
