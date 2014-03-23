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


    public partial class DigitalClock : Form
    {

        public DateTime myTime { get; set; }

       
        public DigitalClock()
        {
            InitializeComponent();
            myTimer.Tick += ClockTimer_Tick;
            myTimer.Enabled = true;
            myTimer.Interval = 1;
            myTimer.Start();
           
        }


        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = myTime.ToString("hh-mm-ss");
            Refresh();
        }



        private Timer myTimer = new Timer();
        /// <summary> 
        /// The timer to update the hands 
        /// </summary> 

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void DigitalClock_Load(object sender, EventArgs e)
        {
            label1.AutoSize = true;
        }
    }
}
