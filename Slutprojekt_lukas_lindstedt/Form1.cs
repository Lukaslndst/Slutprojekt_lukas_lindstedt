using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slutprojekt_lukas_lindstedt
{
    //Autor:lukas lindstedt
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        int[,] ruta = new int[8, 8];
        int[,] minevärde = new int[8, 8];
        int i = 0;
        int j = 0;
        string antalminor = "";
        int svårighetsgrad = 0;
        Font minefont = new Font("Calibri", 8);

        private void Form1_Load(object sender, EventArgs e)
        {
            ruta[2,4] = 1;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush N = new SolidBrush(Color.LightSlateGray);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ruta[i,j] == 0)
                    {
                        g.FillRectangle(N, i * 40, j * 40, 30, 30);
                        g.DrawString(antalminor,minefont ,N , i * 40, j *40);
                    }
                    
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            Random kordinat = new Random();
            while (x <= svårighetsgrad)
            {
                //random kordinat här
                //if(kordinaten redan har mina)
            }
            //en while sats används ifall att man får en kordinat som redan har en mina
            //så kan man skriva så denna loopen inte räknas.
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            panel1.Invalidate();
        }
    }
}
