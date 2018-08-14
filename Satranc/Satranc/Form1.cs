using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satranc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] btn;
        int k;
        bool mavi = false;
        string eskibuton;
        private void button1_Click(object sender, EventArgs e)
        {
            btn = new Button[8,8];
            for (int i = 0; i < 8; i++)
            {
                for (int s = 0; s < 8; s++)
                {
                    btn[i,s] = new Button();
                    btn[i, s].Size = new Size(50, 50);
                    btn[i, s].Location = new Point(50 * s, 50 * i);
                    btn[i, s].Text = (i +"+"+ s +"+"+ k).ToString();
                    btn[i, s].Name = "btn_" + i + "_" + s + "_" + k;                   
                    panel1.Controls.Add(btn[i, s]);
                    btn[i, s].Click += Btn_Click;
                    btn[i, s].Visible = true;
                    btn[i, s].BackColor = Color.White;
                    taslar(btn[i, s], s, i, k);
                    k++;
                }
            }
        }

        public void taslar(Button button, int s, int i, int k)
        {
            switch (i)
            {
                case 6:
                    button.Text = "BPiyon";
                    break;
                    
                case 0:
                    switch (s)
                    {
                       case 0:
                            button.Text = "SKale";
                            break;

                        case 7:
                            button.Text = "SKale";
                            break;

                        case 1:
                            button.Text = "SAt";
                            break;

                        case 6:
                            button.Text = "SAt";
                            break;

                        case 2:
                            button.Text = "SFil";
                            break;

                        case 5:
                            button.Text = "SFil";
                            break;

                        case 3:
                            button.Text = "SSah";
                            break;
                        case 4:
                            button.Text = "SVezir";
                            break;
                    }
                    break;

                case 1:
                    button.Text = "SPiyon";
                    break;

                case 7:
                    switch (s)
                    {
                        case 0:
                            button.Text = "BKale";
                            break;

                        case 7:
                            button.Text = "BKale";
                            break;

                        case 1:
                            button.Text = "BAt";
                            break;

                        case 6:
                            button.Text = "BAt";
                            break;

                        case 2:
                            button.Text = "BFil";
                            break;

                        case 5:
                            button.Text = "BFil";
                            break;

                        case 3:
                            button.Text = "BSah";
                            break;
                        case 4:
                            button.Text = "BVezir";
                            break;
                    }
                    break;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button sbuton = (sender as Button);
            
            var splitedName = sbuton.Name.Split('_');
            var dsira = int.Parse(splitedName[1]);
            var ysira = int.Parse(splitedName[2]);
            var bsayisi = int.Parse(splitedName[3]);
            if (eskibuton == null)
            {
                eskibuton = sbuton.Text;
            }

            if (eskibuton== "BPiyon")
            {
                BeyazPiyon(sbuton, dsira, ysira, bsayisi);
            }
            else if(eskibuton== "SPiyon")
            {
                SiyahPiyon(sbuton, dsira, ysira, bsayisi);
            }
            else
            {
                eskibuton = null;
            }
           
        }

        private void SiyahPiyon(Button sbuton, int dsira, int ysira, int bsayisi)
        {
            if (mavi == true)
            {

                sbuton.Text = eskibuton;
                btn[dsira, ysira].BackColor = Color.White;
                btn[dsira - 1, ysira].Text = (dsira - 1 + "+" + ysira + "+" + bsayisi).ToString();
                mavi = false;

                for (int i = 0; i < 8; i++)
                {
                    for (int s = 0; s < 8; s++)
                    {
                        btn[i, s].Enabled = true;
                    }
                }
                eskibuton = null;
            }
            else if (sbuton.Text == "SPiyon")
            {
                btn[dsira + 1, ysira].BackColor = Color.Blue;
                mavi = true;
                eskibuton = sbuton.Text;
                for (int i = 0; i < 8; i++)
                {
                    for (int s = 0; s < 8; s++)
                    {
                        btn[i, s].Enabled = false;
                    }
                }
                btn[dsira + 1, ysira].Enabled = true;
            }
        }

        private void BeyazPiyon(Button sbuton, int dsira, int ysira, int bsayisi)
        {
            if (mavi == true)
            {

                sbuton.Text = eskibuton;
                btn[dsira, ysira].BackColor = Color.White;
                btn[dsira+1, ysira].Text = (dsira+1 + "+" + ysira + "+" + bsayisi).ToString();
                mavi = false;

                for (int i = 0; i < 8; i++)
                {
                    for (int s = 0; s < 8; s++)
                    {
                        btn[i, s].Enabled = true;
                    }
                }
                eskibuton = null;
            }
            else if (sbuton.Text == "BPiyon")
            {
                btn[dsira - 1, ysira].BackColor = Color.Blue;
                mavi = true;
                eskibuton = sbuton.Text;
                for (int i = 0; i < 8; i++)
                {
                    for (int s = 0; s < 8; s++)
                    {
                        btn[i, s].Enabled = false;
                    }
                }
                btn[dsira - 1, ysira].Enabled = true;
            }
        }

        
    }
}
