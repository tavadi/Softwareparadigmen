using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTC_Clock
{
    class Helpme
    {
        public Helpme()
        {
            MessageBox.Show(@"
Erstellt eine analoge Uhr mit Timezone +1 an position x  &  y: 
show -t analog -z 1 -x 100 -y 100  

Erstellt eine digitale Uhr mit Timezone -3 an position x  &  y: 
show -t digital -z -3 -x 200 -y 300

Setzt die SingletonClock auf 8:20:30:
set -h 8 -m 20 -s 30

Setzt die SingletonClock auf 10:XX:25 wobei hier XX für die vorhereige Minutenanzahl steht:
set -h 10 -s 25

Dekrementiert die SingletonClock um 2 Stunden 1 Minute und 3 Sekunden:
dec -h -h -m -s -s -s 

Inkrementiert die SingletonClock um eine Stunde und 3 Minuten:
inc -h -m -m -m 

Erstellt ein Macro namens NewYorkAnalog:
create NewYorkAnalog show -t analog -z -6 -x 100 -y 100 

Führt das Macro NewYorkAnalog aus:
execute NewYorkAnalog

Macht die letzten Befehle(set-inc-dec-show-execute) rückgängig:
undo 

Wiederholt den letzten Befehl oder macht das letzte Undo rückgängig:
redo

Zeigt Hilfe an
help");
        }

    }
}
