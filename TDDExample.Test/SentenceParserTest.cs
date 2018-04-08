using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDExample;
using NUnit.Framework;


namespace TDDExample.Test{ 

   [TestFixture]
   public class SentenceParserTest
    {
        SentenceParser sentenceParser ;

        [TestFixtureSetUp]
        public void SetupTest()
        {
            sentenceParser = new SentenceParser();
        }


        [Test]
        public void GetNoofWordsInStringTest()
        {
            string str = "ceci est un test";

            int nombre = sentenceParser.GetNoofWordsInString(str);

            Assert.AreEqual(4, nombre);
        }


        [Test]
        public void FizzBuzTest()
        {
            int nombre = 15;
            string retour = sentenceParser.FizzBuz(nombre);
            Assert.AreEqual("FizzBuz", retour);

        }

        [Test]
        public void isCubeTest()
        {
          int x = 27;
          bool result = sentenceParser.isCube(x);
          Assert.AreEqual(true, result);
        }



        [TestFixtureTearDown]
        public void TearDownTest()
        {
            sentenceParser = null;
        }


    }
}
