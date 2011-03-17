/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: TranslationTest.cs 3185 2010-10-01 00:44:06Z unknown $

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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLocalizer;

namespace NLocalizer.Tests
{
    [TestClass]
    public class TranslationTest
    {
        private string[] polishLanguage = new string[]
            {
                "; Komentarz",
                ";",
                "locale pl-PL",
                "using System, System.Windows.Forms, NLocalizer, NLocalizer.Tests",
                "module NLocalizer.Tests.dll",
                "static Messages",
                "(TestForm)Text=Mój pierwszy formularz",
                "(TestForm)toolStripMenuItem1.Text=Pierwsze menu",
                "(TestForm)toolStripMenuItem2.Text=Drugie menu",
                "(TestForm)toolStripMenuItem3.Text=Trzecie menu",
                "(TestForm)toolStripMenuItem4.Text=Czwarte menu",
                "(TestForm)toolStripMenuItem5.Text=Piąte menu",
                "(TestForm)toolStripMenuItem6.Text=Szóste menu",
                "(TestForm)toolStripMenuItem7.Text=Siódme menu",
                "(TestForm)toolStripMenuItem8.Text=Ósme menu",
                "(TestForm)toolStripMenuItem9.Text=Dziewiąte menu",
                "(TestForm)toolStripMenuItem10.Text=Dziesiąte menu",
                "(TestForm)label1.Text=Etykietka",
                "(TestForm)linkLabel1.Text=Etykietka URL",
                "(TestForm)tabPage1.Text=Zakładka1",
                "(TestForm)tabPage2.Text=Zakładka2",
                "(TestForm)toolStripStatusLabel1.Text=Statusik1",
                "(TestForm)toolStripStatusLabel2.Text=Statusik2",
                "(TestForm)toolStripButton1.Text=Przycisk1",
                "(TestForm)toolStripButton2.Text=Przycisk2",
                "(TestForm)toolStripButton3.Text=Przycisk3",
                "(TestForm)toolStripButton4.Text=Przycisk3",
                "(TestForm)toolStripTextBox2.Text=Na górnym pasku",
                "(Messages)TestMessage = Testowa wiadomość",
                "",
            };
        private string[] englishLanguage = new string[]
            {
                "; Comment",
                ";",
                "locale en-US",
                "(TestForm)Text=My first form",
                "(TestForm)toolStripMenuItem1.Text=First menu",
                "(TestForm)toolStripMenuItem2.Text=Second menu",
                "(TestForm)toolStripMenuItem3.Text=Third menu",
                "(TestForm)toolStripMenuItem4.Text=Fourth menu",
                "(TestForm)toolStripMenuItem5.Text=Fifth menu",
                "(TestForm)toolStripMenuItem6.Text=Sixth menu",
                "(TestForm)toolStripMenuItem7.Text=Seventh menu",
                "(TestForm)toolStripMenuItem8.Text=Eight menu",
                "(TestForm)toolStripMenuItem9.Text=Ninenth menu",
                "(TestForm)toolStripMenuItem10.Text=Ten menu",
                "(TestForm)label1.Text=Label",
                "(TestForm)linkLabel1.Text=Label URL",
                "(TestForm)tabPage1.Text=Tab Page 1",
                "(TestForm)tabPage2.Text=Tab Page 2",
                "(TestForm)toolStripStatusLabel1.Text=Status information 1",
                "(TestForm)toolStripStatusLabel2.Text=Status information 2",
                "(TestForm)toolStripButton1.Text=Button 1",
                "(TestForm)toolStripButton2.Text=Button 2",
                "(TestForm)toolStripButton3.Text=Button 3",
                "(TestForm)toolStripButton4.Text=Button 1",
                "(TestForm)toolStripTextBox2.Text=On the top bar",
                "(Messages)TestMessage = Test message :)",
                "",
            };

        [TestMethod]
        public void ReadTest()
        {
            Translation translation = new Translation();
            translation.Read("Polish", polishLanguage);
            Assert.AreEqual(1, translation.Count);
            Assert.AreEqual("Mój pierwszy formularz", translation.GetText("Polish", "TestForm", "Text"));

            translation.CurrentLanguage = "Polish";
            Assert.AreEqual("Polish", translation.CurrentLanguage);
            translation.CurrentLanguage = "English";
            Assert.AreEqual("Polish", translation.CurrentLanguage);
            Assert.AreEqual("Mój pierwszy formularz", translation.GetText("TestForm", "Text"));

            translation.Read("English", englishLanguage);
            Assert.AreEqual("My first form", translation.GetText("English", "TestForm", "Text"));
            translation.Write(@"..\..\..\NLocalizer.Tests");
        }

        [TestMethod]
        public void AutoDetectCurrentLanguageTest()
        {
            Translation translation = new Translation();
            translation.Read(@"..\..\..\NLocalizer.Tests");
            Assert.AreEqual("Polish", translation.CurrentLanguage);
        }

        [TestMethod]
        public void WriteTest()
        {
            Translation translation = new Translation();
            translation.Read("Polish", polishLanguage);
            translation.Read("English", englishLanguage);
            Assert.AreEqual(2, translation.Count);

            Translation translationSecond = new Translation();
            translationSecond.Add("Polish", translation["Polish"]);
            translationSecond.Add("English", translation["English"]);

            translation.Write(@"..\..\..\NLocalizer.Tests");
            translation.Clear();
            Assert.AreEqual(0, translation.Count);

            translation.Read(@"..\..\..\NLocalizer.Tests");
            Assert.AreEqual(2, translation.Count);
            foreach (var lang in translationSecond)
                foreach (var cl in lang.Value)
                    foreach (var prop in cl.Value)
                    {
                        Assert.IsTrue(translation.Exists(lang.Key));
                        Assert.IsTrue(translation.Exists(lang.Key, cl.Key));
                        Assert.IsTrue(translation.Exists(lang.Key, cl.Key, prop.Key));
                        Assert.AreEqual(prop.Value, translation.GetText(lang.Key, cl.Key, prop.Key));
                    }
        }
    }
}
