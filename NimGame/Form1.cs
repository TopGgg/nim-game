using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGame
{
    public partial class Form1 : Form
    {
        public string turn = "player1";
        public int matches = 16;
        public int? row = null;
        public List<PictureBox> clicked = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }
       

        public void onMatchClick(object sender, EventArgs args)
        {
            if(sender.GetType() == typeof(PictureBox))
            {
                PictureBox img = (PictureBox)sender;
                finish.Enabled = true;
                if (clicked.Contains(img))
                {
                    clicked.Remove(img);
                    img.BorderStyle = BorderStyle.None;
                    return;
                }
                if (row == null)
                {
                    row = int.Parse((string)img.Tag);
                    img.BorderStyle = BorderStyle.Fixed3D;
                    clicked.Add(img);
                }
                else if (int.Parse((string)img.Tag) == row)
                {
                    img.BorderStyle = BorderStyle.Fixed3D;
                    clicked.Add(img);
                }
               
            }
            
        }

        

        private void finish_Click(object sender, EventArgs e)
        {
            foreach(PictureBox img in clicked)
            {
                img.Visible = false;
            }
            
            finish.Enabled = false;
            matches -= clicked.Count;
            clicked.Clear();
            row = null;
            if(matches == 0)
            {
                playerlbl.Text = turn + " lost.";
                return;
            }
            turn = turn == "player1" ? "player2" : "player1";
            playerlbl.Text = "Turn: " + char.ToUpper(turn[0]) + turn.Substring(1);
        }

        
    }
}
