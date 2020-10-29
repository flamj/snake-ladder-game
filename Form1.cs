using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeLadder
{
    public partial class snake : Form
    {
        int position = 0;
        int newposition = 0;
        

        public snake()
        {
            InitializeComponent();
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game will generate the condition on the text box. \n Players are only require to click the \"Roll\" button", "About");
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void roll_Click(object sender, EventArgs e)
        {
            Random dice = new Random();
            int roll = dice.Next(1, 7);

            newposition = position + roll;
            String con = condition(newposition);
            newposition = ladder(newposition);
            newposition = eaten(newposition);
           
            if(newposition >= 100)
            {
                display.AppendText(position + " rolled " + roll + " " + con + " = position 100" + "\n");
                MessageBox.Show("You Won!", "Message");
            }
            else
            {
                display.AppendText(position + " rolled " + roll + " " + con + " = position " + newposition + "\n");
                position = newposition;
            }
        }

        private String condition(int value)
        { 
            if (value == 3 || value == 6 || value == 20 || value == 36 || value == 63 || value == 68)
            {
                return "Ladder is used";

            } else if (value == 25 || value == 33 || value == 47 || value == 65 || value == 87 || value == 91 || value == 99)
            {
                return "Eaten by snake";
            }
            return "";
        }

        private int ladder (int value)
        {
            switch (value)
            {
                case 3: return 51;

                case 6: return 27;

                case 20: return 60;

                case 36: return 55;

                case 63: return 95;

                case 68: return 98;

            }

            return value;

        }

        private int eaten(int value)
        {
            switch (value)
            {
                case 91: return 61;

                case 87: return 57;

                case 99: return 69;

                case 65: return 52;

                case 47: return 19;

                case 25: return 5;

                case 33: return 1;

            }

            return value;

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Text = "";
            position = 0;
            newposition = 0;
        }
    }
}
