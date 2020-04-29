using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sec = 0;
        int w = 60, h = 60;
        int x = 1, y = 100;
        int dx = 5;


        enum STATUS { RU, RD, LU, LD };  //направления движения
        STATUS flag;        //флаг изменения направления движения
        SolidBrush brush = new SolidBrush(Color.Black); // кисть
        Rectangle rc; //прямоугольная область, в которой находиться фигура

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, rc);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            sec++;
            rc = new Rectangle(x, y, w, h);
            this.Invalidate(rc, true);

            if (y <= 1)
                flag = STATUS.RD;
            if (x >= (this.ClientSize.Width - w)) // если достигли правого края формы
                flag = STATUS.LD;
            if (y >= (this.ClientSize.Height - h))
                flag = STATUS.LU;
            if (x <= 1)
                flag = STATUS.RU;

            if (flag == STATUS.RU)
            {
                x += dx;
                y -= 2*dx;
            }
            if (flag == STATUS.RD)
            {
                x += 2*dx;
                y += dx;
            }
            if (flag == STATUS.LU)
            {
                x -= 2*dx;
                y -= dx;
            }
            if (flag == STATUS.LD)
            {
                x -= dx;
                y += 2*dx;
            }     

            rc = new Rectangle(x, y, w, h); // новая прямоугольная область
            this.Invalidate(rc, true);  // вызываем прорисовку этой области

        }

        public int MySpeed
        {
            get
            {
                return 100 - timer1.Interval;
            }
            set
            {
                timer1.Interval = 110 - value;
            }
        }

        public Color MyColor
        {
            get
            {
                return brush.Color;
            }
            set
            {
                brush.Color = value;
            }
        }
        public void weidth(int r)
        {
            w = r;
            h = r;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Старт")
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Старт";
            }

        }        

        



    }
}
