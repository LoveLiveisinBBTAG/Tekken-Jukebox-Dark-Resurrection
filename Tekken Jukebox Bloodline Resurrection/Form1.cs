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
using System.Diagnostics;


namespace Tekken_Jukebox_Bloodline_Resurrection
{
    public partial class Form1 : Form
    {
        List<Button> lColors;
        List<CheckBox> timeChecks;
        List<NumericUpDown> numValues;
        List<Label> labels;

        int pID = 0;
        string[] files = new string[57];
        int[] volumes = new int[57];
        bool[] checks = new bool[57];
        float[] times = new float[57];
        public Form1()
        {
            InitializeComponent();




          


            lColors = Controls.OfType<Button>().Concat(panel1.Controls.OfType<Button>()).ToList();
            timeChecks = panel2.Controls.OfType<CheckBox>().ToList();
            numValues = Controls.OfType<NumericUpDown>().Concat(panel2.Controls.OfType<NumericUpDown>()).ToList();
            labels = Controls.OfType<Label>().Concat(panel1.Controls.OfType<Label>()).ToList();
            if (Properties.Settings.Default.firstsave)
            {
                volumes = Properties.Settings.Default.volumes;
                files = Properties.Settings.Default.files;
                times = Properties.Settings.Default.times;
                checks = Properties.Settings.Default.checkboxes;


                foreach (NumericUpDown n in numValues)
                {
                    if (n.Tag != null && int.Parse(n.Tag.ToString()) < 100)
                    {
                        
                        n.Value = volumes[int.Parse(n.Tag.ToString())];
                    }
                    else if (n.Tag != null && int.Parse(n.Tag.ToString()) >= 100)
                    {
                        n.Value = (decimal)times[int.Parse(n.Tag.ToString()) - 100];
                    }

                }

                foreach (Label l in labels)
                {
                    if (l.Tag != null && files[int.Parse(l.Tag.ToString())] != null)
                    {
                        Console.WriteLine("AOIHAEROIEWAIRFJI0" + files[0]);
                        l.Text = files[int.Parse(l.Tag.ToString())];
                    }
                    else if(l.Tag != null)
                        l.Text = "File path not found";


                }


                foreach (CheckBox c in timeChecks)
                {
                    if (c.Tag != null && int.Parse(c.Tag.ToString()) <= 55)
                    {
                        c.Checked = checks[int.Parse(c.Tag.ToString())];
                    }


                }
            }

        
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
        int round;
        bool finalRound = false;
        int bitch = 0;

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
                     //Opponent side, could probably be removed by now
                     opSide = m.readInt("TekkenGame-Win64-Shipping.exe+0x0349ABB0,0x0,0x8,0x70");
                     //Current loaded stage (non-ranked)
                     currentStage = m.readInt("TekkenGame-Win64-Shipping.exe+0x0349ABB0,0x0,0x0,0x18");
                     //Currently loaded ranked stage (dunno about player match)
                     currentRanked = m.readInt("TekkenGame-Win64-Shipping.exe+0x034936C0,0x68,0x8,0x0,0x470,0x24");
                     //Offset for player data, reads as 1 when a character is loaded. 
                     chara = m.readInt("TekkenGame-Win64-Shipping.exe+0x034E9388,0x4");
                     //Current input direction, could probably be removed by now
                     input = m.readInt("TekkenGame-Win64-Shipping.exe+0x034E9388,0x8,0x0,0x1960");
                     //Current round, does not track remaining rounds however, so final round script only works if 6 rounds in total
                     round = m.readInt("TekkenGame-Win64-Shipping.exe+0x034936C0,0x68,0x8,0x0,0x470,0x50");
                    //Previously, inMatch was used because I used the entire player data pointer offset by 8 instead of 4, which would return a random value when a char is loaded.
                    //Could probably be removed.
                    if (chara != 0 && !inMatch /*&& input == 32*/)
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
            files[0] = openFileDialog1.FileName;
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
                player.URL = "";

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

            if (m.readString("TekkenGame-Win64-Shipping.exe+0x034B0C90,0x2E8") == "[NSB]" && bitch == 0)
            {

                bitch++;
                Select();
                Focus();
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show(new Form() { TopMost = true }, "Bitch");


                

            }




            //Looper
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying && Math.Floor(player.currentMedia.duration - player.controls.currentPosition) == 0)
            {
                if (round != 5)
                    player.controls.currentPosition = 0;

                if (round == 5)
                {
                    foreach (CheckBox c in timeChecks)
                    {
                        if (int.Parse(c.Tag.ToString()) == currentRanked && c.Checked && round == 5 && currentRanked != currentStage || int.Parse(c.Tag.ToString()) == currentStage && c.Checked && round == 5)
                        {
                            foreach (NumericUpDown n in numValues)
                            {
                                if (int.Parse(n.Tag.ToString()) == currentRanked + 100 && currentRanked != currentStage || int.Parse(n.Tag.ToString()) == currentStage + 100)
                                {
                                    player.controls.currentPosition = (double)n.Value;
                                    finalRound = true;
                                }
                            }
                        }
                    }
                }
            }


