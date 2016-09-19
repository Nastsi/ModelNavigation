using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethodsForms
{
    public partial class Form1 : Form
    {
        static int numBeacons = 10;
        static int DistanceBetween = 0;
        static double Speed = 0;
        static int maxVerticalSpeed = 50;
        static int maxSpeed = 50;
        static int Number;
        static int Dead = 0;
        static bool Crash = false;
        static bool boom = false;
        static bool fall = false;
        static bool nullSpeed = false;
        static int[] Beacons = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] SpeedsH = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] SpeedsV = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] HeigthBeacons = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] Sequence = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] HeigthMin = new int[10] { 800, 1500, 1000, 900, 1200, 1000, 900, 1150, 1400, 1350 };
        static Beacon rb_1 = new Beacon();
        static Beacon rb_2 = new Beacon();
        static Beacon rb_3 = new Beacon();
        static Beacon rb_4 = new Beacon();
        static Beacon rb_5 = new Beacon();
        static Beacon rb_6 = new Beacon();
        static Beacon rb_7 = new Beacon();
        static Beacon rb_8 = new Beacon();
        static Beacon rb_9 = new Beacon();
        static Beacon rb_10 = new Beacon();
        static Beacon AP = new Beacon();
        static Plane first = new Plane();
        static Beacon Present = new Beacon();
        static bool worked = false;
        static object Locker = new object();
        static bool counted = false;
        int[] seqs;
        int[] speeds;
        int[] heights;
        int[] vSpeeds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void speed1_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence1.Text, out temp);
            Int32.TryParse(speed1.Text, out SpeedsH[temp - 1]);
        }

        private void speed2_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence2.Text, out temp);
            Int32.TryParse(speed2.Text, out SpeedsH[temp - 1]);
        }

        private void speed3_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence3.Text, out temp);
            Int32.TryParse(speed3.Text, out SpeedsH[temp - 1]);
        }

        private void speed4_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence4.Text, out temp);
            Int32.TryParse(speed4.Text, out SpeedsH[temp - 1]);
        }

        private void speed5_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence5.Text, out temp);
            Int32.TryParse(speed5.Text, out SpeedsH[temp - 1]);
        }

        private void speed6_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence6.Text, out temp);
            Int32.TryParse(speed6.Text, out SpeedsH[temp - 1]);
        }

        private void speed7_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence7.Text, out temp);
            Int32.TryParse(speed7.Text, out SpeedsH[temp - 1]);
        }

        private void speed8_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence8.Text, out temp);
            Int32.TryParse(speed8.Text, out SpeedsH[temp - 1]);
        }

        private void speed9_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence9.Text, out temp);
            Int32.TryParse(speed9.Text, out SpeedsH[temp - 1]);
        }

        private void speed10_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence10.Text, out temp);
            Int32.TryParse(speed10.Text, out SpeedsH[temp - 1]);
        }

        private void vSpeed1_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence1.Text, out temp);
            Int32.TryParse(vSpeed1.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed2_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence2.Text, out temp);
            Int32.TryParse(vSpeed2.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed3_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence3.Text, out temp);
            Int32.TryParse(vSpeed3.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed4_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence4.Text, out temp);
            Int32.TryParse(vSpeed4.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed5_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence5.Text, out temp);
            Int32.TryParse(vSpeed5.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed6_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence6.Text, out temp);
            Int32.TryParse(vSpeed6.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed7_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence7.Text, out temp);
            Int32.TryParse(vSpeed7.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed8_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence8.Text, out temp);
            Int32.TryParse(vSpeed8.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed9_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence9.Text, out temp);
            Int32.TryParse(vSpeed9.Text, out SpeedsV[temp - 1]);
        }

        private void vSpeed10_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence10.Text, out temp);
            Int32.TryParse(vSpeed10.Text, out SpeedsV[temp - 1]);
        }

        private void Heigth1_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence1.Text, out temp);
            Int32.TryParse(Heigth1.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth2_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence2.Text, out temp);
            Int32.TryParse(Heigth2.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth3_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence3.Text, out temp);
            Int32.TryParse(Heigth3.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth4_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence4.Text, out temp);
            Int32.TryParse(Heigth4.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth5_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence5.Text, out temp);
            Int32.TryParse(Heigth5.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth6_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence6.Text, out temp);
            Int32.TryParse(Heigth6.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth7_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence7.Text, out temp);
            Int32.TryParse(Heigth7.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth8_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence8.Text, out temp);
            Int32.TryParse(Heigth8.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth9_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence9.Text, out temp);
            Int32.TryParse(Heigth9.Text, out HeigthBeacons[temp - 1]);
        }

        private void Heigth10_TextChanged(object sender, EventArgs e)
        {
            int temp;
            Int32.TryParse(Sequence10.Text, out temp);
            Int32.TryParse(Heigth10.Text, out HeigthBeacons[temp - 1]);
        }

        private void Sequence1_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence1.Text, out temp))
            {
                speed1.ReadOnly = true;
                vSpeed1.ReadOnly = true;
                Heigth1.ReadOnly = true;
            }
            else
            {
                speed1.ReadOnly = false;
                vSpeed1.ReadOnly = false;
                Heigth1.ReadOnly = false;
                Int32.TryParse(Sequence1.Text, out temp);
                Sequence[temp - 1] = 1;
            }
        }

        private void Sequence2_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence2.Text, out temp))
            {
                speed2.ReadOnly = true;
                vSpeed2.ReadOnly = true;
                Heigth2.ReadOnly = true;
            }
            else
            {
                speed2.ReadOnly = false;
                vSpeed2.ReadOnly = false;
                Heigth2.ReadOnly = false;
                Int32.TryParse(Sequence2.Text, out temp);
                Sequence[temp - 1] = 2;
            }
        }

        private void Sequence3_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence3.Text, out temp))
            {
                speed3.ReadOnly = true;
                vSpeed3.ReadOnly = true;
                Heigth3.ReadOnly = true;
            }
            else
            {
                speed3.ReadOnly = false;
                vSpeed3.ReadOnly = false;
                Heigth3.ReadOnly = false;
                Int32.TryParse(Sequence3.Text, out temp);
                Sequence[temp - 1] = 3;
            }
        }

        private void Sequence4_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence4.Text, out temp))
            {
                speed4.ReadOnly = true;
                vSpeed4.ReadOnly = true;
                Heigth4.ReadOnly = true;
            }
            else
            {
                speed4.ReadOnly = false;
                vSpeed4.ReadOnly = false;
                Heigth4.ReadOnly = false;
                Int32.TryParse(Sequence4.Text, out temp);
                Sequence[temp - 1] = 1;
            }
        }

        private void Sequence5_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence5.Text, out temp))
            {
                speed5.ReadOnly = true;
                vSpeed5.ReadOnly = true;
                Heigth5.ReadOnly = true;
            }
            else
            {
                speed5.ReadOnly = false;
                vSpeed5.ReadOnly = false;
                Heigth5.ReadOnly = false;
                Int32.TryParse(Sequence5.Text, out temp);
                Sequence[temp - 1] = 1;
            }
        }

        private void Sequence6_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence6.Text, out temp))
            {
                speed6.ReadOnly = true;
                vSpeed6.ReadOnly = true;
                Heigth6.ReadOnly = true;
            }
            else
            {
                speed6.ReadOnly = false;
                vSpeed6.ReadOnly = false;
                Heigth6.ReadOnly = false;
                Int32.TryParse(Sequence6.Text, out temp);
                Sequence[temp - 1] = 6;
            }
        }

        private void Sequence7_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence7.Text, out temp))
            {
                speed7.ReadOnly = true;
                vSpeed7.ReadOnly = true;
                Heigth7.ReadOnly = true;
            }
            else
            {
                speed7.ReadOnly = false;
                vSpeed7.ReadOnly = false;
                Heigth7.ReadOnly = false;
                Int32.TryParse(Sequence7.Text, out temp);
                Sequence[temp - 1] = 7;
            }
        }

        private void Sequence8_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence8.Text, out temp))
            {
                speed8.ReadOnly = true;
                vSpeed8.ReadOnly = true;
                Heigth8.ReadOnly = true;
            }
            else
            {
                speed8.ReadOnly = false;
                vSpeed8.ReadOnly = false;
                Heigth8.ReadOnly = false;
                Int32.TryParse(Sequence8.Text, out temp);
                Sequence[temp -1 ] = 8;
            }
        }

        private void Sequence9_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence9.Text, out temp))
            {
                speed9.ReadOnly = true;
                vSpeed9.ReadOnly = true;
                Heigth9.ReadOnly = true;
            }
            else
            {
                speed9.ReadOnly = false;
                vSpeed9.ReadOnly = false;
                Heigth9.ReadOnly = false;
                Int32.TryParse(Sequence9.Text, out temp);
                Sequence[temp - 1] = 9;
            }
        }

        private void Sequence10_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (!Int32.TryParse(Sequence10.Text, out temp))
            {
                speed10.ReadOnly = true;
                vSpeed10.ReadOnly = true;
                Heigth10.ReadOnly = true;
            }
            else
            {
                speed10.ReadOnly = false;
                vSpeed10.ReadOnly = false;
                Heigth10.ReadOnly = false;
                Int32.TryParse(Sequence10.Text, out temp);
                Sequence[temp - 1] = 10;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        List<int> speedList = new List<int>();
        List<int> vSpeedList = new List<int>();
        List<int> seq = new List<int>();
        List<int> heightList = new List<int>();


        private void button1_Click(object sender, EventArgs e)
        {
            speedList.Clear();
            vSpeedList.Clear();
            seq.Clear();
            heightList.Clear();
            if (!speed1.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence1);
                int tempSpeed = valueFromTextBox(speed1);
                int tempVSpeed = valueFromTextBox(vSpeed1);
                int tempHeight = valueFromTextBox(Heigth1);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed2.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence2);
                int tempSpeed = valueFromTextBox(speed2);
                int tempVSpeed = valueFromTextBox(vSpeed2);
                int tempHeight = valueFromTextBox(Heigth2);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed3.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence3);
                int tempSpeed = valueFromTextBox(speed3);
                int tempVSpeed = valueFromTextBox(vSpeed3);
                int tempHeight = valueFromTextBox(Heigth3);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed4.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence4);
                int tempSpeed = valueFromTextBox(speed4);
                int tempVSpeed = valueFromTextBox(vSpeed4);
                int tempHeight = valueFromTextBox(Heigth4);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed5.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence5);
                int tempSpeed = valueFromTextBox(speed5);
                int tempVSpeed = valueFromTextBox(vSpeed5);
                int tempHeight = valueFromTextBox(Heigth5);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed6.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence6);
                int tempSpeed = valueFromTextBox(speed6);
                int tempVSpeed = valueFromTextBox(vSpeed6);
                int tempHeight = valueFromTextBox(Heigth6);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed7.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence7);
                int tempSpeed = valueFromTextBox(speed7);
                int tempVSpeed = valueFromTextBox(vSpeed7);
                int tempHeight = valueFromTextBox(Heigth7);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed8.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence8);
                int tempSpeed = valueFromTextBox(speed8);
                int tempVSpeed = valueFromTextBox(vSpeed8);
                int tempHeight = valueFromTextBox(Heigth8);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed9.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence9);
                int tempSpeed = valueFromTextBox(speed9);
                int tempVSpeed = valueFromTextBox(vSpeed9);
                int tempHeight = valueFromTextBox(Heigth9);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            if (!speed10.ReadOnly)
            {
                int tempSeq = valueFromTextBox(Sequence10);
                int tempSpeed = valueFromTextBox(speed10);
                int tempVSpeed = valueFromTextBox(vSpeed10);
                int tempHeight = valueFromTextBox(Heigth10);
                speedList.Add(tempSpeed);
                vSpeedList.Add(tempVSpeed);
                seq.Add(tempSeq);
                heightList.Add(tempHeight);
            }
            int lastSpeed = valueFromTextBox(speedB);
            int lastVSpeed = valueFromTextBox(vSpeedB);

            speedList.Add(lastSpeed);
            vSpeedList.Add(lastVSpeed);

            seqs = seq.ToArray();
            speeds = speedList.ToArray();
            heights = heightList.ToArray();
            vSpeeds = vSpeedList.ToArray();

            myCustomControlPlane1.start(seqs, speeds);
            Thread t = new Thread(MainThread);
            t.IsBackground = true;
            t.Start();
        }

        private int valueFromTextBox(TextBox textBox)
        {
            int temp;
            if (Int32.TryParse(textBox.Text, out temp))
            {
                return temp;
            } 
            else
            {
                throw new Exception("It's not integer!");
            }
        }

        private void MainThread()
        {
            rb_1.X = 14;
            rb_1.Y = 30;
            rb_2.X = 26;
            rb_2.Y = 24;
            rb_3.X = 36;
            rb_3.Y = 16;
            rb_4.X = 8;
            rb_4.Y = 26;
            rb_5.X = 16;
            rb_5.Y = 20;
            rb_6.X = 34;
            rb_6.Y = 10;
            rb_7.X = 4;
            rb_7.Y = 20;
            rb_8.X = 8;
            rb_8.Y = 14;
            rb_9.X = 18;
            rb_9.Y = 8;
            rb_10.X = 30;
            rb_10.Y = 4;
            AP.X = 43;
            AP.Y = 3;

            int num = 0;
            bool arrived = false;
            int[] BeaconsTemp = seqs;
            int[] HeigthBeaconsTemp = heights;
            int[] SpeedsHTemp = speeds;
            int[] SpeedsVTemp = vSpeeds;

            foreach (int el in HeigthBeaconsTemp)
            {
                HeigthBeacons[num] = el;
                num++;
            }

            num = 0;
            foreach (int el in BeaconsTemp)
            {
                Beacons[num] = el;
                num++;
            }

            num = 0;
            foreach (int el in SpeedsHTemp)
            {
                SpeedsH[num] = el;
                num++;
            }

            num = 0;
            foreach (int el in SpeedsVTemp)
            {
                SpeedsV[num] = el;
                num++;
            }

            Number = 0;
            Thread OutputTh = new Thread(Output);
            OutputTh.IsBackground = true;
            OutputTh.Start();
            do
            {
                Present.ReturnBeacon(Beacons[Number], Present);
                DistanceTo(Present);
                do
                {
                    SpeedCount();
                    Thread.Sleep(120);
                    DistanceCount();
                    Thread.Sleep(120);
                    VerticalSpeedCount();
                    Thread.Sleep(120);
                    VerticalHeigthCount();
                    Thread.Sleep(120);
                    PowerEngine();
                    Thread.Sleep(120);
                    DeadCheck();
                    Thread.Sleep(120);
                } while (DistanceBetween != 0 && Crash == false);
                if ((first.X == 43) && (first.Y == 3))
                {
                    arrived = true;
                }
                Number++;
                counted = false;
            } while (arrived == false && Crash == false);

            OutputTh.Suspend();
            if (Crash == false)
            {
                //Console.WriteLine("\nCамолёт долетел до места назначения");
            }
        }

        /**
            Методы работы с датчиками
        **/

        void Output()
        {
            while (true)
            {
                lock (Locker)
                {
                    if ((Present.X == AP.X) && (Present.Y == AP.Y))
                    {
                        //Console.WriteLine("Летим в аэропорт\n");
                        Direction.Text = "Летим в аэропорт";
                    }
                    else
                    {
                         Direction.Text = "Летим к маяку под номером: " + Beacons[Number];
                    }

                    Distance.Text = DistanceBetween + "";
                    SpeedTextBox.Text = first.speed + "";
                    Heigth.Text = first.heigth + "";
                    vSpeed.Text = first.vSpeed + "";
                    Engines.Text = first.power + "";

                    if (Crash == true && boom == true)
                    {
                        myCustomControlPlane1.setDead();
                        if (Direction.Text != "Двигатели самолета взорвались. Самолет упал")
                            Direction.Text = "Двигатели самолета взорвались. Самолет упал";
                    }
                    else if (Crash == true && fall == true)
                    {
                        myCustomControlPlane1.setDead();
                        if (Direction.Text != "Самолет не набрал необходимую высоту. Падение.")
                            Direction.Text = "Самолет не набрал необходимую высоту. Падение.";
                    }
                    else if (Crash == true && nullSpeed == true)
                    {
                        myCustomControlPlane1.setDead();
                        if (Direction.Text != "Нулевая скорость. Падение.")
                            Direction.Text = "Нулевая скорость. Падение.";
                    }

                    Thread.Sleep(100);
                }
            }
        }

        void Falling()
        {
            first.speed = 0;
            first.vSpeed = 0;
            first.power = 0;
            first.heigth = 0;
            Crash = true;
            Output();
        }

        void DeadCheck()
        {
            if (first.power == 100 && Dead == 10)
            {
                boom = true;
                Falling();
            }
            else if (first.power >= 90 && first.power < 100 && Dead == 20)
            {
                boom = true;
                Falling();
            }
            else if (first.power >= 80 && first.power < 90 && Dead == 35)
            {
                boom = true;
                Falling();
            }
        }

        void HeigthCheck()
        {
            if (first.heigth < HeigthMin[Beacons[Number] - 1])
            {
                fall = true;
                Falling();
            }

            if ((first.heigth == 0) && (DistanceBetween != 0))
            {
                fall = true;
                Falling();
            }
            
        }

        void PowerEngine()
        {
            first.power = first.speed + first.vSpeed + 5;
            if (first.power > 100)
            {
                first.power = 100;
            }

            if (first.power >= 80)
            {
                Dead++;
            }
            else
            {
                Dead = 0;
            }

            if ((first.X == 43) && (first.Y == 3))
            {
                first.power = 0;
            }
        }

        static void VerticalSpeedCount()
        {
            lock (Locker)
            {
                if ((first.vSpeed < SpeedsV[Number]) && (first.vSpeed < Math.Abs(HeigthBeacons[Number] - first.heigth)) && (first.heigth != HeigthBeacons[Number]))
                {
                    first.vSpeed += 10;
                    if (first.vSpeed > SpeedsV[Number])
                    {
                        first.vSpeed = SpeedsV[Number];
                    }
                }

                if ((first.heigth < HeigthBeacons[Number]) && (HeigthBeacons[Number] - first.heigth <= 60) && (first.vSpeed < Math.Abs(HeigthBeacons[Number] - first.heigth)))
                {
                    first.vSpeed -= 20;
                    if ((HeigthBeacons[Number] - first.heigth <= 60) && (first.vSpeed == 0))
                    {
                        first.heigth = HeigthBeacons[Number];
                    }
                }
                else if ((first.vSpeed > Math.Abs(HeigthBeacons[Number] - first.heigth)))
                {
                    first.heigth = HeigthBeacons[Number];
                    first.vSpeed = 0;
                }
                else if ((first.vSpeed < SpeedsV[Number]) && (first.heigth > HeigthBeacons[Number]) && (first.heigth - HeigthBeacons[Number] != 60))
                {
                    first.vSpeed += 10;
                    if (first.vSpeed > SpeedsV[Number])
                    {
                        first.vSpeed = SpeedsV[Number];
                    }
                }
                else if ((first.heigth > HeigthBeacons[Number]) && (first.heigth - HeigthBeacons[Number] <= 60) && (first.vSpeed < Math.Abs(HeigthBeacons[Number] - first.heigth)))
                {
                    first.vSpeed -= 20;
                }
            }
        }

        static void VerticalHeigthCount()
        {
            lock (Locker)
            {

                if ((first.vSpeed != 0) && (first.vSpeed <= (HeigthBeacons[Number] - first.heigth)) && (first.heigth < HeigthBeacons[Number]))
                {
                    first.heigth += first.vSpeed;
                }
                else if ((first.vSpeed != 0) && (first.vSpeed < (first.heigth - HeigthBeacons[Number])) && (first.heigth >= HeigthBeacons[Number]))
                {
                    first.heigth -= first.vSpeed;
                }
                if ((first.vSpeed >= Math.Abs(HeigthBeacons[Number] - first.heigth)) || (first.heigth == HeigthBeacons[Number]))
                {
                    first.heigth = HeigthBeacons[Number];
                    first.vSpeed = 0;
                }

                if ((DistanceBetween == 0) && (Present.X == 43) && (Present.Y == 3))
                {
                    first.vSpeed = 0;
                    first.heigth = 0;
                    first.speed = 0;
                }
            }
        }



        static void DistanceTo(Beacon P)
        {
            DistanceBetween = (int)Math.Round(Math.Sqrt((int)Math.Pow(first.X - P.X, 2) + (int)Math.Pow(first.Y - P.Y, 2)));
            DistanceBetween = DistanceBetween * 100;
        }

        void DistanceCount()
        {
            lock (Locker)
            {
                if ((first.speed != 0) && (DistanceBetween > first.speed))
                {
                    DistanceBetween -= first.speed;
                }
                else DistanceBetween = 0;

                if (Present.X == 43 && Present.Y == 3)
                {
                    if ((first.heigth == 0) && (DistanceBetween != 0))
                    {
                        fall = true;
                        Falling();
                    }
                }

                if (DistanceBetween == 0)
                {
                    first.X = Present.X;
                    first.Y = Present.Y;
                    if (Present.X != 43 && Present.Y != 3)
                    {
                        HeigthCheck();
                    }
                }
            }
        }

        void SpeedCount()
        {
            lock (Locker)
            {
                if (SpeedsH[Number] == 0)
                {
                    nullSpeed = true;
                    Falling();
                }
                else if ((first.speed < SpeedsH[Number]) && (Present.X != 43) && (Present.Y != 3) && (DistanceBetween > first.speed))
                {
                    first.speed += 10;
                    if (first.speed > SpeedsH[Number])
                    {
                        first.speed = SpeedsH[Number];
                    }
                    if (first.speed > maxSpeed)
                    {
                        first.speed = maxSpeed;
                    }
                }
                else if ((first.speed > SpeedsH[Number]) && (Present.X != 43) && (Present.Y != 3) && (DistanceBetween > first.speed))
                {
                    first.speed -= 10;
                    if (first.speed < SpeedsH[Number])
                    {
                        first.speed = SpeedsH[Number];
                    }
                    if (first.speed > maxSpeed)
                    {
                        first.speed = maxSpeed;
                    }
                }

                if ((DistanceBetween <= 60) && (Present.X == 43) && (Present.Y == 3))
                {
                    first.speed -= 10;
                }
            }
        }

        /****/
        public class Beacon
        {
            public int X;
            public int Y;

            public Beacon()
            {
                X = 0;
                Y = 0;
            }

            public void ReturnBeacon(int x, Beacon p)
            {
                switch (x)
                {
                    case 1:
                        p.X = rb_1.X;
                        p.Y = rb_1.Y;
                        break;
                    case 2:
                        p.X = rb_2.X;
                        p.Y = rb_2.Y;
                        break;
                    case 3:
                        p.X = rb_3.X;
                        p.Y = rb_3.Y;
                        break;
                    case 4:
                        p.X = rb_4.X;
                        p.Y = rb_4.Y;
                        break;
                    case 5:
                        p.X = rb_5.X;
                        p.Y = rb_5.Y;
                        break;
                    case 6:
                        p.X = rb_6.X;
                        p.Y = rb_6.Y;
                        break;
                    case 7:
                        p.X = rb_7.X;
                        p.Y = rb_7.Y;
                        break;
                    case 8:
                        p.X = rb_8.X;
                        p.Y = rb_8.Y;
                        break;
                    case 9:
                        p.X = rb_9.X;
                        p.Y = rb_9.Y;
                        break;
                    case 10:
                        p.X = rb_10.X;
                        p.Y = rb_10.Y;
                        break;
                    case 0:
                        p.X = AP.X;
                        p.Y = AP.Y;
                        break;
                    default:
                        Console.WriteLine("Такого маяка нет, самолет отправляется в аэропорт назначения прямым путем");
                        p.X = AP.X;
                        p.Y = AP.Y;
                        break;

                }
            }
        }

        public class Plane
        {
            public int speed;
            public int heigth;
            public int X;
            public int Y;
            public int vSpeed;
            public int power;

            public Plane()
            {
                speed = 0;
                heigth = 0;
                X = 3;
                Y = 31;
                vSpeed = 0;
                power = 0;
            }
        }
    }

}
