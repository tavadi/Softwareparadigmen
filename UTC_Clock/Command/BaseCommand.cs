﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    //Interface für Cmd
    interface BaseCommand
    {
        void Execute(Command cmd);

        void Undo(Command cmd);
    }
}
