using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public Form1()
        {
            InitializeComponent(); 
            endText1.Text = "Game Over!";
            endText2.Text = "Your final score is: " + score;
            gameDesigner.Text = "Game Designed By your name ChangeMaker";

            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;

            // start--> below code is for moving pipe from right to left(one end of screen to other) 

            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            lblScore.Text = "Score : " + score;
            // end <--  below code is for moving pipe from right to left(one end of screen to other) 



            //start--> below code is for once pipe moves from right to left, it has to come back again on screen

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            //end <-- below code is for once pipe moves from right to left, it has to come back again on screen


            /// start ==> if bird collides with any of the pipe or the ground
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))     // ** Bounds means Borders 
            {

                EndGame();

            }
            /// end <== if bird collides with any of the pipe or the ground
            /// 

            if (score >5)
            {
                pipeSpeed = 15;
            }

            /// start ==> this code is for if my birds goes out of the top border
            /// 
            if (flappyBird.Top <-25)
            {
                EndGame();
            }
            
            
            // <== end
        }

        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            // When key is released
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            // When space bar is pressed
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
            // ie ==> if space key is pressed we reverse the gravity from 10 to -10;
        }

        private void EndGame()
        {
            gameTimer.Stop();
            lblScore.Text += " Game Over !!!";

            endText1.Text = "Game Over!";
            endText2.Text = "Your final score is: " + score;
            gameDesigner.Text = "Game Designed By your name ChangeMaker";

            endText1.Visible = true;
            endText2.Visible = true;
            gameDesigner.Visible = true;
        }
    }
}
