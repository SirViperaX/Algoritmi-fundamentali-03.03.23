using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmi_fundamentali_03._03._23
{
    public partial class Form1 : Form
    {
        Label[] D;
        Random rnd = new Random();
        int[] T = new int[5];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Create();
        }

        public void Create()
        {
            D = new Label[5];
            for(int i =0; i < D.Length; i++)
            {
                D[i] = new Label();
                D[i].AutoSize = false;
                D[i].Size = new Size(80, 80);
                D[i].BorderStyle = BorderStyle.FixedSingle;
                D[i].Parent = this;
                D[i].Location = new Point(50 + i * 85, 50);
                D[i].Font = new Font("Arial", 40, FontStyle.Regular);
                D[i].Text = "x";
                D[i].TextAlign = ContentAlignment.MiddleCenter;
            }
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < D.Length; i++) 
            {
                T[i] = rnd.Next(2, 15);
                D[i].Text = ValueToCard(T[i]);
            }
            outputLabel.Text = IDxToFormation(Calculus());
        }

        private string ValueToCard(int x)
        {
           if(x<10)
                return x.ToString();
           switch(x)
           {
                case 10:
                    return "X";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                case 14:
                    return "A";
           }
            return "error";
        }
        public int Calculus()
        {
            int[] Nr = new int[15];
            for(int i =0 ; i < T.Length; i++)
            {
                Nr[T[i]]++;
            }
            int max = 0;
            int np2 = 0;
            for(int i = 0 ; i < Nr.Length; i++) 
            { 
                if (Nr[i] > max)
                    max = Nr[i];
                if (Nr[i] == 2)
                    np2++;
            }
            if (max == 5)
                return 9;
            else if (max == 4)
                return 7;
            else if (max == 3 && np2 == 2)
                return 6;
            else if (max == 3)
                return 3;
            else if (max == 2 && np2 == 2)
                return 2;
            else if (max == 2)
                return 1;
            else if(max == 1) 
                return 0;
            return -1;
        }

        public string IDxToFormation(int x)
        {
            switch(x)
            {
                case 0:
                    return "";
                case 1:
                    return "One pair";
                case 2:
                    return "Two pairs";
                case 3:
                    return "Three of a kind";
                case 4:
                    return "Straight";
                case 5:
                    return "Flush";
                case 6:
                    return "Full house";
                case 7:
                    return "Four of a kind";
                case 8:
                    return "Royal flush";
                case 9:
                    return "Five of a kind";
            }
            return "";
        }
    }
}
