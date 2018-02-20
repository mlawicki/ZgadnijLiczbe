using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZgadnijLiczbe
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        int zgadnietoMin = 1;
        int zgadnietoMax = 100;
        int liczbaProb = 1;
        int liczbaDoZgadniecia;
        


        public Form1()
        {
           
            InitializeComponent();
            liczbaDoZgadniecia = rnd.Next(1, 100);
            label1.Text = "Zgadnij liczbę z zakresu: "+zgadnietoMin +" - " + zgadnietoMax;
            label2.Text = liczbaDoZgadniecia.ToString();
            label4.Text = liczbaProb.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int wartoscWpisana;
            if (!int.TryParse(textBox1.Text, out wartoscWpisana))
            {
                MessageBox.Show("Wpisany tekst:\n"+textBox1.Text+"\nnie jest liczbą całkowitą");
            }
            if (wartoscWpisana<zgadnietoMin||wartoscWpisana>zgadnietoMax)
            { MessageBox.Show("Podaj liczbę większą od: "+zgadnietoMin+" i mniejszą od:"+ zgadnietoMax);}
            sprawdzenie();
              label1.Text = "Zgadnij liczbę z zakresu: " + zgadnietoMin+ " - " + zgadnietoMax;
            textBox1.Clear();


        }

        public void sprawdzenie()
        {
            int wartoscWpisana2;
            int.TryParse(textBox1.Text, out wartoscWpisana2);
            if (liczbaDoZgadniecia!=wartoscWpisana2)
            {
                                if (liczbaDoZgadniecia>wartoscWpisana2)
                                {   wartoscWpisana2 = zgadnietoMax;
                                    label1.Text = "Zgadnij liczbę z zakresu: "+zgadnietoMin.ToString()+" - "+ zgadnietoMax.ToString();

                                    liczbaProb++;
                                    label4.Text = liczbaProb.ToString();

                                }
                                if (liczbaDoZgadniecia<wartoscWpisana2)
                                {
                                    wartoscWpisana2 = zgadnietoMin;
                                    label1.Text = "Zgadnij liczbę z zakresu: "+zgadnietoMin.ToString()+" - "+zgadnietoMax.ToString();
                                    liczbaProb++;
                                    label4.Text = liczbaProb.ToString();
                                } 
            }
            else
            { podsumowanie(); } 
        }
        public void podsumowanie()
        {

            DialogResult dr = MessageBox.Show("Udało Ci się zganąć po " + liczbaProb + " próbach.\nCzy chcesz zgadywać ponownie inną liczbę?","", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else { Application.Exit(); }
            
        }
    }
}

