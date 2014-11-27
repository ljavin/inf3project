﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using game.backend;

namespace game.Parser
{
    class ParserMap
    {

        private ParserGate parserGate;
        private String message;
        private bool messageIsValid;

        public ParserMap(ParserGate parserGate, String message, bool validity)
        {
            setParserGate(parserGate);
            setMessage(message);
            setMessageIsValid(validity);
        }

        /// <summary>
        /// Getter for the parserGate variable.
        /// </summary>
        /// <returns>Returns the value of the parserGate variable.</returns>
        private ParserGate getParserGate()
        {
            return this.parserGate;
        }

        /// <summary>
        /// Getter for the message variable.
        /// </summary>
        /// <returns>Returns the value of the message variable.</returns>
        private String getMessage()
        {
            return this.message;
        }

        /// <summary>
        /// Getter for the messageIsValid variable.
        /// </summary>
        /// <returns>Returns the value of the messageIsValid variable.</returns>
        private bool getMessageIsValid()
        {
            return this.messageIsValid;
        }

        /// <summary>
        /// Setter for the parserGate variable. The new value is only set if parameter != null.
        /// </summary>
        /// <param name="parserGate">The ParserGate object which created this object.</param>
        private void setParserGate(ParserGate parserGate)
        {
            if (parserGate != null)
                this.parserGate = parserGate;
        }

        /// <summary>
        /// Setter for the message variable. The new value is only set if parameter != null.
        /// </summary>
        /// <param name="message">The part of the original message passed down from the calling ParserGate object.</param>
        private void setMessage(String message)
        {
            if (message != null)
                this.message = message;
        }

        /// <summary>
        /// Setter for the messageIsValid variable. The new value is only set if parameter != null.
        /// </summary>
        /// <param name="validity">Expresses the current state (true = valid, false = invalid) of the message in the parsing process.</param>
        private void setMessageIsValid(bool validity)
        {
            
                this.messageIsValid = validity;
        }

        /// <summary>
        /// Parses the message applying the "MAP" rule.
        /// </summary>
        /// <param name="partOfMessage">Part of original message, is expected to fit the "MAP" rule.</param>
        private void parseMap(String partOfMessage)
        {
            Contract.Requires(partOfMessage != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "MAPCELL" rule.
        /// </summary>
        /// <param name="partOfMessage">Part of original message, is expected to fit the "MAPCELL" rule.</param>
        public void parseMapcell(String partOfMessage)
        {
            Contract.Requires(partOfMessage != null && messageIsValid);
            if (partOfMessage != null && messageIsValid)
            {
                partOfMessage = this.parserGate.deleteLines("begin:cell", "end:cell", partOfMessage);
                String properties = partOfMessage.Substring(partOfMessage.IndexOf("begin:props"));
                partOfMessage = partOfMessage.Remove(partOfMessage.IndexOf("begin:props"));
                partOfMessage = partOfMessage.Trim();
                String[] rowsAndColumns = Regex.Split(partOfMessage, "\n");
                int row = Convert.ToInt32(rowsAndColumns[0]);
                int column = Convert.ToInt32(rowsAndColumns[1]);
                List<FieldType> fieldTypes = this.parseProperty(properties);

            }
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "PROPERTY" rule.
        /// </summary>
        /// <param name="partOfMessage">Part of original message, is expected to fit the "PROPERTY" rule.</param>
        private List<FieldType> parseProperty(String partOfMessage)
        {
            Contract.Requires(partOfMessage != null && messageIsValid);
            if (partOfMessage != null && messageIsValid)
            {
                partOfMessage = this.parserGate.deleteLines("begin:props", "end:props", partOfMessage);
                partOfMessage = partOfMessage.Trim();
                String[] fieldTypes = Regex.Split(partOfMessage, "\n");
                List<FieldType> properties = new List<FieldType>();
                foreach (String s in fieldTypes)
                {
                    switch (s)
                    {
                        case "WALKABLE":
                            properties.Add(FieldType.WALKABLE);
                            break;
                        case "WALL":
                            properties.Add(FieldType.WALL);
                            break;
                        case "FOREST":
                            properties.Add(FieldType.FOREST);
                            break;
                        case "WATER":
                            properties.Add(FieldType.WATER);
                            break;
                        case "HUNTABLE":
                            properties.Add(FieldType.HUNTABLE);
                            break;

                    }
                }
                Contract.Ensures(messageIsValid);
                return properties;
            }
            else
            {
                this.messageIsValid = false;
                throw new ArgumentException("Message is invalid. ParserMap, parseProperties.");
            }
            
        }

        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(parserGate != null);
        }
    }
}
