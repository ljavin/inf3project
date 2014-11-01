﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics.Contracts;

namespace game.client
{
    public class ClientBuffer
    {
        private List<String> fifo;
        private const int MAX_SIZE = 49;
        private static ClientBuffer buffer = new ClientBuffer();
       

        private ClientBuffer()
        {
            Contract.Requires(MAX_SIZE > 0);
            fifo = new List<String>();
            Contract.Ensures(ClientBuffer.buffer != null);
            Contract.Ensures(fifo != null);
        }

        /// <summary>
        /// method for adding messages to the buffer
        /// </summary>
        /// <param name="message">messages to add</param>
        public void put(String message)
        {
            Contract.Requires(message != null);
            Contract.Requires(message.Length > 0);
            Contract.Requires(fifo != null);
            Contract.Requires(!(this.isFull()));
            if ((message == null)||(message.Length < 0)||(fifo == null))
            {
                throw new ArgumentException("The message is null or smaller 0, or the fifo is null");
            }
            else
            {
                fifo.Add(message);
            }
            Contract.Ensures(!this.isEmpty());
        }

        /// <summary>
        /// method for removing and getting the first element of the buffer
        /// </summary>
        /// <returns>first element of the buffer</returns>
        public String getElement()
        {
            Contract.Requires(fifo != null);
            Contract.Requires(fifo.ElementAt(0) != null);
            Contract.Requires(!(this.isEmpty()));
            if ((fifo == null)||(this.isEmpty()))
            {
                throw new ArgumentException("Fifo is null or the Buffer is empty");
            }
            else
            {
                String message = fifo.ElementAt(0);
                fifo.RemoveAt(0);
              return message;
            }
            Contract.Ensures(!this.isFull());
            return "";
        }

        /// <summary>
        /// method returns whether the buffer is empty or not
        /// </summary>
        /// <returns>buffer empty or not</returns>
        public Boolean isEmpty()
        {
            Contract.Requires(fifo != null);
            Boolean isEmpty = false;
            if (fifo.Count == 0)
            {
                isEmpty = true;
            }
            return isEmpty;
            Contract.Ensures(isEmpty != null);
        }

        /// <summary>
        /// method returns whether the buffer is full or not
        /// </summary>
        /// <returns>buffer full or not</returns>
        public Boolean isFull()
        {
            Contract.Requires(fifo != null);
            Boolean isFull = false;
            if (fifo.Count == MAX_SIZE)
            {
                isFull = true;
            }
            return isFull;
            Contract.Ensures(isFull != null);
        }

        /// <summary>
        /// method returns the current size of the buffer
        /// </summary>
        /// <returns>current size</returns>
        public int getSize()
        {
            Contract.Requires(fifo != null);
            Contract.Ensures(Contract.Result<int>() >= 0);
            return fifo.Count;
        }

        /// <summary>
        /// method clear the buffer
        /// </summary>
        public void clear()
        {
            Contract.Requires(fifo != null);
            fifo.Clear();
        }




        /// <summary>
        /// method returns a static instance of the buffer
        /// implemented visa singleton-architecture
        /// </summary>
        /// <returns>current buffer instance</returns>
        public static ClientBuffer getBufferInstance() 
        {
            return buffer;
        }

        [ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            Contract.Invariant(buffer != null);
            Contract.Invariant(fifo != null);
            Contract.Invariant(this.getSize() >= 0);
            Contract.Invariant(this.getSize() <= MAX_SIZE);
        }

    }
}
