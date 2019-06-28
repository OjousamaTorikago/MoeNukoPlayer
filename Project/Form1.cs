using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MoeNukoStudio {
    public partial class Form1 : Form {
        string filePathName;
        private System.Media.SoundPlayer player = null;
        const string V = @"C:\Users\170586\Desktop\unyahoi\1_人間ちゃん\";
        string[] files = Directory.GetFiles(V, "*", SearchOption.AllDirectories);

        public Form1()
        {
            InitializeComponent();
            KeyPreview = !KeyPreview;
            getFileList();

        }

        // 同時再生できるクールなプレイヤー
        private void WMPlaySound(string wavFile)
        {
            WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
            mediaPlayer.URL = wavFile;
            mediaPlayer.controls.play();
        }

        //WAVEファイルを再生する
        private void PlaySound(string waveFile)
        {
            if (player != null) StopSound(); //再生されているときは止める
            player = new System.Media.SoundPlayer(waveFile); //読み込む
            player.Play(); //非同期再生する

            //player.PlayLooping(); //次のようにすると、ループ再生される
            //player.PlaySync();    //次のようにすると、最後まで再生し終えるまで待機する
        }

        //再生されている音を止める
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        private void fm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Q)
            {

                WMPlaySound(filePathName);
            }
        }

        private void getFileList()
        {

            string[] fname = new string[files.Count()];
            int i = 0;
            foreach(string f in files)
            {
                fname[i] = Path.GetFileName(f);
                i++;
            }
            listBox1.Items.AddRange(fname);
        }

        private void lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            label.Text = listBox1.Text + "をQキーに選択しました。";
            filePathName = V + listBox1.Text;
        }

        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) return;
            
            e.SuppressKeyPress = true;
            
        }
    }
}
