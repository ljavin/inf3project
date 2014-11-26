﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Dragon : Token
    {

        public Dragon(int id, int isbusy, String desc, int x, int y)
            : base(id, isbusy, desc, x, y)
        {

        }

        public Dragon(int xPos, int yPos)
        {
            this.setXPos(xPos);
            this.setYPos(yPos);
        }

    }
}