            if(start && chara != 0 && files[currentStage] != "" && files[currentRanked] != "" && inMatch && player.playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                if(currentRanked == currentStage && player.URL != files[currentStage] && !mMusic && input == 32)
                    WmpPlay(files[currentStage], volumes[currentStage]);
                if(currentRanked != currentStage && currentStage == 42 && player.URL != files[currentRanked] && !mMusic)
                    WmpPlay(files[currentRanked], volumes[currentRanked]);
                
            }

            if (start && chara != 0 && round == 5 && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !finalRound)
            {
                foreach (CheckBox c in timeChecks)
                {
                    if (int.Parse(c.Tag.ToString()) == currentRanked && c.Checked && currentRanked != currentStage || int.Parse(c.Tag.ToString()) == currentStage && c.Checked)
                    {
                        foreach (NumericUpDown n in numValues)
                        {
                            if (int.Parse(n.Tag.ToString()) == currentRanked + 100 && currentRanked != currentStage || int.Parse(n.Tag.ToString()) == currentStage + 100)
                            {
                                player.controls.currentPosition = (double)n.Value;
                                finalRound = true;
                            }
                        }
                    }
                }
            }
            if (start && chara == 0 && pID != 0 && currentRanked == currentStage && opSide != 1 && !inMatch && !mMusic || start && chara == 0 && pID != 0 && currentRanked == currentStage && opSide == 0 && !inMatch && !mMusic && currentRanked == 42 || start && chara == 0 && pID != 0 && currentRanked != currentStage && currentRanked != 42 && opSide != 1 && opSide != 0 && opSide != 3 && !mMusic || start && chara == 0 && pID != 0 && currentStage == 255 && !inMatch && !mMusic)
            {
                if (currentStage != 42 && currentRanked != 42) { 
                    mMusic = true;
                WmpPlay(label58.Text, Convert.ToInt32(numericUpDown28.Value)); }

            }
            if (start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara != 0 && !pv && mMusic && currentRanked != currentStage && currentStage == 42  || start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && chara == 0 && !pv && !mMusic /*|| !mMusic && start && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv*/ || start && mMusic && chara != 0 && player.playState == WMPLib.WMPPlayState.wmppsPlaying && !inMatch /*|| start && player.playState != WMPLib.WMPPlayState.wmppsPlaying && !inMatch && !pv && label58.Text == openFileDialog27.FileName*/)
            {
                player.controls.stop();
                player.URL = "";
                mMusic = false;
                finalRound = false;
            }

            //



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
                player.URL = "";

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
            files[1] = openFileDialog2.FileName;

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            volumes[1] = Convert.ToInt32(numericUpDown2.Value);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[2] = openFileDialog3.FileName;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            volumes[2] = Convert.ToInt32(numericUpDown3.Value);

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
                player.URL = "";

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
            files[3] = openFileDialog4.FileName;

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            volumes[3] = Convert.ToInt32(numericUpDown4.Value);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[4] = Convert.ToInt32(numericUpDown5.Value);

        }

        private void openFileDialog5_FileOk(object sender, CancelEventArgs e)
        {
            label12.Text = openFileDialog5.FileName;
            files[4] = openFileDialog5.FileName;

        }

        private void openFileDialog6_FileOk(object sender, CancelEventArgs e)
        {
            label14.Text = openFileDialog6.FileName;
            files[5] = openFileDialog6.FileName;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[5] = Convert.ToInt32(numericUpDown6.Value);

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[6] = Convert.ToInt32(numericUpDown7.Value);

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
            files[6] = openFileDialog7.FileName;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[7] = Convert.ToInt32(numericUpDown8.Value);

        }

        private void openFileDialog8_FileOk(object sender, CancelEventArgs e)
        {
            label18.Text = openFileDialog8.FileName;
            files[7] = openFileDialog8.FileName;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[8] = openFileDialog9.FileName;

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            volumes[8] = Convert.ToInt32(numericUpDown9.Value);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[9] = Convert.ToInt32(numericUpDown10.Value);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[30] = openFileDialog11.FileName;

        }

