﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdSet : BaseCommand
    {

        public void Execute(Command cmd)
        {
            Console.WriteLine("SETCMD");
        }
    }
}
