using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTC_Clock
{
    //show -t analog -z 3 -x 1500 -y 1500
    public partial class AnalogClock : Form
    {
        private int myPosX;
        private int myPosY;

        public AnalogClock()
        {
            InitializeComponent();
        }

        public AnalogClock(int x, int y)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.myPosX = x;
            this.myPosY = y;
            Console.WriteLine("posX: " + myPosX + " posY: " + myPosY);
            

        }

        private void positioning(object sender, EventArgs e)
        {
            this.Top = myPosX;
            this.Left = myPosY;
        }

    }
}
