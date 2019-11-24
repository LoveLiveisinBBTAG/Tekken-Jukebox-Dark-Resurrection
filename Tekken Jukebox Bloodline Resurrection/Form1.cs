using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;


namespace Tekken_Jukebox_Bloodline_Resurrection
{
    public partial class Form1 : Form
    {

        int volume1 = 100;
        int volume2 = 100;
        int volume3 = 100;
        int volume4 = 100;
        int volume5 = 100;
        int volume6 = 100;
        int volume7 = 100;
        int volume8 = 100;
        int volume9 = 100;
        int volume10 = 100;
        int volume11 = 100;
        int volume12 = 100;
        int volume13 = 100;
        int volume14 = 100;
        int volume15 = 100;
        int volume16 = 100;
        int volume17 = 100;
        int volume18 = 100;
        int volume19 = 100;
        int volume20 = 100;
        int volume21 = 100;
        int volume22 = 100;
        int volume23 = 100;
        int volume24 = 100;
        int volume25 = 100;
        int volume26 = 100;
        int volume27 = 100;
        int volume28 = 100;
        int pID = 0;

        public Form1()
        {
            InitializeComponent();
            volume1 = Properties.Settings.Default.Volume1;
            numericUpDown1.Value = volume1;
            volume2 = Properties.Settings.Default.Volume2;
            numericUpDown2.Value = volume2;
            volume3 = Properties.Settings.Default.Volume3;
            numericUpDown3.Value = volume3;
            volume4 = Properties.Settings.Default.Volume4;
            numericUpDown4.Value = volume4;
            volume5 = Properties.Settings.Default.Volume5;
            numericUpDown5.Value = volume5;
            volume6 = Properties.Settings.Default.Volume6;
            numericUpDown6.Value = volume6;
            volume7 = Properties.Settings.Default.Volume7;
            numericUpDown7.Value = volume7;
            volume8 = Properties.Settings.Default.Volume8;
            numericUpDown8.Value = volume8;
            volume9 = Properties.Settings.Default.Volume9;
            numericUpDown9.Value = volume9;
            volume10 = Properties.Settings.Default.Volume10;
            numericUpDown10.Value = volume10;
            volume11 = Properties.Settings.Default.Volume11;
            numericUpDown11.Value = volume11;
            volume12 = Properties.Settings.Default.Volume12;
            numericUpDown12.Value = volume12;
            volume13 = Properties.Settings.Default.Volume13;
            numericUpDown13.Value = volume13;
            volume14 = Properties.Settings.Default.Volume14;
            numericUpDown26.Value = volume14;
            volume15 = Properties.Settings.Default.Volume15;
            numericUpDown25.Value = volume15;
            volume16 = Properties.Settings.Default.Volume16;
            numericUpDown24.Value = volume16;
            volume17 = Properties.Settings.Default.Volume17;
            numericUpDown23.Value = volume17;
            volume18 = Properties.Settings.Default.Volume18;
            numericUpDown22.Value = volume18;
            volume19 = Properties.Settings.Default.Volume19;
            numericUpDown21.Value = volume19;
            volume20 = Properties.Settings.Default.Volume20;
            numericUpDown20.Value = volume20;
            volume21 = Properties.Settings.Default.Volume21;
            numericUpDown19.Value = volume21;
            volume22 = Properties.Settings.Default.Volume22;
            numericUpDown18.Value = volume22;
            volume23 = Properties.Settings.Default.Volume23;
            numericUpDown17.Value = volume23;
            volume24 = Properties.Settings.Default.Volume24;
            numericUpDown16.Value = volume24;
            volume25 = Properties.Settings.Default.Volume25;
            numericUpDown15.Value = volume25;
            volume26 = Properties.Settings.Default.Volume26;
            numericUpDown14.Value = volume26;
            volume27 = Properties.Settings.Default.Volume27;
            numericUpDown28.Value = volume27;
            volume28 = Properties.Settings.Default.Volume28;
            numericUpDown27.Value = volume28;




            label1.Text = Properties.Settings.Default.Label1;
            label6.Text = Properties.Settings.Default.Label6;
            label8.Text = Properties.Settings.Default.Label8;
            label10.Text = Properties.Settings.Default.Label10;
            label12.Text = Properties.Settings.Default.Label12;
            label14.Text = Properties.Settings.Default.Label14;
            label16.Text = Properties.Settings.Default.Label16;
            label18.Text = Properties.Settings.Default.Label18;
            label20.Text = Properties.Settings.Default.Label20;
            label22.Text = Properties.Settings.Default.Label22;
            label24.Text = Properties.Settings.Default.Label24;
            label26.Text = Properties.Settings.Default.Label26;
            label28.Text = Properties.Settings.Default.Label28;
            label30.Text = Properties.Settings.Default.Label30;
            label32.Text = Properties.Settings.Default.Label32;
            label34.Text = Properties.Settings.Default.Label34;
            label36.Text = Properties.Settings.Default.Label36;
            label38.Text = Properties.Settings.Default.Label38;
            label40.Text = Properties.Settings.Default.Label40;
            label42.Text = Properties.Settings.Default.Label42;
            label44.Text = Properties.Settings.Default.Label44;
            label46.Text = Properties.Settings.Default.Label46;
            label48.Text = Properties.Settings.Default.Label48;
            label50.Text = Properties.Settings.Default.Label50;
            label52.Text = Properties.Settings.Default.Label52;
            label54.Text = Properties.Settings.Default.Label54;
            label56.Text = Properties.Settings.Default.Label56;
            label58.Text = Properties.Settings.Default.Label58;



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        public Mem m = new Mem();
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();


        bool mMusic;
        bool start = false;
        bool inMatch = false;
        int currentStage;
        int chara;
        int input;
        bool pv;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            timer1.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool opened = false;
                pID = m.getProcIDFromName("TekkenGame-Win64-Shipping");
                if (pID > 0)
                {
                    opened = m.OpenProcess(pID);
                }
                if (opened)
                {
                    label4.Invoke((MethodInvoker)delegate
                    {
                        label4.Text = pID.ToString();
                    });
                     currentStage = m.readInt("TekkenGame-Win64-Shipping.exe+0x346F810,0x0,0x0,0x18");
                     chara = m.readInt("TekkenGame-Win64-Shipping.exe+034BC4C0");
                     input = m.readInt("TekkenGame-Win64-Shipping.exe+034BC4C0,0x0,0x0,0x1760");
                    if (chara != 0 && !inMatch && input == 32)
                        inMatch = true;
                    else if(inMatch && chara == 0)
                    {
                        inMatch = false;
                    }



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label1.Text = openFileDialog1.FileName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            volume1 = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                player.controls.stop();
                button1.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog1.FileName != "")
            {
               /* player.URL = openFileDialog1.FileName;
                player.settings.volume = volume1;
                player.controls.play();
                */
                player.URL = label1.Text;
                player.controls.play();
                player.settings.volume = volume1;
                pv = true;

                button1.Text = "Stop";
            }
           

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (/*player.playState == WMPLib.WMPPlayState.wmppsPlaying && currentStage != 0 && !pv || */start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara == 0 && !pv && !mMusic || !mMusic && start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv || start && mMusic && chara != 0 && player.playState == WMPLib.WMPPlayState.wmppsPlaying /*|| start && player.playState != WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv && label58.Text == openFileDialog27.FileName*/)
            {
                player.controls.stop();
                mMusic = false;

            }
            if (start && currentStage == 0 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label1.Text == openFileDialog1.FileName)
            {
                player.controls.stop();
                player.URL = label1.Text;
                player.controls.play();
                player.settings.volume = volume1;
            }
            if (start && currentStage == 1 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label6.Text == openFileDialog2.FileName)
            {
                player.controls.stop();
                player.URL = label6.Text;
                player.controls.play();
                player.settings.volume = volume2;
            }
            if (start && currentStage == 2 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label8.Text == openFileDialog3.FileName)
            {
                player.controls.stop();
                player.URL = label8.Text;
                player.controls.play();
                player.settings.volume = volume3;
            }
            if (start && currentStage == 3 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label10.Text == openFileDialog4.FileName)
            {
                player.controls.stop();
                player.URL = label10.Text;
                player.controls.play();
                player.settings.volume = volume4;
            }
            if (start && currentStage == 4 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label12.Text == openFileDialog5.FileName)
            {
                player.controls.stop();
                player.URL = label12.Text;
                player.controls.play();
                player.settings.volume = volume5;
            }
            if (start && currentStage == 5 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label14.Text == openFileDialog6.FileName)
            {
                player.controls.stop();
                player.URL = label14.Text;
                player.controls.play();
                player.settings.volume = volume6;
            }
            if (start && currentStage == 6 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label16.Text == openFileDialog7.FileName)
            {
                player.controls.stop();
                player.URL = label16.Text;
                player.controls.play();
                player.settings.volume = volume7;
            }
            if (start && currentStage == 7 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label18.Text == openFileDialog8.FileName)
            {
                player.controls.stop();
                player.URL = label18.Text;
                player.controls.play();
                player.settings.volume = volume8;
            }
            if (start && currentStage == 8 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label20.Text == openFileDialog9.FileName)
            {
                player.controls.stop();
                player.URL = label20.Text;
                player.controls.play();
                player.settings.volume = volume9;
            }
            if (start && currentStage == 9 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label22.Text == openFileDialog10.FileName)
            {
                player.controls.stop();
                player.URL = label22.Text;
                player.controls.play();
                player.settings.volume = volume10;
            }
            if (start && currentStage == 30 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label24.Text == openFileDialog11.FileName)
            {
                player.controls.stop();
                player.URL = label24.Text;
                player.controls.play();
                player.settings.volume = volume11;
            }
            if (start && currentStage == 31 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label26.Text == openFileDialog12.FileName)
            {
                player.controls.stop();
                player.URL = label26.Text;
                player.controls.play();
                player.settings.volume = volume12;
            }
            if (start && currentStage == 32 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label28.Text == openFileDialog13.FileName)
            {
                player.controls.stop();
                player.URL = label28.Text;
                player.controls.play();
                player.settings.volume = volume13;
            }
            if (start && currentStage == 33 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label54.Text == openFileDialog14.FileName)
            {
                player.controls.stop();
                player.URL = label54.Text;
                player.controls.play();
                player.settings.volume = volume14;
            }
            if (start && currentStage == 35 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label52.Text == openFileDialog15.FileName)
            {
                player.controls.stop();
                player.URL = label52.Text;
                player.controls.play();
                player.settings.volume = volume15;
            }
            if (start && currentStage == 36 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label50.Text == openFileDialog16.FileName)
            {
                player.controls.stop();
                player.URL = label50.Text;
                player.controls.play();
                player.settings.volume = volume16;
            }
            if (start && currentStage == 37 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label48.Text == openFileDialog17.FileName)
            {
                player.controls.stop();
                player.URL = label48.Text;
                player.controls.play();
                player.settings.volume = volume17;
            }
            if (start && currentStage == 39 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label46.Text == openFileDialog18.FileName)
            {
                player.controls.stop();
                player.URL = label46.Text;
                player.controls.play();
                player.settings.volume = volume18;
            }
            if (start && currentStage == 40 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label44.Text == openFileDialog19.FileName)
            {
                player.controls.stop();
                player.URL = label44.Text;
                player.controls.play();
                player.settings.volume = volume19;
            }
            if (start && currentStage == 41 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label42.Text == openFileDialog20.FileName)
            {
                player.controls.stop();
                player.URL = label42.Text;
                player.controls.play();
                player.settings.volume = volume20;
            }
            if (start && currentStage == 51 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label40.Text == openFileDialog21.FileName)
            {
                player.controls.stop();
                player.URL = label40.Text;
                player.controls.play();
                player.settings.volume = volume21;
            }
            if (start && currentStage == 52 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label38.Text == openFileDialog22.FileName)
            {
                player.controls.stop();
                player.URL = label38.Text;
                player.controls.play();
                player.settings.volume = volume22;
            }
            if (start && currentStage == 53 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label36.Text == openFileDialog23.FileName)
            {
                player.controls.stop();
                player.URL = label36.Text;
                player.controls.play();
                player.settings.volume = volume23;
            }
            if (start && currentStage == 54 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label34.Text == openFileDialog24.FileName)
            {
                player.controls.stop();
                player.URL = label34.Text;
                player.controls.play();
                player.settings.volume = volume24;
            }
            if (start && currentStage == 55 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label32.Text == openFileDialog25.FileName)
            {
                player.controls.stop();
                player.URL = label32.Text;
                player.controls.play();
                player.settings.volume = volume25;
            }
            if (start && currentStage == 42 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label56.Text == openFileDialog28.FileName)
            {
                player.controls.stop();
                player.URL = label56.Text;
                player.controls.play();
                player.settings.volume = volume28;
            }
         
            if(start && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara == 0 && pID != 0)
            {
                mMusic = true;
                player.URL = label58.Text;
                player.controls.play();
                player.settings.volume = volume27;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.Text == "Stop")
            {
                player.controls.stop();
                button3.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog2.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label6.Text;
                player.settings.volume = volume2;
                player.controls.play();
                
                pv = true;

                button3.Text = "Stop";
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            label6.Text = openFileDialog2.FileName;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            volume2 = Convert.ToInt32(numericUpDown2.Value);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Stop")
            {
                player.controls.stop();
                button5.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog3.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label8.Text;
                player.settings.volume = volume3;
                player.controls.play();

                pv = true;

                button5.Text = "Stop";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            label8.Text = openFileDialog3.FileName;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            volume3 = Convert.ToInt32(numericUpDown3.Value);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog4.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "Stop")
            {
                player.controls.stop();
                button7.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog4.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label10.Text;
                player.settings.volume = volume4;
                player.controls.play();

                pv = true;

                button7.Text = "Stop";
            }
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            label10.Text = openFileDialog4.FileName;

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            volume4 = Convert.ToInt32(numericUpDown4.Value);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Stop")
            {
                player.controls.stop();
                button9.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog5.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label12.Text;
                player.settings.volume = volume5;
                player.controls.play();

                pv = true;

                button9.Text = "Stop";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog5.ShowDialog();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            volume5 = Convert.ToInt32(numericUpDown5.Value);

        }

        private void openFileDialog5_FileOk(object sender, CancelEventArgs e)
        {
            label12.Text = openFileDialog5.FileName;

        }

        private void openFileDialog6_FileOk(object sender, CancelEventArgs e)
        {
            label14.Text = openFileDialog6.FileName;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Stop")
            {
                player.controls.stop();
                button11.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog6.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label14.Text;
                player.settings.volume = volume6;
                player.controls.play();

                pv = true;

                button11.Text = "Stop";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog6.ShowDialog();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            volume6 = Convert.ToInt32(numericUpDown6.Value);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Stop")
            {
                player.controls.stop();
                button13.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog7.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label16.Text;
                player.settings.volume = volume7;
                player.controls.play();

                pv = true;

                button13.Text = "Stop";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openFileDialog7.ShowDialog();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            volume7 = Convert.ToInt32(numericUpDown7.Value);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = "Souq Ma Deek";
        }

        private void openFileDialog7_FileOk(object sender, CancelEventArgs e)
        {
            label16.Text = openFileDialog7.FileName;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "Stop")
            {
                player.controls.stop();
                button15.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog8.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label18.Text;
                player.settings.volume = volume8;
                player.controls.play();

                pv = true;

                button15.Text = "Stop";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openFileDialog8.ShowDialog();

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            volume8 = Convert.ToInt32(numericUpDown8.Value);

        }

        private void openFileDialog8_FileOk(object sender, CancelEventArgs e)
        {
            label18.Text = openFileDialog8.FileName;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Text == "Stop")
            {
                player.controls.stop();
                button17.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog9.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label20.Text;
                player.settings.volume = volume9;
                player.controls.play();

                pv = true;

                button17.Text = "Stop";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openFileDialog9.ShowDialog();

        }

        private void openFileDialog9_FileOk(object sender, CancelEventArgs e)
        {
            label20.Text = openFileDialog9.FileName;

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            volume9 = Convert.ToInt32(numericUpDown9.Value);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.Text == "Stop")
            {
                player.controls.stop();
                button19.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog10.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label22.Text;
                player.settings.volume = volume10;
                player.controls.play();

                pv = true;

                button19.Text = "Stop";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openFileDialog10.ShowDialog();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            volume10 = Convert.ToInt32(numericUpDown10.Value);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.Text == "Stop")
            {
                player.controls.stop();
                button21.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog11.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label24.Text;
                player.settings.volume = volume11;
                player.controls.play();

                pv = true;

                button21.Text = "Stop";
            }
        }

        private void openFileDialog11_FileOk(object sender, CancelEventArgs e)
        {
            label24.Text = openFileDialog11.FileName;

        }

        private void openFileDialog10_FileOk(object sender, CancelEventArgs e)
        {
            label22.Text = openFileDialog10.FileName;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            openFileDialog11.ShowDialog();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            volume11 = Convert.ToInt32(numericUpDown11.Value);

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.Text == "Stop")
            {
                player.controls.stop();
                button23.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog12.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label26.Text;
                player.settings.volume = volume12;
                player.controls.play();

                pv = true;

                button23.Text = "Stop";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            openFileDialog12.ShowDialog();
        }

        private void openFileDialog12_FileOk(object sender, CancelEventArgs e)
        {
            label26.Text = openFileDialog12.FileName;
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            volume12 = Convert.ToInt32(numericUpDown12.Value);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.Text == "Stop")
            {
                player.controls.stop();
                button25.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog13.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label28.Text;
                player.settings.volume = volume13;
                player.controls.play();

                pv = true;

                button25.Text = "Stop";
            }
        }

        private void openFileDialog13_FileOk(object sender, CancelEventArgs e)
        {
            label28.Text = openFileDialog13.FileName;
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            volume13 = Convert.ToInt32(numericUpDown13.Value);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            openFileDialog13.ShowDialog();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (button51.Text == "Stop")
            {
                player.controls.stop();
                button51.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog14.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label54.Text;
                player.settings.volume = volume14;
                player.controls.play();

                pv = true;

                button51.Text = "Stop";
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            openFileDialog14.ShowDialog();
        }

        private void openFileDialog14_FileOk(object sender, CancelEventArgs e)
        {
            label54.Text = openFileDialog14.FileName;
        }

        private void numericUpDown26_ValueChanged(object sender, EventArgs e)
        {
            volume14 = Convert.ToInt32(numericUpDown26.Value);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            openFileDialog15.ShowDialog();

        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (button49.Text == "Stop")
            {
                player.controls.stop();
                button49.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog15.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label52.Text;
                player.settings.volume = volume15;
                player.controls.play();

                pv = true;

                button49.Text = "Stop";
            }
        }

        private void numericUpDown25_ValueChanged(object sender, EventArgs e)
        {
            volume15 = Convert.ToInt32(numericUpDown25.Value);

        }

        private void openFileDialog15_FileOk(object sender, CancelEventArgs e)
        {
            label52.Text = openFileDialog15.FileName;

        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (button47.Text == "Stop")
            {
                player.controls.stop();
                button47.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog16.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label50.Text;
                player.settings.volume = volume16;
                player.controls.play();

                pv = true;

                button47.Text = "Stop";
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            openFileDialog16.ShowDialog();

        }

        private void numericUpDown24_ValueChanged(object sender, EventArgs e)
        {
            volume16 = Convert.ToInt32(numericUpDown24.Value);
        }

        private void openFileDialog16_FileOk(object sender, CancelEventArgs e)
        {
            label50.Text = openFileDialog16.FileName;

        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.Text == "Stop")
            {
                player.controls.stop();
                button45.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog17.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label48.Text;
                player.settings.volume = volume17;
                player.controls.play();

                pv = true;

                button45.Text = "Stop";
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            openFileDialog17.ShowDialog();

        }

        private void openFileDialog17_FileOk(object sender, CancelEventArgs e)
        {
            label48.Text = openFileDialog17.FileName;

        }

        private void numericUpDown23_ValueChanged(object sender, EventArgs e)
        {
            volume17 = Convert.ToInt32(numericUpDown23.Value);

        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (button43.Text == "Stop")
            {
                player.controls.stop();
                button43.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog18.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label46.Text;
                player.settings.volume = volume18;
                player.controls.play();

                pv = true;

                button43.Text = "Stop";
            }

        }

        private void button44_Click(object sender, EventArgs e)
        {
            openFileDialog18.ShowDialog();

        }

        private void openFileDialog18_FileOk(object sender, CancelEventArgs e)
        {
            label46.Text = openFileDialog18.FileName;

        }

        private void numericUpDown22_ValueChanged(object sender, EventArgs e)
        {
            volume18 = Convert.ToInt32(numericUpDown22.Value);

        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.Text == "Stop")
            {
                player.controls.stop();
                button41.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog19.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label44.Text;
                player.settings.volume = volume19;
                player.controls.play();

                pv = true;

                button41.Text = "Stop";
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            openFileDialog19.ShowDialog();

        }

        private void openFileDialog19_FileOk(object sender, CancelEventArgs e)
        {
            label44.Text = openFileDialog19.FileName;

        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            volume19 = Convert.ToInt32(numericUpDown21.Value);

        }

        private void button39_Click(object sender, EventArgs e)
        {
            if(button39.Text == "Stop")
            {
                player.controls.stop();
                button39.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog20.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label42.Text;
                player.settings.volume = volume20;
                player.controls.play();

                pv = true;

                button39.Text = "Stop";
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            openFileDialog20.ShowDialog();

        }

        private void openFileDialog20_FileOk(object sender, CancelEventArgs e)
        {
            label42.Text = openFileDialog20.FileName;

        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {
            volume20 = Convert.ToInt32(numericUpDown20.Value);

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.Text == "Stop")
            {
                player.controls.stop();
                button37.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog21.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label40.Text;
                player.settings.volume = volume21;
                player.controls.play();

                pv = true;

                button37.Text = "Stop";
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            openFileDialog21.ShowDialog();

        }

        private void openFileDialog21_FileOk(object sender, CancelEventArgs e)
        {
            label40.Text = openFileDialog21.FileName;

        }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            volume21 = Convert.ToInt32(numericUpDown19.Value);

        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (button35.Text == "Stop")
            {
                player.controls.stop();
                button35.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog22.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label38.Text;
                player.settings.volume = volume22;
                player.controls.play();

                pv = true;

                button35.Text = "Stop";
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            openFileDialog22.ShowDialog();

        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            volume22 = Convert.ToInt32(numericUpDown18.Value);

        }

        private void openFileDialog22_FileOk(object sender, CancelEventArgs e)
        {
            label38.Text = openFileDialog22.FileName;

        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.Text == "Stop")
            {
                player.controls.stop();
                button33.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog23.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label36.Text;
                player.settings.volume = volume23;
                player.controls.play();

                pv = true;

                button33.Text = "Stop";
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            openFileDialog23.ShowDialog();

        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            volume23 = Convert.ToInt32(numericUpDown17.Value);

        }

        private void openFileDialog23_FileOk(object sender, CancelEventArgs e)
        {
            label36.Text = openFileDialog23.FileName;

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.Text == "Stop")
            {
                player.controls.stop();
                button31.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog24.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label34.Text;
                player.settings.volume = volume24;
                player.controls.play();

                pv = true;

                button31.Text = "Stop";
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            openFileDialog24.ShowDialog();

        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            volume24 = Convert.ToInt32(numericUpDown16.Value);

        }

        private void openFileDialog24_FileOk(object sender, CancelEventArgs e)
        {
            label34.Text = openFileDialog24.FileName;

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.Text == "Stop")
            {
                player.controls.stop();
                button29.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog25.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label32.Text;
                player.settings.volume = volume25;
                player.controls.play();

                pv = true;

                button29.Text = "Stop";
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            openFileDialog25.ShowDialog();

        }

        private void openFileDialog25_FileOk(object sender, CancelEventArgs e)
        {
            label32.Text = openFileDialog25.FileName;

        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            volume25 = Convert.ToInt32(numericUpDown15.Value);

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.Text == "Stop")
            {
                player.controls.stop();
                button27.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog26.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label30.Text;
                player.settings.volume = volume26;
                player.controls.play();

                pv = true;

                button27.Text = "Stop";
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            openFileDialog26.ShowDialog();

        }

        private void openFileDialog26_FileOk(object sender, CancelEventArgs e)
        {
            label30.Text = openFileDialog26.FileName;

        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            volume26 = Convert.ToInt32(numericUpDown14.Value);

        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (button53.Text == "Stop")
            {
                player.controls.stop();
                button53.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog28.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label56.Text;
                player.settings.volume = volume28;
                player.controls.play();

                pv = true;

                button53.Text = "Stop";
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            openFileDialog28.ShowDialog();

        }

        private void openFileDialog28_FileOk(object sender, CancelEventArgs e)
        {
            label56.Text = openFileDialog28.FileName;

        }

        private void numericUpDown27_ValueChanged(object sender, EventArgs e)
        {
            volume28 = Convert.ToInt32(numericUpDown27.Value);

        }

        private void button55_Click(object sender, EventArgs e)
        {
            if(button55.Text == "Stop")
            {
                player.controls.stop();
                button55.Text = "Preview";
                pv = false;
            }
            else if (openFileDialog27.FileName != "")
            {
                /* player.URL = openFileDialog1.FileName;
                 player.settings.volume = volume1;
                 player.controls.play();
                 */
                player.URL = label58.Text;
                player.settings.volume = volume27;
                player.controls.play();

                pv = true;

                button55.Text = "Stop";
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            openFileDialog27.ShowDialog();

        }

        private void numericUpDown28_ValueChanged(object sender, EventArgs e)
        {
            volume27 = Convert.ToInt32(numericUpDown28.Value);

        }

        private void openFileDialog27_FileOk(object sender, CancelEventArgs e)
        {
            label58.Text = openFileDialog27.FileName;

        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (button57.Text == "Start Jukebox!")
            {
                start = true;
                button57.Text = "Stop Jukebox";
            }
            else if(button57.Text == "Stop Jukebox")
            {
                start = false;
                player.controls.stop();
                button57.Text = "Start Jukebox!";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Volume1 = volume1;
            Properties.Settings.Default.Volume2 = volume2;
            Properties.Settings.Default.Volume3 = volume3;
            Properties.Settings.Default.Volume4 = volume4;
            Properties.Settings.Default.Volume5 = volume5;
            Properties.Settings.Default.Volume6 = volume6;
            Properties.Settings.Default.Volume7 = volume7;
            Properties.Settings.Default.Volume8 = volume8;
            Properties.Settings.Default.Volume9 = volume9;
            Properties.Settings.Default.Volume10 = volume10;
            Properties.Settings.Default.Volume11 = volume11;
            Properties.Settings.Default.Volume12 = volume12;
            Properties.Settings.Default.Volume13 = volume13;
            Properties.Settings.Default.Volume14 = volume14;
            Properties.Settings.Default.Volume15 = volume15;
            Properties.Settings.Default.Volume16 = volume16;
            Properties.Settings.Default.Volume17 = volume17;
            Properties.Settings.Default.Volume18 = volume18;
            Properties.Settings.Default.Volume19 = volume19;
            Properties.Settings.Default.Volume20 = volume20;
            Properties.Settings.Default.Volume21 = volume21;
            Properties.Settings.Default.Volume22 = volume22;
            Properties.Settings.Default.Volume23 = volume23;
            Properties.Settings.Default.Volume24 = volume24;
            Properties.Settings.Default.Volume25 = volume25;
            Properties.Settings.Default.Volume26 = volume26;
            Properties.Settings.Default.Volume27 = volume27;
            Properties.Settings.Default.Volume28 = volume28;
            Properties.Settings.Default.Label1 = label1.Text;
            Properties.Settings.Default.Label6 = label6.Text;
            Properties.Settings.Default.Label8 = label8.Text;
            Properties.Settings.Default.Label10 = label10.Text;
            Properties.Settings.Default.Label12 = label12.Text;
            Properties.Settings.Default.Label14 = label14.Text;
            Properties.Settings.Default.Label16 = label16.Text;
            Properties.Settings.Default.Label18 = label18.Text;
            Properties.Settings.Default.Label20 = label20.Text;
            Properties.Settings.Default.Label22 = label22.Text;
            Properties.Settings.Default.Label24 = label24.Text;
            Properties.Settings.Default.Label26 = label26.Text;
            Properties.Settings.Default.Label28 = label28.Text;
            Properties.Settings.Default.Label30 = label30.Text;
            Properties.Settings.Default.Label32 = label32.Text;
            Properties.Settings.Default.Label34 = label34.Text;
            Properties.Settings.Default.Label36 = label36.Text;
            Properties.Settings.Default.Label38 = label38.Text;
            Properties.Settings.Default.Label40 = label40.Text;
            Properties.Settings.Default.Label42 = label42.Text;
            Properties.Settings.Default.Label44 = label44.Text;
            Properties.Settings.Default.Label46 = label46.Text;
            Properties.Settings.Default.Label48 = label48.Text;
            Properties.Settings.Default.Label50 = label50.Text;
            Properties.Settings.Default.Label52 = label52.Text;
            Properties.Settings.Default.Label54 = label54.Text;
            Properties.Settings.Default.Label56 = label56.Text;
            Properties.Settings.Default.Label58 = label58.Text;




            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            
        }

        private void button58_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

        }
    }
}
