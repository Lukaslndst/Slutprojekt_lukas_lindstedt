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
        int näraminor = 0;
        int antalminor = 5;
        Font minefont = new Font("Calibri", 20);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush Blank = new SolidBrush(Color.LightSlateGray);
            SolidBrush Flag = new SolidBrush(Color.Red);


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ruta[i,j] == 0)
                    {
                        g.FillRectangle(Blank, i * 40, j * 40, 30, 30);
                    }
                    if (ruta[i, j] == 1)
                    {
                        if (minevärde[i,j] == 0)
                        {

                            näraminor = 0;
                            if (i-1 >= 0)
                            {
                                näraminor = näraminor + minevärde[i - 1, j];
                                if (j-1 >= 0) { näraminor = näraminor + minevärde[i - 1, j - 1]; }
                                if (j+1 < 8) { näraminor = näraminor + minevärde[i - 1, j + 1]; }
                            }
                            if (i+1 < 8)
                            {
                                näraminor = näraminor + minevärde[i + 1, j];
                                if (j - 1 >= 0) { näraminor = näraminor + minevärde[i + 1, j - 1]; }
                                if (j + 1 < 8) { näraminor = näraminor + minevärde[i + 1, j + 1]; }
                            }
                            if (j-1 >= 0) { näraminor = näraminor + minevärde[i, j - 1]; }
                            if (j+1 < 8) { näraminor = näraminor + minevärde[i, j + 1]; }
                            string varförkanintestringvaraintjahatarprogramering = näraminor.ToString();
                            g.DrawString(varförkanintestringvaraintjahatarprogramering, minefont, Blank, i * 40, j * 40);
                        }
                        else
                        {
                            g.FillRectangle(Blank, i * 40, j * 40, 10, 10);
                        }
                    }
                    if (ruta[i,j] == 2)
                    {
                        g.FillRectangle(Flag, i * 40, j * 40, 30, 30);
                    }
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.Clear(ruta, 0, ruta.Length);
            Array.Clear(minevärde, 0, ruta.Length);
            int x = 0;
            antalminor = trackBar1.Value;
            Random kordinat = new Random();
            while (x < antalminor)
            {
                i = kordinat.Next(0, 8);
                j = kordinat.Next(0, 8);
                if (minevärde[i,j] == 0)
                {
                    minevärde[i, j] = 1;
                    x++;
                }
            }
            
            panel1.Invalidate();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int mousex = e.X / 40;
            int mousey = e.Y / 40;
            if (e.Button == MouseButtons.Left) { ruta[mousex, mousey] = 1; }
            if (e.Button == MouseButtons.Right) { ruta[mousex, mousey] = 2; }
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ruta[i, j] = 1;
                    
                }
            }
            panel1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            antalminor = trackBar1.Value;
            textBox1.Text = antalminor.ToString();
        }
    }
}