        private void openFileDialog10_FileOk(object sender, CancelEventArgs e)
        {
            label22.Text = openFileDialog10.FileName;
            files[9] = openFileDialog10.FileName;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            openFileDialog11.ShowDialog();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            volumes[30] = Convert.ToInt32(numericUpDown11.Value);

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[31] = openFileDialog12.FileName;

        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            volumes[31] = Convert.ToInt32(numericUpDown12.Value);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[32] = openFileDialog13.FileName;

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            volumes[32] = Convert.ToInt32(numericUpDown13.Value);

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
                player.URL = "";

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
            files[33] = openFileDialog14.FileName;

        }

        private void numericUpDown26_ValueChanged(object sender, EventArgs e)
        {
            volumes[33] = Convert.ToInt32(numericUpDown26.Value);

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
                player.URL = "";

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
            volumes[35] = Convert.ToInt32(numericUpDown25.Value);

        }

        private void openFileDialog15_FileOk(object sender, CancelEventArgs e)
        {
            label52.Text = openFileDialog15.FileName;
            files[35] = openFileDialog15.FileName;


        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (button47.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[36] = Convert.ToInt32(numericUpDown24.Value);

        }

        private void openFileDialog16_FileOk(object sender, CancelEventArgs e)
        {
            label50.Text = openFileDialog16.FileName;
            files[36] = openFileDialog16.FileName;

        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[37] = openFileDialog17.FileName;

        }

        private void numericUpDown23_ValueChanged(object sender, EventArgs e)
        {
            volumes[37] = Convert.ToInt32(numericUpDown23.Value);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (button43.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[39] = openFileDialog18.FileName;


        }

        private void numericUpDown22_ValueChanged(object sender, EventArgs e)
        {
            volumes[39] = Convert.ToInt32(numericUpDown22.Value);

        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[40] = openFileDialog19.FileName;

        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)
        {
            volumes[40] = Convert.ToInt32(numericUpDown21.Value);

        }

        private void button39_Click(object sender, EventArgs e)
        {
            if(button39.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[41] = openFileDialog20.FileName;


        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {
            volumes[41] = Convert.ToInt32(numericUpDown20.Value);

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[51] = openFileDialog21.FileName;

        }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            volumes[51] = Convert.ToInt32(numericUpDown19.Value);

        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (button35.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[52] = Convert.ToInt32(numericUpDown18.Value);

        }

        private void openFileDialog22_FileOk(object sender, CancelEventArgs e)
        {
            label38.Text = openFileDialog22.FileName;
            files[52] = openFileDialog22.FileName;

        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[53] = Convert.ToInt32(numericUpDown17.Value);

        }

        private void openFileDialog23_FileOk(object sender, CancelEventArgs e)
        {
            label36.Text = openFileDialog23.FileName;
            files[53] = openFileDialog23.FileName;

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            volumes[54] = Convert.ToInt32(numericUpDown16.Value);

        }

        private void openFileDialog24_FileOk(object sender, CancelEventArgs e)
        {
            label34.Text = openFileDialog24.FileName;
            files[54] = openFileDialog24.FileName;

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[55] = openFileDialog25.FileName;

        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            volumes[55] = Convert.ToInt32(numericUpDown15.Value);

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[56] = openFileDialog26.FileName;

        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            volumes[56] = Convert.ToInt32(numericUpDown14.Value);

        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (button53.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
            files[42] = openFileDialog28.FileName;

        }

        private void numericUpDown27_ValueChanged(object sender, EventArgs e)
        {
            volumes[42] = Convert.ToInt32(numericUpDown27.Value);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if(button55.Text == "Stop")
            {
                player.controls.stop();
                player.URL = "";

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
                player.controls.stop();
                player.URL = "";
                mMusic = false;
                start = true;
                button57.Text = "Stop Jukebox";
                lColors = lColors.OrderBy(Button => Button.TabIndex).ToList();
                foreach(Button b in lColors)
                {
                    Console.WriteLine(b.Name);
                    if(b != button57)
                    b.Enabled = false;
                }

                foreach (NumericUpDown n in numValues)
                {
                    n.Enabled = false;
                }

            }
            else if(button57.Text == "Stop Jukebox")
            {
                start = false;
                player.controls.stop();
                player.URL = "";
                mMusic = false;
                button57.Text = "Start Jukebox!";
                foreach (Button b in lColors)
                    b.Enabled = true;
                foreach (NumericUpDown n in numValues)
                    n.Enabled = true;
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

         
            foreach (NumericUpDown n in numValues)
            {
                if (n.Tag != null && int.Parse(n.Tag.ToString()) >= 100)
                {
                    times[int.Parse(n.Tag.ToString()) - 100] = (float)n.Value;               
                }
                if (n.Tag != null && int.Parse(n.Tag.ToString()) < 100)
                    volumes[int.Parse(n.Tag.ToString())] = (int)n.Value;
            }

            Console.WriteLine(checkBox1.Checked);


            foreach (CheckBox n in timeChecks)
            {
                if (n.Tag != null)
                {
                    checks[int.Parse(n.Tag.ToString())] = n.Checked;
                }
            }

            Console.WriteLine(checks[0]);

            Properties.Settings.Default.volumes = volumes;
            Properties.Settings.Default.times = times;
            Properties.Settings.Default.checkboxes = checks;
            Properties.Settings.Default.files = files;

            Console.WriteLine(Properties.Settings.Default.checkboxes[0]);

            for (int i = 0; i < Properties.Settings.Default.volumes.Length; i++)
                Console.WriteLine(Properties.Settings.Default.volumes[i]);

            Properties.Settings.Default.firstsave = true;
           
            Properties.Settings.Default.Volume27 = Convert.ToInt32(numericUpDown28.Value);
            Properties.Settings.Default.Volume28 = Convert.ToInt32(numericUpDown27.Value);
          
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

        private void button114_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label115.Text = "Page 2";


            }
            if (radioButton3.Checked)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                label115.Text = "Page 3";

            }
        }

        private void button115_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            label115.Text = "Page 1";
        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown83_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitch.tv/avoidingthepuddle");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=9ME9RHUTYSFJY&currency_code=USD&source=url");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/user/danhern");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/LoveLiveisinBBTAG/Tekken-Jukebox-Dark-Resurrection/releases");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                numericUpDown84.Enabled = true;
            else if (!checkBox1.Checked)
                numericUpDown84.Enabled = false;               
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                numericUpDown83.Enabled = true;
            else if (!checkBox2.Checked)
                numericUpDown83.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                numericUpDown82.Enabled = true;
            else if (!checkBox3.Checked)
                numericUpDown82.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                numericUpDown81.Enabled = true;
            else if (!checkBox4.Checked)
                numericUpDown81.Enabled = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                numericUpDown80.Enabled = true;
            else if (!checkBox5.Checked)
                numericUpDown80.Enabled = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                numericUpDown79.Enabled = true;
            else if (!checkBox6.Checked)
                numericUpDown79.Enabled = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
                numericUpDown78.Enabled = true;
            else if (!checkBox7.Checked)
                numericUpDown78.Enabled = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
                numericUpDown77.Enabled = true;
            else if (!checkBox8.Checked)
                numericUpDown77.Enabled = false;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
                numericUpDown76.Enabled = true;
            else if (!checkBox9.Checked)
                numericUpDown76.Enabled = false;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
                numericUpDown75.Enabled = true;
            else if (!checkBox10.Checked)
                numericUpDown75.Enabled = false;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
                numericUpDown74.Enabled = true;
            else if (!checkBox11.Checked)
                numericUpDown74.Enabled = false;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
                numericUpDown73.Enabled = true;
            else if (!checkBox12.Checked)
                numericUpDown73.Enabled = false;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
                numericUpDown72.Enabled = true;
            else if (!checkBox13.Checked)
                numericUpDown72.Enabled = false;
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked)
                numericUpDown71.Enabled = true;
            else if (!checkBox28.Checked)
                numericUpDown71.Enabled = false;
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked)
                numericUpDown70.Enabled = true;
            else if (!checkBox27.Checked)
                numericUpDown70.Enabled = false;
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked)
                numericUpDown69.Enabled = true;
            else if (!checkBox26.Checked)
                numericUpDown69.Enabled = false;
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked)
                numericUpDown68.Enabled = true;
            else if (!checkBox25.Checked)
                numericUpDown68.Enabled = false;
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
                numericUpDown67.Enabled = true;
            else if (!checkBox24.Checked)
                numericUpDown67.Enabled = false;
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
                numericUpDown66.Enabled = true;
            else if (!checkBox23.Checked)
                numericUpDown66.Enabled = false;
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
                numericUpDown65.Enabled = true;
            else if (!checkBox22.Checked)
                numericUpDown65.Enabled = false;
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
                numericUpDown64.Enabled = true;
            else if (!checkBox22.Checked)
                numericUpDown64.Enabled = false;
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
                numericUpDown63.Enabled = true;
            else if (!checkBox20.Checked)
                numericUpDown63.Enabled = false;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
                numericUpDown62.Enabled = true;
            else if (!checkBox19.Checked)
                numericUpDown62.Enabled = false;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
                numericUpDown61.Enabled = true;
            else if (!checkBox18.Checked)
                numericUpDown61.Enabled = false;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
                numericUpDown60.Enabled = true;
            else if (!checkBox17.Checked)
                numericUpDown60.Enabled = false;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
                numericUpDown59.Enabled = true;
            else if (!checkBox13.Checked)
                numericUpDown59.Enabled = false;
        }

        private void numericUpDown84_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
