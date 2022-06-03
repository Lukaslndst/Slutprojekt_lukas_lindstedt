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
        int näraminor = 0;
        int i = 0;
        int j = 0;
        int antalminor = 5;
        Font minefont = new Font("Calibri", 20);
        //alla variabler och fonter som kommer användas

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    ruta[i, j] = 4;
                    // detta gör så att inga rutor genereras innan spelet har börjat
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush Blank = new SolidBrush(Color.LightSlateGray);
            SolidBrush Flag = new SolidBrush(Color.Red);
            Pen falseflag = new Pen(Color.Red);
            //de olika penslarna som kommer skapa rutor. kan även bytas ut mot bilder m.m. men valde att hålla det simpelt


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //dessa for-looper går över varje kordinat i spelet. de olika if-satserna tar reda på hur rutan ska se ut
                    //det vill säga om den är blank, öppen, flagga eller mina
                    if (ruta[i,j] == 0)
                    {
                        g.FillRectangle(Blank, i * 40, j * 40, 30, 30);
                        //det finns två 2D arrays. en säger om rutan har en mina, den kallas minvärde[,]. den andra heter
                        //ruta[,] och varje kordinat har ett värde som säger om rutan är oöppnad, öppnad eller markerad med flagga.
                        //denna if-sats gör en grå ruta om rutan är oöppnad
                    }
                    if (ruta[i, j] == 1) // denna sats går om rutan har värdet 1 dvs. att den är öppnad.
                    {
                        if (minevärde[i,j] == 0)// denna sats kollar om rutan har en mina.
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
                            //har rutan ingen mina så räknar den antalet närliggande minor genom att adera varje närliggande rutors
                            //minvärde[,] som antingen är 1 eller 0. anledningen till alla if-satser är för om rutan man öppnar ligger
                            //vid en kant koomer den försöka räkna rutor bortom kanten som inte finns vilket orsakar en krash.
                            //if-satserna kollar så kordinaten inte ligger på en kant innan den räknar värdet.
                        }
                        else
                        {
                            g.FillRectangle(Blank, i * 40, j * 40, 10, 10);
                            // om rutan har en mina ritas en liten kvadratisk mina
                        }
                    }
                    if (ruta[i, j] == 2) //om ruta[,] har värdet två vilket bara kan hända om man högerklickar ritas en röd ruta för att markera den
                    {
                        g.FillRectangle(Flag, i * 40, j * 40, 30, 30);
                    }
                    if (ruta[i,j] == 3)
                    {
                        g.DrawRectangle(falseflag, i * 40, j * 40, 30, 30);
                        näraminor = 0;
                        if (i - 1 >= 0)
                        {
                            näraminor = näraminor + minevärde[i - 1, j];
                            if (j - 1 >= 0) { näraminor = näraminor + minevärde[i - 1, j - 1]; }
                            if (j + 1 < 8) { näraminor = näraminor + minevärde[i - 1, j + 1]; }
                        }
                        if (i + 1 < 8)
                        {
                            näraminor = näraminor + minevärde[i + 1, j];
                            if (j - 1 >= 0) { näraminor = näraminor + minevärde[i + 1, j - 1]; }
                            if (j + 1 < 8) { näraminor = näraminor + minevärde[i + 1, j + 1]; }
                        }
                        if (j - 1 >= 0) { näraminor = näraminor + minevärde[i, j - 1]; }
                        if (j + 1 < 8) { näraminor = näraminor + minevärde[i, j + 1]; }
                        string varförkanintestringvaraintjahatarprogramering = näraminor.ToString();
                        g.DrawString(varförkanintestringvaraintjahatarprogramering, minefont, Blank, i * 40, j * 40);
                        //om du markerar på fel plats visas en röd ruta men med närliggande minor displayat. exakt samma kod
                    }
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.Clear(ruta, 0, ruta.Length); //steg ett i varje nytt spel är att radera det gamla. det gör de första två raderna här.
            Array.Clear(minevärde, 0, ruta.Length);
            int x = 0;
            antalminor = trackBar1.Value;
            Random kordinat = new Random();
            while (x < antalminor)
            {
                //antalminor är hur många minor som genereras. det värdet bestäms av en trackbar.
                //sedan slumpas en kordinat där minvärdet blir ett. jag har en while sats då en kordinat får bara generera en mina
                //en gång. if-satsen tar reda på om en mina redan finns och räknar x ökar bara om en ny mina genererats.
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
            if (e.Button == MouseButtons.Left)
            {
                ruta[mousex, mousey] = 1;
                if (minevärde[mousex, mousey] == 1)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++) //trycker du på en mina slutar spelet genom att alla rutor öppnas
                        {
                            if (ruta[i, j] == 0)
                            {
                                ruta[i, j] = 1;
                            }
                            if (ruta[i, j] == 2)
                            {
                                if (minevärde[i, j] == 0) // den här delen av koden sätter värdet 3 i rutan om du markerat fel
                                {
                                    ruta[i, j] = 3;
                                }
                            }
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right) { ruta[mousex, mousey] = 2; }
            //musens kordinat tas reda på här och när en knapp är tryckt vet pogrammet på vilken ruta och vilken knapp
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
            //detta är en debug funktion och den öppnar alla rutor med en knapp
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            antalminor = trackBar1.Value;
            textBox1.Text = antalminor.ToString();
            //detta är bara en kod som visar det aktuella värdet från trackbaren så du vet hur många minor du genererar.
        }
    }
}
