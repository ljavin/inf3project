﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace game.client
{
    public class ParserGate
    {
        String message;
        bool messageIsValid;
        bool messageIsAvailable;

        /// <summary>
        /// Receives incoming messages from the buffer.
        /// Ensures that incoming messages from the server contain valid information.
        /// The information is then extracted and passed down to the GameManager
        /// </summary>
        ParserGate()
        {

        }

        /// <summary>
        /// Gets one full message from the buffer, if one is available, and stores it in the message variable.
        /// </summary>
        void getMsg()
        {
            Contract.Requires(messageIsAvailable);
            Contract.Ensures(message != null);
        }

        /// <summary>
        /// Parses the message and extracts information from it. Will call other methods, choosing based on message content.
        /// </summary>
        /// <param name="message">The message extracted from the buffer.</param>
        void parse(String message)
        {
            Contract.Requires(message != null);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "MESSAGE" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "MESSAGE" rule.</param>
        void parseMsg(String p_msg){
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "ANSWER" rule, which further applies the "OKAY", "DENY", "UNKNOWN" and "INVALID" rules.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "ANSWER" rule</param>
        void parseAns(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "YOURID" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "YOURID" rule.</param>
        void parseYourId(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "TIME" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "TIME" rule.</param>
        void parseTime(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "ONLINE" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "ONLINE" rule.</param>
        void parseOnline(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "ENTITIES" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "ENTITIES" rule.</param>
        void parseEntities(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }

        /// <summary>
        /// Parses the message applying the "PLAYERS" rule.
        /// </summary>
        /// <param name="p_msg">Part of original message, is expected to fit the "PLAYERS" rule.</param>
        void parseMsg(String p_msg)
        {
            Contract.Requires(p_msg != null && messageIsValid);
            Contract.Ensures(messageIsValid);
        }
       

        /// <summary>
        /// After parsing the message, this method passes the extracted information on to methods required to process the information.
        /// </summary>
        void passInf()
        {
            Contract.Requires(messageIsValid);
            Contract.Ensures(message == null);
        }
    }
}
