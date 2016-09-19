using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsForms
{
    public partial class MyCustomControlPlane : Control
    {
        protected PointF[] points;
        protected int[] planes;
        protected int[] speeds;
        protected Bitmap picture;
        protected System.Timers.Timer timer;
        protected float x;
        protected float y;
        protected float dx;
        protected float dy;
        private int current;
        protected bool[] isFirst;
        protected float distance;
        private float k;
        private float b;
        private float step;
        private bool isAnimation = false;
        private bool dead = false;

        public MyCustomControlPlane()
        {
            picture = new Bitmap(688, 500);
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Elapsed += timerOnTime;
            timer.Interval = 435;
            x = 42;
            y = 11;
            points = new PointF[12];
            points[0] = new PointF(42, 11);
            points[1] = new PointF(214, 26);
            points[2] = new PointF(401, 120);
            points[3] = new PointF((float)557.5, 245);
            points[4] = new PointF(120, 89);
            points[5] = new PointF(245, (float)182.5);
            points[6] = new PointF(526, (float)307.5);
            points[7] = new PointF((float)57.5, (float)182.5);
            points[8] = new PointF(120, 276);
            points[9] = new PointF(276, 370);
            points[10] = new PointF(464, (float)432.5);
            points[11] = new PointF(667, 468);
            current = 0;
        }

        public void start(int[] listOfPlanes, int[] listOfSpeeds)
        {
            planes = listOfPlanes;
            speeds = listOfSpeeds;
            isFirst = new bool[listOfSpeeds.Length];
            for (int i = 0; i < isFirst.Length; i++)
            {
                isFirst[i] = false;
            }
            isAnimation = true;
            timer.Start();
        }

        public void setDead()
        {
            dead = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Pen p = new Pen(Color.Black);
            Brush br = Brushes.Black;
            picture = new Bitmap(688, 500);
            Graphics grfx = Graphics.FromImage(picture);

            grfx.DrawEllipse(p, new RectangleF(42, 11, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(667, 468, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(214, 26, 10, 10));
            grfx.FillEllipse(br, new RectangleF(214, 26, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(401, 120, 10, 10));
            grfx.FillEllipse(br, new RectangleF(401, 120, 10, 10));
            grfx.DrawEllipse(p, new RectangleF((float)557.5, 245, 10, 10));
            grfx.FillEllipse(br, new RectangleF((float)557.5, 245, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(120, 89, 10, 10));
            grfx.FillEllipse(br, new RectangleF(120, 89, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(245, (float)182.5, 10, 10));
            grfx.FillEllipse(br, new RectangleF(245, (float)182.5, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(526, (float)307.5, 10, 10));
            grfx.FillEllipse(br, new RectangleF(526, (float)307.5, 10, 10));
            grfx.DrawEllipse(p, new RectangleF((float)57.5, (float)182.5, 10, 10));
            grfx.FillEllipse(br, new RectangleF((float)57.5, (float)182.5, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(120, 276, 10, 10));
            grfx.FillEllipse(br, new RectangleF(120, 276, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(276, 370, 10, 10));
            grfx.FillEllipse(br, new RectangleF(276, 370, 10, 10));
            grfx.DrawEllipse(p, new RectangleF(464, (float)432.5, 10, 10));
            grfx.FillEllipse(br, new RectangleF(464, (float)432.5, 10, 10));
            if (isAnimation)
                f(grfx);
            pe.Graphics.DrawImage(picture, 0, 0);
        }

        private void f(Graphics grfx)
        {
            if (current < planes.Length)
            {
                if (!isFirst[current])
                {
                    float cx = points[planes[current]].X;
                    float cy = points[planes[current]].Y;
                    distance = (float)(Math.Sqrt(Math.Pow((cx - x) * 14.375, 2) + Math.Pow((cy - y) * 15.625, 2)));
                    step = (float)(Math.Abs(cx - x) / (distance / speeds[current] + 1));
                    dx = 1;
                    dy = Math.Abs(cy - y) / Math.Abs(cx - x);
                    k = (cy - y) / (cx - x);
                    b = (cx * y - x * cy) / (cx - x);
                    if (cx - x < 0)
                    {
                        dx *= -1;
                    }
                    if (cy - y < 0)
                    {
                        dy *= -1;
                    }
                    isFirst[current] = true;
                }
                if (x < 687.5 && y < 500)
                {
                    if (!dead)
                    {
                        grfx.DrawEllipse(new Pen(Color.Aqua), new RectangleF(x, y, 10, 10));
                        grfx.FillEllipse(Brushes.Aqua, new RectangleF(x, y, 10, 10));
                        if (x < points[planes[current]].X && dx > 0 || x > points[planes[current]].X && dx < 0)
                        {
                            if (dx > 0)
                            {
                                x += step;
                            }
                            else
                            {
                                x -= step;
                            }
                            y = k * x + b;
                        }
                        else
                        {
                            current++;
                        }
                    }
                    else
                    {
                        grfx.DrawEllipse(new Pen(Color.Red), new RectangleF(x, y, 10, 10));
                        grfx.FillEllipse(Brushes.Red, new RectangleF(x, y, 10, 10));
                    }
                }
            }
            else
            {
                if (!isFirst[current])
                {
                    float cx = points[11].X;
                    float cy = points[11].Y;
                    distance = (float)(Math.Sqrt(Math.Pow((cx - x) * 14.375, 2) + Math.Pow((cy - y) * 15.625, 2)));
                    step = (float)(Math.Abs(cx - x) / (distance / speeds[current] + 1));
                    dx = 1;
                    dy = Math.Abs(cy - y) / Math.Abs(cx - x);
                    k = (cy - y) / (cx - x);
                    b = (cx * y - x * cy) / (cx - x);
                    if (cx - x < 0)
                    {
                        dx *= -1;
                    }
                    if (cy - y < 0)
                    {
                        dy *= -1;
                    }
                    isFirst[current] = true;
                }
                if (x < 687.5 && y < 500)
                {
                    if (!dead)
                    {
                        grfx.DrawEllipse(new Pen(Color.Aqua), new RectangleF(x, y, 10, 10));
                        grfx.FillEllipse(Brushes.Aqua, new RectangleF(x, y, 10, 10));
                        if (x < points[11].X && dx > 0 || x > points[11].X && dx < 0)
                        {
                            if (dx > 0)
                            {
                                x += step;
                            }
                            else
                            {
                                x -= step;
                            }
                            y = k * x + b;
                        }
                    }
                    else
                    {
                        grfx.DrawEllipse(new Pen(Color.Red), new RectangleF(x, y, 10, 10));
                        grfx.FillEllipse(Brushes.Red, new RectangleF(x, y, 10, 10));
                    }
                }
            }
        }

        private void timerOnTime(object sender, EventArgs args)
        {
            Invalidate();
        }
    }
}
