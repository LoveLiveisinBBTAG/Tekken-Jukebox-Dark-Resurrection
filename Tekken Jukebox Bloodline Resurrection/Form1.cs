﻿using System;
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
        
        int pID = 0;

        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Value = Properties.Settings.Default.Volume1;
            numericUpDown2.Value = Properties.Settings.Default.Volume2;
            numericUpDown3.Value = Properties.Settings.Default.Volume3;
            numericUpDown4.Value = Properties.Settings.Default.Volume4;
            numericUpDown5.Value = Properties.Settings.Default.Volume5;
            numericUpDown6.Value = Properties.Settings.Default.Volume6;
            numericUpDown7.Value = Properties.Settings.Default.Volume7;
            numericUpDown8.Value = Properties.Settings.Default.Volume8;
            numericUpDown9.Value = Properties.Settings.Default.Volume9;
            numericUpDown10.Value = Properties.Settings.Default.Volume10;
            numericUpDown11.Value = Properties.Settings.Default.Volume11;
            numericUpDown12.Value = Properties.Settings.Default.Volume12;
            numericUpDown13.Value = Properties.Settings.Default.Volume13;
            numericUpDown26.Value = Properties.Settings.Default.Volume14;
            numericUpDown25.Value = Properties.Settings.Default.Volume15;
            numericUpDown24.Value = Properties.Settings.Default.Volume16;
            numericUpDown23.Value = Properties.Settings.Default.Volume17;
            numericUpDown22.Value = Properties.Settings.Default.Volume18;
            numericUpDown21.Value = Properties.Settings.Default.Volume19;
            numericUpDown20.Value = Properties.Settings.Default.Volume20;
            numericUpDown19.Value = Properties.Settings.Default.Volume21;
            numericUpDown18.Value = Properties.Settings.Default.Volume22;
            numericUpDown17.Value = Properties.Settings.Default.Volume23;
            numericUpDown16.Value = Properties.Settings.Default.Volume24;
            numericUpDown15.Value = Properties.Settings.Default.Volume25;
            numericUpDown14.Value = Properties.Settings.Default.Volume26;
            numericUpDown28.Value = Properties.Settings.Default.Volume27;
            numericUpDown27.Value = Properties.Settings.Default.Volume28;




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

        int opSide = -1;
        bool mMusic;
        bool start = false;
        bool inMatch = false;
        int currentStage;
        int currentRanked; 
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
                    opSide = m.readInt("TekkenGame-Win64-Shipping.exe+0346F810,0x0,0x8,0x70");
                     currentStage = m.readInt("TekkenGame-Win64-Shipping.exe+0x346F810,0x0,0x0,0x18");
                     currentRanked = m.readInt("TekkenGame-Win64-Shipping.exe+0x3468330,0x68,0x8,0x0,0x470,0x24");
                     chara = m.readInt("TekkenGame-Win64-Shipping.exe+034BC4C0");
                     input = m.readInt("TekkenGame-Win64-Shipping.exe+034BC4C0,0x0,0x0,0x1760");
                    if (chara != 0 && !inMatch && input == 32)
                        inMatch = true;
                    else if(inMatch && chara == 0)
                    {
                        inMatch = false;
                    }
                    if(opSide > 2 || opSide < -1)
                    {
                        opSide = -1;
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
                player.settings.volume = Convert.ToInt32(numericUpDown1.Value);
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
            
            if (start && currentStage == 0 && chara != 0 && inMatch && label1.Text != "File path not found" || start && currentRanked == 0 && chara != 0 && inMatch && player.URL != label1.Text )
            {

                WmpPlay(label1.Text, Convert.ToInt32(numericUpDown1.Value));
                
            }
            if (start && currentStage == 1 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label6.Text != "File path not found" || start && currentRanked == 1 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label6.Text)
            {
                WmpPlay(label6.Text, Convert.ToInt32(numericUpDown2.Value));             
            }
            if (start && currentStage == 2 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label8.Text != "File path not found" || start && currentRanked == 2 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label8.Text)
            {
                WmpPlay(label8.Text, Convert.ToInt32(numericUpDown3.Value));               
            }
            if (start && currentStage == 3 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label10.Text != "File path not found" || start && currentRanked == 3 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label10.Text)
            {
                WmpPlay(label10.Text, Convert.ToInt32(numericUpDown4.Value));            
            }
            if (start && currentStage == 4 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label12.Text != "File path not found" || start && currentRanked == 4 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label12.Text)
            {
                WmpPlay(label12.Text, Convert.ToInt32(numericUpDown5.Value));
            }
            if (start && currentStage == 5 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label14.Text != "File path not found" || start && currentRanked == 5 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label14.Text)
            {
                WmpPlay(label14.Text, Convert.ToInt32(numericUpDown6.Value));

            }
            if (start && currentStage == 6 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label16.Text != "File path not found" || start && currentRanked == 6 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label16.Text)
            {
                WmpPlay(label16.Text, Convert.ToInt32(numericUpDown7.Value));

            }
            if (start && currentStage == 7 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label18.Text != "File path not found" || start && currentRanked == 7 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label18.Text)
            {
                WmpPlay(label18.Text, Convert.ToInt32(numericUpDown8.Value));

            }
            if (start && currentStage == 8 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label20.Text != "File path not found" || start && currentRanked == 8 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label20.Text)
            {
                WmpPlay(label20.Text, Convert.ToInt32(numericUpDown9.Value));
            }
            if (start && currentStage == 9 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label22.Text != "File path not found" || start && currentRanked == 9 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label22.Text)
            {
                WmpPlay(label22.Text, Convert.ToInt32(numericUpDown10.Value));

            }
            if (start && currentStage == 30 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label24.Text != "File path not found" || start && currentRanked == 30 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label24.Text)
            {
                WmpPlay(label24.Text, Convert.ToInt32(numericUpDown11.Value));
            }
            if (start && currentStage == 31 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label26.Text != "File path not found" || start && currentRanked == 31 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label26.Text)
            {
                WmpPlay(label26.Text, Convert.ToInt32(numericUpDown12.Value));

            }
            if (start && currentStage == 32 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label28.Text != "File path not found" || start && currentRanked == 32 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label28.Text)
            {
                WmpPlay(label28.Text, Convert.ToInt32(numericUpDown13.Value));

            }
            if (start && currentStage == 33 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label54.Text != "File path not found" || start && currentRanked == 33 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label54.Text)
            {
                WmpPlay(label54.Text, Convert.ToInt32(numericUpDown26.Value));

            }
            if (start && currentStage == 35 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label52.Text != "File path not found" || start && currentRanked == 35 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label52.Text)
            {
                WmpPlay(label52.Text, Convert.ToInt32(numericUpDown25.Value));

            }
            if (start && currentStage == 36 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label50.Text != "File path not found" || start && currentRanked == 36 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label50.Text)
            {
                WmpPlay(label50.Text, Convert.ToInt32(numericUpDown24.Value));

            }
            if (start && currentStage == 37 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label48.Text != "File path not found" || start && currentRanked == 37 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label48.Text)
            {
                WmpPlay(label48.Text, Convert.ToInt32(numericUpDown23.Value));

            }
            if (start && currentStage == 39 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label46.Text != "File path not found" || start && currentRanked == 39 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label46.Text)
            {
                WmpPlay(label46.Text, Convert.ToInt32(numericUpDown22.Value));

            }
            if (start && currentStage == 40 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label44.Text != "File path not found" || start && currentRanked == 40 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label44.Text)
            {
                WmpPlay(label44.Text, Convert.ToInt32(numericUpDown21.Value));

            }
            if (start && currentStage == 41 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label42.Text != "File path not found" || start && currentRanked == 41 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label42.Text)
            {
                WmpPlay(label42.Text, Convert.ToInt32(numericUpDown20.Value));

            }
            if (start && currentStage == 51 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label40.Text != "File path not found" || start && currentRanked == 51 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label40.Text)
            {
                WmpPlay(label40.Text, Convert.ToInt32(numericUpDown19.Value));

            }
            if (start && currentStage == 52 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label38.Text != "File path not found" || start && currentRanked == 52 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label38.Text)
            {
                WmpPlay(label38.Text, Convert.ToInt32(numericUpDown18.Value));

            }
            if (start && currentStage == 53 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label36.Text != "File path not found" || start && currentRanked == 53 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label36.Text)
            {
                WmpPlay(label36.Text, Convert.ToInt32(numericUpDown17.Value));

            }
            if (start && currentStage == 54 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label34.Text != "File path not found" || start && currentRanked == 54 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label34.Text)
            {
                WmpPlay(label34.Text, Convert.ToInt32(numericUpDown16.Value));

            }
            if (start && currentStage == 55 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label32.Text != "File path not found" || start && currentRanked == 55 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label32.Text)
            {
                WmpPlay(label32.Text, Convert.ToInt32(numericUpDown15.Value));
            }
            if (start && currentStage == 56 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label30.Text != "File path not found" || start && currentRanked == 56 && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label30.Text)
            {
                WmpPlay(label30.Text, Convert.ToInt32(numericUpDown14.Value));
            }
            if (start && currentStage == 42 && currentStage == currentRanked && player.playState != WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && label56.Text != "File path not found" || start && currentRanked == 42 && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && inMatch && player.URL != label56.Text)
            {
                WmpPlay(label56.Text, Convert.ToInt32(numericUpDown27.Value));

            }

            if (start && chara == 0 && pID != 0 && currentRanked == currentStage && opSide != 1 && !inMatch && !mMusic || start && chara == 0 && pID != 0 && currentRanked == currentStage && opSide == 0 && !inMatch && !mMusic && currentRanked == 42 || start && chara == 0 && pID != 0 && currentRanked != currentStage && currentRanked != 42 && opSide != 1 && opSide != 0 && opSide != 3 && !mMusic ||mMusic && !inMatch &&   Math.Floor(player.currentMedia.duration - player.controls.currentPosition) == 0)
            {
                
                mMusic = true;
                WmpPlay(label58.Text, Convert.ToInt32(numericUpDown28.Value));

            }
            if (start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara == 0 && !pv && mMusic && currentRanked != currentStage && currentStage == 42 && opSide <= 4 || start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara == 0 && !pv && !mMusic /*|| !mMusic && start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv*/ || start && mMusic && chara != 0 && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !inMatch /*|| start && player.playState != WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv && label58.Text == openFileDialog27.FileName*/)
            {
                player.controls.stop();
                player.URL = "";
                mMusic = false;
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
                WmpPlay(label6.Text, Convert.ToInt32(numericUpDown2.Value));                               
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
                WmpPlay(label8.Text, Convert.ToInt32(numericUpDown3.Value));
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
                WmpPlay(label10.Text, Convert.ToInt32(numericUpDown4.Value));
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
                WmpPlay(label12.Text, Convert.ToInt32(numericUpDown5.Value));
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
                WmpPlay(label14.Text, Convert.ToInt32(numericUpDown6.Value));
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
                WmpPlay(label16.Text, Convert.ToInt32(numericUpDown7.Value));
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
                WmpPlay(label18.Text, Convert.ToInt32(numericUpDown8.Value));
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
                WmpPlay(label20.Text, Convert.ToInt32(numericUpDown9.Value));
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
                WmpPlay(label22.Text, Convert.ToInt32(numericUpDown10.Value));
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
                WmpPlay(label24.Text, Convert.ToInt32(numericUpDown11.Value));

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
                WmpPlay(label26.Text, Convert.ToInt32(numericUpDown12.Value));

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
                WmpPlay(label28.Text, Convert.ToInt32(numericUpDown13.Value));


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
                WmpPlay(label54.Text, Convert.ToInt32(numericUpDown26.Value));


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
                WmpPlay(label52.Text, Convert.ToInt32(numericUpDown25.Value));


                pv = true;

                button49.Text = "Stop";
            }
        }

        private void numericUpDown25_ValueChanged(object sender, EventArgs e)
        {

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
                WmpPlay(label50.Text, Convert.ToInt32(numericUpDown24.Value));


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
                WmpPlay(label48.Text, Convert.ToInt32(numericUpDown23.Value));

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
                WmpPlay(label46.Text, Convert.ToInt32(numericUpDown22.Value));


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
                WmpPlay(label44.Text, Convert.ToInt32(numericUpDown21.Value));

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
                WmpPlay(label42.Text, Convert.ToInt32(numericUpDown20.Value));


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
                WmpPlay(label40.Text, Convert.ToInt32(numericUpDown19.Value));


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
                WmpPlay(label38.Text, Convert.ToInt32(numericUpDown18.Value));

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
                WmpPlay(label36.Text, Convert.ToInt32(numericUpDown17.Value));


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
                WmpPlay(label34.Text, Convert.ToInt32(numericUpDown16.Value));

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
                WmpPlay(label32.Text, Convert.ToInt32(numericUpDown15.Value));


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
                WmpPlay(label30.Text, Convert.ToInt32(numericUpDown14.Value));


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
                WmpPlay(label56.Text, Convert.ToInt32(numericUpDown27.Value));


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
                WmpPlay(label58.Text, Convert.ToInt32(numericUpDown28.Value));


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

        void WmpPlay(string u, int v)
        {

            player.controls.stop();
            player.close();
            player.URL = u;
            player.controls.play();
            player.settings.volume = v;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Volume1 = Convert.ToInt32(numericUpDown1.Value);
            Properties.Settings.Default.Volume2 = Convert.ToInt32(numericUpDown2.Value);
            Properties.Settings.Default.Volume3 = Convert.ToInt32(numericUpDown3.Value);
            Properties.Settings.Default.Volume4 = Convert.ToInt32(numericUpDown4.Value);
            Properties.Settings.Default.Volume5 = Convert.ToInt32(numericUpDown5.Value);
            Properties.Settings.Default.Volume6 = Convert.ToInt32(numericUpDown6.Value);
            Properties.Settings.Default.Volume7 = Convert.ToInt32(numericUpDown7.Value);
            Properties.Settings.Default.Volume8 = Convert.ToInt32(numericUpDown8.Value);
            Properties.Settings.Default.Volume9 = Convert.ToInt32(numericUpDown9.Value);
            Properties.Settings.Default.Volume10 = Convert.ToInt32(numericUpDown10.Value);
            Properties.Settings.Default.Volume11 = Convert.ToInt32(numericUpDown11.Value);
            Properties.Settings.Default.Volume12 = Convert.ToInt32(numericUpDown12.Value);
            Properties.Settings.Default.Volume13 = Convert.ToInt32(numericUpDown13.Value);
            Properties.Settings.Default.Volume14 = Convert.ToInt32(numericUpDown26.Value);
            Properties.Settings.Default.Volume15 = Convert.ToInt32(numericUpDown25.Value);
            Properties.Settings.Default.Volume16 = Convert.ToInt32(numericUpDown24.Value);
            Properties.Settings.Default.Volume17 = Convert.ToInt32(numericUpDown23.Value);
            Properties.Settings.Default.Volume18 = Convert.ToInt32(numericUpDown22.Value);
            Properties.Settings.Default.Volume19 = Convert.ToInt32(numericUpDown21.Value);
            Properties.Settings.Default.Volume20 = Convert.ToInt32(numericUpDown20.Value);
            Properties.Settings.Default.Volume21 = Convert.ToInt32(numericUpDown19.Value);
            Properties.Settings.Default.Volume22 = Convert.ToInt32(numericUpDown18.Value);
            Properties.Settings.Default.Volume23 = Convert.ToInt32(numericUpDown17.Value);
            Properties.Settings.Default.Volume24 = Convert.ToInt32(numericUpDown16.Value);
            Properties.Settings.Default.Volume25 = Convert.ToInt32(numericUpDown15.Value);
            Properties.Settings.Default.Volume26 = Convert.ToInt32(numericUpDown14.Value);
            Properties.Settings.Default.Volume27 = Convert.ToInt32(numericUpDown28.Value);
            Properties.Settings.Default.Volume28 = Convert.ToInt32(numericUpDown27.Value);
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

        private void numericUpDown16_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
