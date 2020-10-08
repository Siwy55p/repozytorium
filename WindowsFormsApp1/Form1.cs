using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AutoItX3Lib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, IntPtr dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        Autoit mojAuto = new Autoit();

        DataTable tabela1 = new DataTable();
        DataTable tabela2 = new DataTable();
        DataTable tabela3 = new DataTable();
        DataTable tabela4 = new DataTable();

        Point lokalizacja; // znalezionego obrazka

        Graphics g;
        Graphics g1;

        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        Pen p;

        Point cursor;
        int k = 0; Point[] points = new Point[50];

        AutoItX3 auto = new AutoItX3();

        int dwFlags;

        void readMouseDown()
        {
            if(dwFlags == MOUSEEVENTF_LEFTDOWN)
            {
                textBox7.Text = "nacisnales lewy przycisk myszki gdziekolwiek";
            }
            //if()
        }

        void sendMouseDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 998, 546, 0, new System.IntPtr());
        }

        void sendMouseUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 998, 546, 0, new System.IntPtr());
        }

        public Form1()
        {
            InitializeComponent();
            g1 = this.CreateGraphics();
            g = panel1.CreateGraphics();
            p = new Pen(Color.Black, 2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 2);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        public void tabela()
        {
            Random kolejnosc = new Random();
            int kolej = kolejnosc.Next(1, 60);

            //table.Rows.Add(kolej, 1187, 314);  // to jest przycisk Reklama nie wiem czemu 
            //kolej = kolejnosc.Next(1, 60);

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 400, 500);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 320, 500);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela3.Rows.Add(kolej, 420, 483);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 714, 570);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 350, 430);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 479, 450);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 330, 450);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 594, 450);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 403, 421);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 644, 502);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 465, 490);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 721, 532);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 453, 480);  // prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 721, 450);  //prawidlowy klik

            kolej = kolejnosc.Next(1, 60);
            tabela2.Rows.Add(kolej, 600, 430);  // prawidlowy klik

            tabela1.Rows.Add(kolej, 572, 590);  // przycisk doł
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 539, 588);  // przycisk dół
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 498, 577);  // przycisk dół
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 513, 564);  // przycisk dół
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 517, 558);
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 524, 530);
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 543, 528);
            kolej = kolejnosc.Next(1, 60);
            tabela1.Rows.Add(kolej, 731, 74);
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1144, 384);
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1136, 352);

            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 741, 60); //prawy górny naroznik
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 727, 65); //prawy górny narownikowy dol
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 451, 94); //lewy gorny naroznik

            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1349, 304); //prawy x
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1169, 22); // aplikacja MultiAirWar
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1313, 117); // zamkniecie 2 okna 
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1074, 77);
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(20, 1170, 22); // aplikacja MultiAirWar
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(21, 1310, 80); // zamknięcie 1 okna
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(22, 1116, 22); // aplikacja Sklep (dom)
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(23, 1166, 22); // aplikacja MultiAirWar
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(24, 1360, 60); // prawy górny naroznik
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1119, 532); // lewe 
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1155, 535); // lewe
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1356, 60);  // prawe gorny naroznik
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1072, 60);  // lewe gorny narozik
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1068, 86); //lewy gorny X pośredni
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1305, 333); 
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1274, 452); 
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1343,505); 
            //kolej = kolejnosc.Next(1, 60);
            //table.Rows.Add(kolej, 1364, 300); 
            //kolej = kolejnosc.Next(1, 60);


        }

        int X1;
        int Y1;
        int X2;
        int Y2;
        int X3;
        int Y3;
        int kolej;
        public void losujKlikniecie1()
        {
            tabela1.Rows.Add(kolej,X1, Y1);
        }
        public void losujKlikniecie2()
        {
            tabela2.Rows.Add(kolej, X2, Y2);
        }
        public void losujKlikniecie3()
        {
            tabela3.Rows.Add(kolej, X3, Y3);
        }
        private void timer15_Tick(object sender, EventArgs e)
        {
            Random kolejnosc = new Random();
            kolej = kolejnosc.Next(1, 60);
        }
        int losa;
        int losb;
        private void timer13_Tick(object sender, EventArgs e) // max Y
        {
            Random losaa = new Random();
            losa = losaa.Next(400, 570);
        }

        private void timer14_Tick(object sender, EventArgs e) // max X
        {
            Random losbb = new Random();
            losb = losbb.Next(700, 724);
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            Random losY = new Random();
            if(losa == 0)
            {
                losa = 570;
            }
            Y1 = losY.Next(110, losa);
            Y2 = losY.Next(440, 490);
            Y3 = losY.Next(440, 490);
            label7.Text = Y1.ToString();
        }
        private void timer12_Tick(object sender, EventArgs e)
        {
            //Random s = new Random();
            //int u = s.Next(440, 500);
            Random losX = new Random();
            if(losb == 0)
            {
                losb = 724;
            }
            X1 = losX.Next(435, losb);
            X2 = losX.Next(440, 500);
            X3 = losX.Next(580, 610);
            label6.Text = X1.ToString();
        }
        private void timer10_Tick(object sender, EventArgs e)
        {
            losujKlikniecie1();
            dataGridView1.DataSource = tabela1;
            losujKlikniecie2();
            dataGridView2.DataSource = tabela2;
            losujKlikniecie3();
            dataGridView3.DataSource = tabela3;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabela1.Columns.Add("Id", typeof(int));
            tabela1.Columns.Add("X", typeof(int));
            tabela1.Columns.Add("Y", typeof(int));

            tabela1.AcceptChanges();


            tabela2.Columns.Add("Id", typeof(int));
            tabela2.Columns.Add("X", typeof(int));
            tabela2.Columns.Add("Y", typeof(int));

            tabela2.AcceptChanges();


            tabela3.Columns.Add("Id", typeof(int));
            tabela3.Columns.Add("X", typeof(int));
            tabela3.Columns.Add("Y", typeof(int));

            tabela3.AcceptChanges();

            tabela4.Columns.Add("Id", typeof(int));
            tabela4.Columns.Add("X", typeof(int));
            tabela4.Columns.Add("Y", typeof(int));
            tabela4.Columns.Add("Akcja", typeof(int));

            tabela4.AcceptChanges();

            tabela();
            dataGridView1.DataSource = tabela1;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            dataGridView2.DataSource = tabela2;
            dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);

            dataGridView3.DataSource = tabela3;
            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auto.WinActivate("new 1 - Notepad++");
            auto.Send("Test Autoit on C#");
        } //notepad test 


        private void button2_Click(object sender, EventArgs e)  // button start
        {
            textBox2.Text = dataGridView1.RowCount.ToString();
           // textBox2.Text = dataGridView1.Rows[1].Cells["X"].FormattedValue.ToString();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) //timer wykonuje sie w w pentli for co 5 sekund jesli nie uzyjemy timer1.Stop()
        {
            timer1.Stop();
            //listBox1.Items.Add(mojAuto.readPosition());
            //for(int i = 0; i < 2
            //    //listBox1.Items.Count
            //    ; i++)
            //{
            //    mojAuto.mClick("LEFT", int.Parse(listBox1.Text.PadLeft(5)), int.Parse(listBox1.Text.PadRight(5)), 1, -1);
            //}

            //mojAuto.mClick("LEFT", 564, 310, 1, -2); //1195, 316 button reklama Pierwsze kliknięcie musi być na pozycji Reklama i Aplikacji z Menu kliknij w reklame przycisk
            mojAuto.mClick("LEFT", 601, 104, 1, -2); //1195, 316 button reklama Pierwsze kliknięcie musi być na pozycji Reklama i Aplikacji z Menu kliknij w reklame przycisk

            for (int i = 1; i < dataGridView1.RowCount-1; i ++ )
            {
                mojAuto.mClick("LEFT", int.Parse(dataGridView1.Rows[i].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView1.Rows[i].Cells["Y"].FormattedValue.ToString()), 1, -2); //1191, 314
            }



            //60000
            Random rand = new Random();
            int ran = rand.Next(90000, 130000);

            textBox3.Text = ran.ToString();
            timer2.Interval = ran;
            miernik1 = 0;

            Random rand2 = new Random();
            int xs = rand2.Next(532, 550);
            mojAuto.MouseClickDrag("LEFT", 1078, 532, 1347, xs);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            tabela1.Clear();
            tabela();
            dataGridView1.DataSource = tabela1;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            //timer2.Interval = int.Parse(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // set czas co jaki czas
        {
            timer2.Interval = int.Parse(textBox1.Text);
        }

        private void timer2_Tick(object sender, EventArgs e) // timer2 to jest po nacisnieciu na start
        {
            textBox4.Text = timer2.Interval.ToString();
            timer8.Stop(); // zatrzymaj losowe klikniecia
            richTextBox1.Text += "Zatrzymuje losowe kliki i klik w reklame \n";
            mojAuto.mClick("LEFT", 601, 104, 1, -2); //1195, 316 button reklama Pierwsze kliknięcie musi być na pozycji Reklama i Aplikacji z Menu

            Random rand = new Random();
            int ran = rand.Next(100000, 120000);
            timer2.Interval = ran;
            miernik1 = 0;

            richTextBox1.Text += "Nastepne klikniecie w przycisk w reklame za: " + timer2.Interval +" \n";
            richTextBox1.Text += "Start szukanie wylaczenia! reklamy \n";

            //Odlicz 30 sek i zacznij szukac obrazkow w timer7 po tym klikaj  losowo co zalatwia timer7
            odlicz30sek.Start();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // przycisk Stop
        {
            timer2.Stop();
            timer1.Stop();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // przycisk sort
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        int czas;

        private void timer4_Tick(object sender, EventArgs e)
        {
            czas += 1;
            int za = (timer2.Interval - (czas * 1000));
            label2.Text = za.ToString();


            Random rand = new Random();
            ran = rand.Next(900, 1500);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!=-1 && y!=-1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = this.PointToClient(Cursor.Position);
            mouseStatus.Text = row1 + " X: " + cursor.X + " Y: " + cursor.Y;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if(drawCheck.Checked == true)
            {
                g1.DrawEllipse(p, cursor.X-2, cursor.Y-2, 5, 5);
                listBox1.Items.Add( row1 + "X: " + cursor.X + " Y: " + cursor.Y);
            }
        }


        int row1=0;
        int row2 = 0;
        int row3 = 0;

        private void timer5_Tick(object sender, EventArgs e)
        {
            //row++;
            //if (row >= dataGridView1.RowCount-1)
            //{
            //    row = 0;
            //    timer5.Stop();
            //}
            //mojAuto.mClick("LEFT", int.Parse(dataGridView1.Rows[row].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView1.Rows[row].Cells["Y"].FormattedValue.ToString()), 1, -2); //1191, 314

            if(lokalizacja != null)
            {
                mojAuto.mClick("LEFT", lokalizacja.X+5, lokalizacja.Y+5, 1, -2);
                lokalizacja = new Point();
            }
            timer5.Stop();



        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer5.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer5.Stop();
            timer5.Enabled = false;
        }

        private void open1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox2.Image = (Bitmap)System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void open2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox3.Image = (Bitmap)System.Drawing.Image.FromFile(openFileDialog2.FileName);
            }
        }

        private void znajdzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap sourceImage = (Bitmap)pictureBox2.Image;
            System.Drawing.Bitmap template = (Bitmap)pictureBox3.Image;
            // create template matching algorithm's instance
            // (set similarity threshold to 92.1%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(sourceImage, template);
            // highlight found matchings

            BitmapData data = sourceImage.LockBits(
                 new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                 ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {

                Drawing.Rectangle(data, m.Rectangle, Color.White);

                //MessageBox.Show(m.Rectangle.Location.ToString());
                richTextBox1.Text += "Obrazek znaleziony: m.Rectangle.Location.ToString() /n";
                lokalizacja = m.Rectangle.Location;
                // do something else with matching
            }
            sourceImage.UnlockBits(data);
        }
        int js = 10;

        int znajdz = 1;
        int MaxZnajdz;

        //string pathImage = @"Z:\Windows 7 All x64, x86\NowyKliker\image"; // to jest dla maszyn wirtualnych

        string[] files;

       string pathImage = @"Z:\NowyKliker\image"; // to jest lokalnie do testow 
        private void zrzutEkranuToolStripMenuItem_Click(object sender, EventArgs e) // Przycisk Start Zrzut ekranu
        {



            try
            {
                files = Directory.GetFiles(pathImage);
            }
            catch (System.IO.DirectoryNotFoundException ea)
            {

                if (openFileDialog3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox3.Image = (Bitmap)System.Drawing.Image.FromFile(openFileDialog3.FileName);
                }
                pathImage = openFileDialog3.InitialDirectory;
            }


            files = Directory.GetFiles(pathImage);
            textBox5.Text = files.Length.ToString(); //29 plikow w folderze @"F:\Windows 7 All x64, x86\NowyKliker\image"
            MaxZnajdz = files.Length-1;

            //int yHow = this.Top;
            //this.Top = Screen.PrimaryScreen.Bounds.Height + 1000;

            richTextBox1.Text += "Nacisniety btn Zrzut ekranu Start ## ";

            Bitmap btm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graph = Graphics.FromImage(btm);
            graph.CopyFromScreen(0, 0, 0, 0, btm.Size);

            btm.Save(js+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            richTextBox1.Text += "Zrzut ekranu " +js+".jpg ## ";
            // pictureBox2.Image = btm;
            pictureBox2.Image = (Bitmap)System.Drawing.Image.FromFile(js+".jpg");
            //System.Diagnostics.Process.Start("1.jpg");
            //@"C:\Documents and Settings\" +            @"All Users\Documents\My Music\music.bmp",
            //cd @"F:\Windows 7 All x64, x86\NowyKliker\image"

            pictureBox3.Image = (Bitmap)System.Drawing.Image.FromFile(pathImage+ "\\z" + znajdz+".jpg");
            richTextBox1.Text += "Zaladowany obr znajdz: z" + znajdz + ".jpg " + js + ".jpg ## /n";
            if (znajdz >= MaxZnajdz)
            {
                znajdz = 1;
            }
            timer6.Start(); // znajdz obrazek

            znajdz++;
            js++;
        }

        private void timer6_Tick(object sender, EventArgs e)  // Timer 6 to jest szykanie obrazka i klikniecie jesli znajdzie
        {
            timer2.Stop();
            timer6.Stop();
            richTextBox1.Text += "!!! Szukam: z" + znajdz + ".jpg  w "+ js + ".jpg /n";
            System.Drawing.Bitmap template = (Bitmap)pictureBox3.Image;
            System.Drawing.Bitmap sourceImage = (Bitmap)pictureBox2.Image;
            // create template matching algorithm's instance
            // (set similarity threshold to 92.1%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(sourceImage, template);
            // highlight found matchings

            BitmapData data = sourceImage.LockBits(
                 new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                 ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {

                Drawing.Rectangle(data, m.Rectangle, Color.White);
                richTextBox1.Text += "Znalazlem: z" + znajdz + ".jpg w " + js + ".jpg /n";
                //MessageBox.Show(m.Rectangle.Location.ToString());
                lokalizacja = m.Rectangle.Location;
                richTextBox1.Text += "lok: "+ lokalizacja.ToString() +"\n";
                // do something else with matching
            }
            sourceImage.UnlockBits(data);

            if(lokalizacja != null) // jesli znalazło to kliknij
            {
                timer5.Start(); // co 5 sekund klik w znaleziona pozycje
                richTextBox1.Text += "klikam: " + lokalizacja.ToString() + "\n";
            }
            richTextBox1.Text += "Kontrona znajdz: " + znajdz + " ## ";
            richTextBox1.Text += "Kontrona zrzut ekranu: " + js + " ## /n";
            timer7.Start(); // To jest zrzut ekranu i załadowanie obrazkow do boksów
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void timer7_Tick(object sender, EventArgs e) // Timer 6 to jest szykanie obrazka i klikniecie jesli znajdzie
        {
            string[] files = Directory.GetFiles(pathImage);
            textBox5.Text = files.Length.ToString(); //29 plikow w folderze @"F:\Windows 7 All x64, x86\NowyKliker\image"
            MaxZnajdz = files.Length-1;

            timer7.Stop();
            richTextBox1.Text += " Ladowanie obrazkow : " + znajdz + " (timer7) robie zrzut ekranu \n";
            Bitmap btm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics graph = Graphics.FromImage(btm);
            graph.CopyFromScreen(0, 0, 0, 0, btm.Size);

            btm.Save(js + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            richTextBox1.Text += "Zrzut ekranu: " + js + ".jpg ### ";

            // pictureBox2.Image = btm;
            pictureBox2.Image = (Bitmap)System.Drawing.Image.FromFile(js + ".jpg");
            richTextBox1.Text += "Załadowany zrzut ekranu: " + js + ".jpg ### ";
            //System.Diagnostics.Process.Start("1.jpg");


            pictureBox3.Image = (Bitmap)System.Drawing.Image.FromFile(pathImage+"\\z" + znajdz + ".jpg");
            richTextBox1.Text += "Załadowany obrazek: z" + znajdz + ".jpg ### ";
            if (znajdz >= MaxZnajdz)
            {
                znajdz = 1;
                richTextBox1.Text += "znajdz=" + znajdz + " ma być 0 ### ";
            }

            if (znajdz == 1)
            {
                richTextBox1.Text += "znajdz=" + znajdz + " ma być 0 uruchom klikacz ### ";
                timer8.Start(); // klikacz
            }
            else
            {
                timer6.Start(); // znajdz obrazek i kliknij w znalaziony obrazek
            }
            znajdz++;
            js++;
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            row1++;
            richTextBox1.Text += " Klik: " + row1 + " / ";
            if (row1 >= dataGridView1.RowCount - 1)
            {
                row1 = 2;
                richTextBox1.Text += "losuje kliki =" + znajdz + " \n";
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                tabela1.Clear();
                tabela();
                dataGridView1.DataSource = tabela1;
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            row2++;
            if (row2 >= dataGridView2.RowCount - 1)
            {
                row2 = 2;
                richTextBox1.Text += "losuje kliki =" + znajdz + " \n";
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                tabela2.Clear();
                tabela();
                dataGridView2.DataSource = tabela2;
                dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
            }
            row3++;
            if (row3 >= dataGridView3.RowCount - 1)
            {
                row3 = 2;
                richTextBox1.Text += "losuje kliki =" + znajdz + " \n";
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
                tabela3.Clear();
                tabela();
                dataGridView3.DataSource = tabela3;
                dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
            }

            if(ran == 0)
            {
                ran = 1000;
            }

            switch(losAkcja)
            {
                case 1:
                    mojAuto.mClick("LEFT", int.Parse(dataGridView1.Rows[row1].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView1.Rows[row1].Cells["Y"].FormattedValue.ToString()), 1, -2); //1191, 314
                    break;
                case 2:
                    mojAuto.MouseClickDrag("LEFT", int.Parse(dataGridView2.Rows[row2].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView2.Rows[row2].Cells["Y"].FormattedValue.ToString()), int.Parse(dataGridView3.Rows[row3].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView3.Rows[row3].Cells["Y"].FormattedValue.ToString()));
                    break;
                case 3:
                    mojAuto.MouseClickDrag("LEFT", X2drag, Y2drag, X1drag, Y1drag); // z prawej do lewej
                    break;
                case 4:
                    mojAuto.mClick("LEFT", int.Parse(dataGridView1.Rows[row1].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView1.Rows[row1].Cells["Y"].FormattedValue.ToString()), 1, -2); //1191, 314
                    break;
            }


            timer8.Interval = ran;
        }

        int losAkcja;

        int X1drag;
        int Y1drag;
        int X2drag;
        int Y2drag;
        private void Ydrap_Tick(object sender, EventArgs e)
        {
            Random rano = new Random();
            Y1drag = rano.Next(400, 450);
        }
        private void Xdrap_Tick(object sender, EventArgs e)
        {
            Random rano = new Random();
            X1drag = rano.Next(440, 490); 
        }
        private void Y1drap_Tick(object sender, EventArgs e)
        {
            Random rano = new Random();
            Y2drag = rano.Next(400, 500);
        }
        private void X1drap_Tick(object sender, EventArgs e)
        {
            Random rano = new Random();
            X2drag = rano.Next(500, 680);
        }

        int ran; // losowane od 1 do 2 sekund w timer4 co 1 1sekunde
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        int miernik1 = 0;
        private void timer9_Tick(object sender, EventArgs e)
        {
            miernik1++;
               int miernik2 = timer2.Interval - (miernik1 * 1000); 
            label5.Text = miernik2.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void odlicz30sek_Tick(object sender, EventArgs e)
        {
            timer7.Start();
            odlicz30sek.Stop();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer16_Tick(object sender, EventArgs e)
        {
            Random rans = new Random();
            losAkcja = rans.Next(1, 5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer17recordCoJakiCzas.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer17recordCoJakiCzas.Stop();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int s = 0;



        private void timer17recordCoJakiCzas_Tick(object sender, EventArgs e)
        {
            tabela4.Rows.Add(s++, mojAuto.GetPostionX(), mojAuto.GetPostionY(),  mojAuto.GetAction());
            dataGridView4.DataSource = tabela4;

            //mojAuto.ClickLeft();

            //sendMouseUp();
            //sendMouseDown();

            readMouseDown();

            //mojAuto;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer17.Start();

            //for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            //{
            //    mojAuto.Position(int.Parse(dataGridView4.Rows[i].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView4.Rows[i].Cells["Y"].FormattedValue.ToString()));
            //}



           // mojAuto.MouseClickDrag("LEFT", int.Parse(dataGridView2.Rows[row2].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView2.Rows[row2].Cells["Y"].FormattedValue.ToString()), int.Parse(dataGridView3.Rows[row3].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView3.Rows[row3].Cells["Y"].FormattedValue.ToString()));

        }

        int sa;

        private void timer17_Tick(object sender, EventArgs e)
        {

            if (sa >= dataGridView4.RowCount - 1)
            {
                sa = 0;
            }
            mojAuto.Position(int.Parse(dataGridView4.Rows[sa++].Cells["X"].FormattedValue.ToString()), int.Parse(dataGridView4.Rows[sa++].Cells["Y"].FormattedValue.ToString()) );
        }
        void f_LostFocus(object sender, EventArgs e)
        {
            Form f = sender as Form;
            f.Close();
            f.Dispose();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.X)
            {
                timer17.Stop();
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                timer17.Stop();
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = "Mouse Click";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            Form f = new Form();
            f.LostFocus += new EventHandler(f_LostFocus);
            f.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
