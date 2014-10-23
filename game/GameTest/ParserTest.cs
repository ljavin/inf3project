﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using game.client;

namespace GameTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void getMessageTest()
        {
            ParserGate parserGate = new ParserGate();
            parserGate.getMessage();
            Assert.IsNotNull(parserGate.message);
        }

        public void parseTest()
        {
            ParserGate parserGate = new ParserGate();
            parserGate.parse(parserGate.message);
            Assert.IsTrue(parserGate.messageIsValid);
        }

        public void parseMessageTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseAnswerTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseYourIdTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseTimeTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseOnlineTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseEntitiesTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parsePlayersTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseUpdateTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseDeleteTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseChallengeTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseResultTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseOpponentTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseDragonTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parsePlayerTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseMapTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parseMapcellTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }

        public void parsePropertyTest()
        {
            bool messageIsValid = true;
            Assert.IsTrue(messageIsValid);
        }
    }
}
