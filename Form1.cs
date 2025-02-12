using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private double playtime;
        private string status;
        private int FocusedRow;
        private int FocusedColumn;
        string time;
        private int lineNum;
        private string videoPath, videoPathOld;
        private bool TextMode;
        private string Mode;
        private Form2 form2;
        public string backKey, nextKey, stopKey, stampKey;

        public double seekValue, rewindStartTime;
        private bool OneLine;
        private bool fileIsMusic;
        private int listLineNum;
        private history history;
      //  private int index;
        private Deley Deley;
        private string listviewAction;
        private bool close;

 
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Mode = "normal";　//開始→終了→終了

            //言語の読み込み
            Language();

            //初期化
            ResetAll(videoPath);

            //キーを読み取る
            loadKeys();
        }

        /// <summary>
        /// 再生時間を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {

            //再生時間を表示
            label1.Text = VideoPosition(AxVLCPlugin21.input.time);

        }



        /// <summary>
        /// ミリ秒→00:00:00.000に変換
        /// </summary>
        /// <param name="ms">ミリ秒</param>
        /// <returns>変換された00:00:00.000</returns>
        private string  VideoPosition(double ms)
        {
            
            if (ms < 0)
            {
                playtime = 0;
            }
            else
            {
                playtime = (ms / 1000);
            }

            if(playtime>= 359999)
            {
                time = string.Format("{0:00:00:00.000}", 0);
            }

            else if (playtime >= 3600)
            {
                int playtime1 = ((int)Math.Truncate(playtime / 3600));
                int playtime2 = (int)Math.Truncate((playtime % 3600)/60);
                double playtime3 = ((playtime % 3600) % 60);

                time = string.Format("{0:00}", playtime1) + ":" + string.Format("{0:00}", playtime2) + ":" + string.Format("{0:00.000}", playtime3);


            }
            else if (playtime >= 60)
            {
                int playtime2 = (int)Math.Truncate(playtime / 60);
                double playtime3 = (playtime % 60); ;

                time = string.Format("{0:00:00}", playtime2) + ":" + string.Format("{0:00.000}", playtime3);
            }
            else
            {
                //MessageBox.Show(playtime.ToString());
                time = string.Format("{0:00:00:00.000}", playtime);
            }
            return time;
        }

   

        /// <summary>
        /// 00:00:00.000→秒に変換
        /// </summary>
        /// <param name="text">変換する文字</param>
        /// <returns></returns>
        private double  VideoPositionToSec(string text)
        {
            double HH, MM, SS, MS, result;

            if (Regex.IsMatch(text, @"[\d\d:]+\d\d[.][\d]{3}"))
            {
                HH = Convert.ToInt32(text.Substring(0, 2));
                MM = Convert.ToInt32(text.Substring(3, 2));
                SS = Convert.ToInt32(text.Substring(6, 2));
                MS = Convert.ToInt32(text.Substring(9, 3));

                result = (HH * 3600 + MM * 60 + SS + (MS/1000));
            }
            else
            {
                result = 0;
            }
            return result;
        }




        /// <summary>
        /// 動画を読み込む
        /// </summary>
        /// <param name="videoPath">動画のパス</param>
        private void load(string videoPath)
        {
            playtime = AxVLCPlugin21.input.time;
            AxVLCPlugin21.playlist.items.clear();
            AxVLCPlugin21.playlist.add("file:///" + videoPath);
            
            AxVLCPlugin21.playlist.next();
        // AxVLCPlugin21.playlist.play();
        
            //途中から再生する
            AxVLCPlugin21.input.time = playtime;

            if (status == "Pause")
            {
                AxVLCPlugin21.playlist.pause();
                //再生時間を表示
               
            }

        }








        /// <summary>
        /// リストビューの値から字幕を生成する
        /// </summary>
        /// <returns></returns>
        private void MakeSubtitle()
        {
            int SubtitleNum = 1;//字幕の番号
            SubtitletextBox.WordWrap = false;//改行しない
            //リストからテキストボックスに入れる
            SubtitletextBox.Text = "";
            foreach (ListViewItem b in listView1.Items)
            {
                //追加
                SubtitletextBox.AppendText(SubtitleNum + "\r\n");
                SubtitletextBox.AppendText(b.SubItems[(int)column.StartTime].Text + "  --> " + b.SubItems[(int)column.EndTime].Text + "\r\n");
                SubtitletextBox.AppendText(b.SubItems[(int)column.Subtitle].Text.Trim()+ "\r\n\r\n");

                SubtitleNum++;
            }
            SubtitletextBox.WordWrap = true;//改行する

        }




        /// <summary>
        /// 文字が何個あるか
        /// </summary>
        /// <param name="target">探す文字</param>
        /// <param name="strArray">探す場所</param>
        /// <returns></returns>
        public static int CountString(string target, string str)
        {

            MatchCollection matchCollection= Regex.Matches(target, str);
            return matchCollection.Count;
        }





        //アラートがならないようにする
        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        //キーを押したときの処理
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            //リストビューに時間を書き込む
            //キーが押されたときの処理
            ListViewWriter(e, Mode);


        }

        //リストビューに時間を書き込む
        /// <summary>
        /// キーが押されるたびにフォーカスを下にずらしながら開始時間、
        /// 終了時間に動画の再生時間を書き込む
        /// </summary>
        /// <param name="e"></param>
        /// <param name="Mode"></param>
        private void ListViewWriter(KeyEventArgs e, string Mode)
        {
            //スペースキー(デフォルトでは)
            if (e.KeyCode.ToString() == stampKey)
            {
                close = false;//フォームの終了を拒否

                listLineNum = listView1.Items.Count;

                //リストビューに値があるとき
                if (listLineNum - 1 >= FocusedRow && listView1.SelectedItems.Count > 0)
                {
                    //変更前を記録
                    history.AddUndo(listView1.Items[FocusedRow].SubItems[(int)column.Subtitle].Text, "Writing", FocusedRow,
                                    listView1.Items[FocusedRow].SubItems[(int)column.StartTime].Text, listView1.Items[FocusedRow].SubItems[(int)column.EndTime].Text);


                    //開始時間の列のとき
                    if (FocusedColumn == (int)column.StartTime)
                    {


                        //動画の時間を入力
                        listView1.Items[FocusedRow].SubItems[FocusedColumn].Text = VideoPosition(AxVLCPlugin21.input.time - rewindStartTime);
                    }
                    else
                    {
                        //終了時間にフォーカスがある時
                        //動画の時間を入力
                        listView1.Items[FocusedRow].SubItems[FocusedColumn].Text = VideoPosition(AxVLCPlugin21.input.time);

                    }
                    //変更後を記録
                    history.AddRedo(listView1.Items[FocusedRow].SubItems[(int)column.Subtitle].Text, "Writing", FocusedRow,
                                    listView1.Items[FocusedRow].SubItems[(int)column.StartTime].Text, listView1.Items[FocusedRow].SubItems[(int)column.EndTime].Text);

                }
                //最後の行で且つ終了時間にフォーカスがあるとき
                if (listLineNum - 1 <= FocusedRow && FocusedColumn == (int)column.EndTime && listView1.Items[listLineNum - 1].Selected == true)
                {
                    if (!ListviewCheck())//エラーがない時
                    {
                        listView1.Items[FocusedRow].Selected = false;

                        //テキストボックスに字幕を書き込む
                        MakeSubtitle();

                        //字幕を動画のある場所に保存する
                        SaveSubtitle(videoPath, ".vtt");

                        //音楽以外なら再読み込み
                        if (!fileIsMusic)
                        {
                            //動画を再読み込み
                            load(videoPath);
                        }

                        listView1.Focus();
                    }

                }


                else
                {
                    //アドバンスモードのとき
                    //開始→終了→開始→
                    if (Mode == "advance")
                    {

                        //次のフィールドを指定する

                        //開始時間にフォーカスがあるとき
                        if (FocusedColumn == (int)column.StartTime)
                        {
                            //列を指定

                            //終了時間
                            FocusedColumn = (int)column.EndTime;
                        }
                        //終了時間にフォーカスがあるとき
                        else
                        {
                            //列を指定

                            //開始時間
                            FocusedColumn = (int)column.StartTime;

                            FocusedRow += 1;
                            //次の行が存在するときのみ
                            if (listLineNum > FocusedRow)
                            {
                                //フォーカスを下にずらす
                                listView1.Items[FocusedRow - 1].Selected = false;
                                listView1.Items[FocusedRow].Selected = true;

                                //リストビューをスクロール
                                listView1.EnsureVisible(FocusedRow);
                                //フォーカスを当てる
                                //listView1.Items[FocusedRow].Focused = true;

                            }
                        }
                    }
                    //ノーマルモード
                    //開始→終了→終了→
                    else
                    {
                        //次のフィールドを指定する

                        //最初の行のときで且つ開始の列にフォーカスがあるとき
                        if (FocusedColumn == (int)column.StartTime)
                        {
                            //列を指定

                            //終了時間
                            FocusedColumn = (int)column.EndTime;
                        }

                        //終了時間にフォーカスがあるとき
                        else
                        {
                            FocusedRow += 1;

                            //次の行が存在するときのみ
                            if (listLineNum > FocusedRow)
                            {
                                //リストビューをスクロール
                                listView1.EnsureVisible(FocusedRow);
                                //フォーカスを下にずらす
                                listView1.Items[FocusedRow - 1].Selected = false;
                                listView1.Items[FocusedRow].Selected = true;


                                //変更前を記録
                                history.AddUndo(listView1.Items[FocusedRow].SubItems[(int)column.Subtitle].Text, "Writing", FocusedRow,
                                                listView1.Items[FocusedRow].SubItems[(int)column.StartTime].Text, listView1.Items[FocusedRow].SubItems[(int)column.EndTime].Text);


                                //開始時間を自動で入力する

                                //動画の時間を入力
                                listView1.Items[FocusedRow].SubItems[(int)column.StartTime].Text = VideoPosition(AxVLCPlugin21.input.time - rewindStartTime);
                                //変更履歴を残す

                                //変更後を記録
                                history.AddRedo(listView1.Items[FocusedRow].SubItems[(int)column.Subtitle].Text, "Writing", FocusedRow,
                                                listView1.Items[FocusedRow].SubItems[(int)column.StartTime].Text, listView1.Items[FocusedRow].SubItems[(int)column.EndTime].Text);
                            }
                        }
                    }

                }

            }
            else if (e.KeyCode == Keys.Down && listLineNum - 1 > FocusedRow)//上矢印キーの押下時
            {
                listView1.Items[FocusedRow + 1].Focused = false;
                listView1.Items[FocusedRow].Focused = true;
                listView1.Items[FocusedRow + 1].Selected = false;
                listView1.Items[FocusedRow].Selected = true;
                FocusedColumn = (int)column.StartTime;
            }
            else if (e.KeyCode == Keys.Up && FocusedRow > 0 && listLineNum - 1 > FocusedRow) //下矢印キーの押下時
            {

                listView1.Items[FocusedRow - 1].Focused = false;
                listView1.Items[FocusedRow].Focused = true;
                listView1.Items[FocusedRow - 1].Selected = false;
                listView1.Items[FocusedRow].Selected = true;
                FocusedColumn = (int)column.StartTime;
            }

            string key = e.KeyCode.ToString();

            //シーク
            if (key == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (key == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }

            //再生
            else if (key == stopKey)
            {
                VideoPlay();
            }

        }

        /// <summary>
        /// 動画の再生/停止
        /// </summary>
        private void VideoPlay()
        {

            if (status == "Playing")
            {
                AxVLCPlugin21.playlist.pause();
            }
            else
            {
                AxVLCPlugin21.playlist.play();
            }
        }





        private void ListClear(ListView listView)
        {
            listView.Items.Clear();
        }



        private void AxVLCPlugin21_MediaPlayerPaused_1(object sender, EventArgs e)
        {
            status = "Pause";

        }


        private void AxVLCPlugin21_MediaPlayerPlaying_1(object sender, EventArgs e)
        {
            status = "Playing";
        }



      


        /// <summary>
        /// 字幕を保存する
        /// </summary>
        /// <param name="videoPath">保存するパス</param>
        /// <param name="ext">字幕の拡張子</param>
        private void SaveSubtitle(string SubPath, string ext)
        {
            string subtitlePath;
            if (!string.IsNullOrEmpty(SubPath))
            {
                try
                {
                    subtitlePath = Path.GetDirectoryName(SubPath) + "\\" + Path.GetFileNameWithoutExtension(SubPath) + ext;
                    using (StreamWriter writer = new StreamWriter(subtitlePath, false, Encoding.GetEncoding("UTF-8")))
                    {
                        if (ext == ".vtt")
                        {
                            writer.Write("WEBVTT" + "\r\n\r\n" + SubtitletextBox.Text);
                        }
                        else
                        {
                            writer.Write(SubtitletextBox.Text);
                        }

                    }

                }
                catch (DriveNotFoundException)
                {

                    MessageBox.Show(Properties.Resources.failed,
                    Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            string key = e.KeyCode.ToString();

            //シーク
            if (key == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (key == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }
        }



        /// <summary>
        /// ファイル→動画を開くを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(CheckSave())//開く前に字幕の保存がされているかの確認
            {
                OpenFile();


                if (Path.GetExtension(videoPath) == ".mp3" || Path.GetExtension(videoPath) == ".wav" || Path.GetExtension(videoPath) == ".flac" || Path.GetExtension(videoPath) == "aac")
                {
                    fileIsMusic = true;
                }
                else
                {
                    fileIsMusic = false;
                }
            }
        }




        /// <summary>
        /// 動画を開く
        /// </summary>
        private void OpenFile()
        {
            openFileDialog1.Filter = Properties.Resources.movie +" | *.avi; *.mp4; *.flv; *.mov; *.webm; *.wmv; *.mkv; *.mpg; *.mpeg; *.m4a| "+Properties.Resources.music +"| *.wav; *.mp3; *.aac; *.wave; *.flac| "+Properties.Resources.all+" | *.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                videoPathOld = videoPath;
                videoPath = openFileDialog1.FileName;

                

                ResetAll(videoPath);

                //有効化
                listView1.Enabled = true;
                SubtitletextBox.Enabled = true;

            }
        }
        

        /// <summary>
        /// 変更した値などを初期化する
        /// </summary>
        /// <param name="videoPath"></param>
        private void ResetAll(string videoPath)
        {
            history = new history(listView1,FocusedRow);
            //動画の状態
            status = "Pause";




            if (CheckOverWrite())//上書きするかの確認
            {
                if (videoPath != null)
                {
                    //動画を読み込む
                    load(videoPath);
                }

                close = true;//フォームの終了を許可する

                //一時停止
                AxVLCPlugin21.playlist.pause();
                //最初から再生
                AxVLCPlugin21.input.time = 0;

                //文字をリストビューに追加を許可
                TextMode = true;


                ListClear(listView1);
                TextMode = true;
                SubtitletextBox.Text = null;
                InputSubtitleButton.Text = "↓";


                //字幕を動画のある場所に保存する
                SaveSubtitle(videoPath, ".vtt");
            }
            else
            {
                if (!string.IsNullOrEmpty(videoPath))
                {
                    this.videoPath = videoPathOld;
                }
            }



            


            

        }

        private void ノーマルToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mode = "advance";
            開始終了終了ToolStripMenuItem.Checked = false;
            ノーマルToolStripMenuItem.Checked = true;

            //MessageBox.Show(AxVLCPlugin21.subtitle.ToString());
        }

        private void 開始終了終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mode = "normal";
            開始終了終了ToolStripMenuItem.Checked = true;
            ノーマルToolStripMenuItem.Checked = false;
        }



        /// <summary>
        /// vlcの画面を押されたら動画を再生する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxVLCPlugin21_ClickEvent_1(object sender, EventArgs e)
        {

            VideoPlay();
        }


        /// <summary>
        /// 動画の再生速度を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            double num = trackBar1.Value;

            //動画の再生速度
            double speed;
            speed = num * 0.1;
            
            //再生速度を変える
            AxVLCPlugin21.input.rate = speed;
            //ラベルに再生速度を書き込む
            videoSpeedLabel.Text = "x" + speed.ToString("0.0");
        }




        /// <summary>
        /// フォームをクリックしてもリストビューのフォーカスが消えないようにする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.Focus();
        }


        private void 上に追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertListview(0);//字幕を上に追加
        }

        private void 下に追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertListview(1);//字幕を下に追加
        }

        /// <summary>
        /// 字幕を開き、それをリストビューに変換する
        /// </summary>

        private void SubtitleToListview()
        {
            ListViewItem lvi;
            Match match;
            var ListTime = new List<List<string>>();
            int firstPos;
            string Time,Path;
            List<string> ListText = new List<string>();
            int CountSub, CountTime;
            CountSub = CountTime = 0;
            string subtext, line,timetext;
            subtext = "";
            history = new history(listView1, FocusedRow);//履歴を初期化

            openFileDialog1.Filter= Properties.Resources.subtitlefile+"|*.vtt;*.srt|"+Properties.Resources.all+"|*.*";
            //ファイルを選択する
            //OKだったら1行ずつ書き込み
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SubtitletextBox.Enabled = false;
                listView1.Enabled = false;
                InputSubtitleButton.Enabled = false;

                Path = openFileDialog1.FileName;
                //リストビューにテキストを追加できないようにする
                TextMode = false;
                InputSubtitleButton.Text = "↑";

                //リストビューの値を消す
                listView1.Items.Clear();
                try
                {

                    subtext = "";
                    using (StreamReader stream = new StreamReader(
                    Path, Encoding.GetEncoding("UTF-8")))
                    {
                        while ((line = stream.ReadLine()) != null)
                        {
                            subtext = line.Trim() + "\r\n";//テキスト
                            timetext = subtext; //時間

                            //  MessageBox.Show(Regex.IsMatch(subtext, @"(\d\d:)+\d\d[.][\d]{3}").ToString());
                            //時間を探す
                            if (Regex.IsMatch(timetext, @"(\d\d:)+\d\d[.,][\d]{3}"))
                            {
                                
                                ListTime.Add(new List<string>());
                                //開始と終了時間をリストに入れる
                                for (int i = 0; i < 2; i++)
                                {                               //カンマ→ピリオドに変更
                                    //必要があれば時間の書式を 「00:00:00,000」から「00:00:00.000]に変更する
                                    if (Regex.IsMatch(timetext, @"(\d\d:)+\d\d[,][\d]{3}"))
                                    {
                                        match = Regex.Match(timetext, @"(\d\d:)\d\d[,][\d]{3}");
                                        timetext = timetext.Substring(0, match.Index + 5) + "." + timetext.Substring(match.Index + 6);
                                    }


                                    match = Regex.Match(timetext, @"(\d\d:)+\d\d[.][\d]{3}");
                                   
                                    //MM:SS.ms のとき
                                    if (match.Length == 9)
                                    {
                                        Time = "00:" + match.Value;
                                    }
                                    else
                                    {
                                        Time = match.Value;
                                    }
                                    
                                    //開始位置
                                    firstPos = match.Index;
                                    ListTime[CountTime].Add(Time); //開始と終了時刻を入れる

                                    timetext = timetext.Substring(firstPos+match.Length);

                                    
                                }
                                CountTime++;
                            }
                            //テキストの時 //webvttは除外
                            else if (!(subtext.Equals("webvtt\r\n", StringComparison.OrdinalIgnoreCase)&&(CountSub+CountTime)==0)
                                    &&!int.TryParse(subtext,out int result)
                                    &&subtext != "\r\n")
                            {

                                CountSub++;
                                if (CountTime == CountSub)//一行の時
                                {

                                    //リストからリストビューに入れる

                                    lvi = listView1.Items.Add(subtext);

                                    lvi.SubItems.Add(ListTime[CountTime-1][0]);
                                    lvi.SubItems.Add(ListTime[CountTime-1][1]);

                                    //変更履歴を残す
                                    Addhistory("", "Add", CountTime - 1);
                               
                                        
                                }
                                else //２行目以降
                                {
                                    if (listView1.Items.Count >= CountTime)
                                    {
                                        //テキストだけ加筆
                                        listView1.Items[CountTime - 1].SubItems[0].Text += subtext;
                                        
                                    }
                                    CountSub = CountTime;

                                }  
                            }             
                        }                   
                    }
                }
                catch
                {
                    MessageBox.Show(Properties.Resources.failed2,
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               finally
                {
                    listLineNum = listView1.Items.Count;
                    SubtitletextBox.Enabled = true;
                    listView1.Enabled = true;
                    InputSubtitleButton.Enabled = true;
                }

                //リストビューから字幕
                ListviewToSubtitle();
            }
          
        }

        /// <summary>
        /// 
        ///矢印ボタンを押したときの処理。<br></br>
        /// テキストボックスからリストビューに書き込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void InputSubtitleButton_Click(object sender, EventArgs e)
        {
            try
            {//連打防止
                //this.Enabled=false;
                InputSubtitleButton.Enabled = false;
                SubtitletextBox.Enabled = false;
                listView1.Enabled = false;



                //何も記述されてないとき
                if (SubtitletextBox.Text == "" && TextMode==true)
                {
                        MessageBox.Show(Properties.Resources.textboxerror,
                        Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InputSubtitleButton.Enabled = true;
                }

                //文字をリストビューに入れる
                else if (TextMode == true)
                {
                    listView1.BeginUpdate();//描画を止める


                    //自動で改行するにチェックを入れたときの処理
                    if (OneLine == true)
                    {
                        //２行以上の改行があったら一行だけ空くようにする
                        while (SubtitletextBox.Text.Contains("\r\n\r\n"))
                        {

                            SubtitletextBox.Text = SubtitletextBox.Text.Replace("\r\n\r\n", "\r\n");
                        }

                        SubtitletextBox.Text = SubtitletextBox.Text.Replace("\r\n", "\r\n\r\n");
                    }
                    else
                    {
                        //２行以上空いていたら一行だけ空くようにする
                        while (SubtitletextBox.Text.Contains("\r\n\r\n\r\n"))
                        {

                            SubtitletextBox.Text = SubtitletextBox.Text.Replace("\r\n\r\n\r\n", "\r\n\r\n");
                        }
                    }


                    //何行か調べる
                    lineNum = CountString(SubtitletextBox.Text, @"\r\n\r\n");

                    //リストビューのアイテムを全部消す
                    ListClear(listView1);

                    int endPos = 0;
                    int firstPos = 0;
                    string Lyrics;
                    //テキストボックスの文字を一行ずつ読み取り、
                    //前後の空白を除去する
                    string textLines = TrimTextBox(SubtitletextBox);

                    ListViewItem lvi;

                    int count=0;
                    //改行した回数だけ通る
                    for (int i = 0; i < lineNum; i++)
                    {
                        //改行コードが何番目に来るか
                        string substr = textLines.Substring(firstPos);
                        endPos = substr.IndexOf("\r\n\r\n");
                        Lyrics = textLines.Substring(firstPos, endPos).Trim();

                        //リストビューに追加
                        if (Lyrics != "")
                        {
                            lvi = listView1.Items.Add(Lyrics);
                            lvi.SubItems.Add("00:00:00.000");
                            lvi.SubItems.Add("00:00:00.000");

                            //変更履歴を残す
                            Addhistory("", "Add", count);
                            count++;
                        }
                        firstPos += endPos + 4;//次の行が何文字目から始まるか
                    }
                    //一番最後の行
                    Lyrics = textLines.Substring(firstPos).Trim();
                    if (Lyrics != "")
                    {
                        lvi = listView1.Items.Add(Lyrics);

                        lvi.SubItems.Add("00:00:00.000");
                        lvi.SubItems.Add("00:00:00.000");

                        //変更履歴を残す
                        Addhistory("", "Add", count);                   
                    }

                    //リストビューにテキストを追加できないようにする
                    TextMode = false;
                    InputSubtitleButton.Text = "↑";

                    listLineNum = listView1.Items.Count;

                }
                //リストビューから字幕に変換する
                else
                {
                    ListviewCheckTime();//リストビューのチェック
                    ListviewToSubtitle();

                        
                }

            }
            catch
            {
                MessageBox.Show(Properties.Resources.failed3,
                Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //処理落ち防止
                await Task.Delay(500);


                if (!string.IsNullOrEmpty(videoPath) )
                {
                    SubtitletextBox.Enabled = true;
                    listView1.Enabled = true;

                    InputSubtitleButton.Enabled = true;
                }

                //this.Enabled = true;

                listView1.EndUpdate();//描画
            }
        }
        
        /// <summary>
        /// テキストボックスの不要な改行、空白を削除するため一行ずつ読み取る
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>不要な文字が除去されたテキスト</returns>
        private string TrimTextBox(TextBox textBox)
        {
            int CountLines = textBox.Lines.Length;
            string textLines = "";
            for (int i = 0; i < CountLines; i++)
            {
                textLines += textBox.Lines[i].Trim() + "\r\n";
            }

            return textLines;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                FocusedRow = listView1.SelectedItems[0].Index;
            }
            //00:00:00.000
            FocusedColumn = (int)column.StartTime;


            if (e.Button == MouseButtons.Left)
            {
                //字幕を編集できないようにする
                listView1.LabelEdit = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                //一時停止
                AxVLCPlugin21.playlist.pause();
            }


            Task.Delay(1000);
        }

        //字幕を保存
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ListviewCheck()) //エラーが無い時
                {
                    saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(videoPath);
                    saveFileDialog1.Filter = "srtファイル(*.srt)|*.srt|WebVTTファイル(*.vtt)|*.vtt";

                    //OKボタンを押したとき
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //保存するファイルの拡張子
                        string ext = Path.GetExtension(saveFileDialog1.FileName);

                        //テキストボックスに字幕を書き込む
                        MakeSubtitle();

                        if (ext == ".srt")
                        {
                            SaveSubtitle(saveFileDialog1.FileName, ".srt");

                        }
                        else
                        {
                            SaveSubtitle(saveFileDialog1.FileName, ".vtt");
                        }

                        close = true;//フォームの終了を許可
                    }
                }


            }
            catch
            {
                MessageBox.Show(Properties.Resources.error,
   Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //リストビューに値があるときのみ
            if (listView1.SelectedItems.Count > 0 && listView1.Items.Count> FocusedRow)
            {
                //変更履歴を残す
                Addhistory("", "Delete", FocusedRow);

                //選択している字幕を削除する
                listView1.Items.Remove(listView1.Items[FocusedRow]);

                //リストビューの行数をカウント
                listLineNum = listView1.Items.Count;

                close = false;//フォームの終了を拒否
            }
        }

        private void 編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //字幕を編集可能にする
            listView1.LabelEdit = true;

            listviewAction = "Edit";

            //字幕を編集する
            if (listView1.SelectedItems.Count>0 && listView1.Items.Count > FocusedRow) listView1.FocusedItem.BeginEdit();
        }



        private void 設定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();

            //キーを送る
            form2.stampKey = Properties.Settings.Default.stampKey;
            form2.backKey = Properties.Settings.Default.backKey;
            form2.stopKey = Properties.Settings.Default.stopKey;
            form2.nextKey = Properties.Settings.Default.nextKey;
            form2.seekValue = Properties.Settings.Default.seekValue;
            form2.rewindStartTime = Properties.Settings.Default.RewindStartTime;
            form2.OneLine = Properties.Settings.Default.OneLine;
            form2.ShowDialog();

            //キーを読み取る
            loadKeys();


        }

        private void 字幕を開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //動画が読み込まれていたら開く
            if (!string.IsNullOrEmpty(videoPath))
            {
                if (!CheckSave())//保存しなくて良いかの確認
                {
                    return;//ここで抜ける
                }

                //字幕からリストビューに変換をし、リストビューから字幕に変換する
                SubtitleToListview();

            }
            else
            {
                MessageBox.Show(Properties.Resources.videofailed,
                Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// リストビューから字幕を生成する
        /// </summary>
        private void ListviewToSubtitle()
        {
            if (!ListviewCheck()&&listView1.Items.Count>0)                //エラーが無い時
            {
                //テキストボックスに字幕を書き込む
                MakeSubtitle();

                //字幕を動画のある場所に保存する
                SaveSubtitle(videoPath, ".vtt");

                //音楽以外なら再読み込み
                if (!fileIsMusic)
                {
                    //動画を再読み込み
                    load(videoPath);
                }


                listView1.Focus();
            }
        }



        /// <summary>
        /// リストのラベルが編集されたら履歴を残す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

            if (listviewAction == "Add")
            {
                //変更履歴を残す
                Addhistory("", "Add", FocusedRow, e.Label);
            }
            //編集の時
            else
            {
                Addhistory("", "Edit", FocusedRow, e.Label);
            }


            close = false;//フォームの終了を拒否
        }



        private void やり直すToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Redo();
            close = false;//フォームの終了を拒否
        }

        private void 元に戻すToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.Undo();
            close = false;//フォームの終了を拒否
        }

        /// <summary>
        /// 過去に保存したキーと同じキーを使えるようにする
        /// </summary>
        private void loadKeys()
        {
            stampKey = Properties.Settings.Default.stampKey;
            backKey = Properties.Settings.Default.backKey;
            stopKey = Properties.Settings.Default.stopKey;
            nextKey = Properties.Settings.Default.nextKey;
            seekValue = Properties.Settings.Default.seekValue;
            rewindStartTime = Properties.Settings.Default.RewindStartTime;
            OneLine = Properties.Settings.Default.OneLine;


            label2Text();
        }
        /// <summary>
        /// 一行ずつ読み込むの有効か、無効かを表示
        /// </summary>
        private void label2Text()
        {
            string Mode;
            if (OneLine)
            {
                Mode = Properties.Resources.OneLineModeEnable;
            }
            else
            {
                Mode = Properties.Resources.OneLineModeDisEnable;
            }
            label2.Text = Properties.Resources.load + " : " + Mode;
        }

        private void アラビア語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            //言語の読み込み
            Language();
        }
        private void 英語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            //言語の読み込み
            Language();
        }
        private void ドイツ語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
            //言語の読み込み
            Language();
        }

        private void スペイン語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
            //言語の読み込み
            Language();
        }

        private void フランス語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            //言語の読み込み
            Language();
        }

        private void 日本語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");
            //言語の読み込み
            Language();
        }

        private void ロシア語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            //言語の読み込み
            Language();
        }

        private void 中国語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh");
            //言語の読み込み
            Language();
        }
        /// <summary>
        /// リストの項目をダブルクリックしたらその行から再生する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listLineNum = listView1.Items.Count;
            if (listView1.SelectedItems.Count >0 && listLineNum> listView1.SelectedItems[0].Index)
            {

                FocusedRow = listView1.SelectedItems[0].Index;
                //00:00:00.000
                FocusedColumn = (int)column.StartTime;

                if (e.Button == MouseButtons.Left)
                {
                    //開始時間にシークする
                    AxVLCPlugin21.input.time = VideoPositionToSec(listView1.SelectedItems[0].SubItems[(int)column.StartTime].Text) * 1000;


                    //再生
                    AxVLCPlugin21.playlist.play();

                    //字幕を編集できないようにする
                    listView1.LabelEdit = false;
                }
            }


            Task.Delay(1000);
        }

        private void 字幕の遅延ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deley = new Deley();

            Deley.ShowDialog();

            double DelayEnd = Convert.ToDouble(Deley.DelayEnd) * 1000;
            double DelayStart = Convert.ToDouble(Deley.DelayStart) * 1000;

            listLineNum = listView1.Items.Count;

            for (int i = 0; i < listLineNum; i++)
            {
                listView1.Items[i].SubItems[(int)column.StartTime].Text = VideoPosition(VideoPositionToSec(listView1.Items[i].SubItems[(int)column.StartTime].Text) * 1000 + DelayStart);
                listView1.Items[i].SubItems[(int)column.EndTime].Text = VideoPosition(VideoPositionToSec(listView1.Items[i].SubItems[(int)column.EndTime].Text) * 1000 + DelayEnd);
            }
        }



        /// <summary>
        /// 字幕の挿入
        /// </summary>
        /// <param name="num">どこに挿入するか。選択している行より上なら"０"下なら"１"</param>
        private void InsertListview(int num)
        {
            ListViewItem lvi;
            int index;
            index = FocusedRow + num;
            //リストビューの行数をカウント
            listLineNum = listView1.Items.Count;
            //字幕を編集可能にする
            listView1.LabelEdit = true;

            //リストビューに値があるときのみ
            if (listView1.SelectedItems.Count > 0 && listLineNum > FocusedRow)
            {
                close = false;//フォームの終了を拒否

                lvi = listView1.Items.Insert(index, "");
                if (num == 1)//下に挿入
                {
                    lvi.SubItems.Add(VideoPosition(ListViewGetEndTimeMillisecond(FocusedRow)));
                    lvi.SubItems.Add("00:00:00.000");
                    lvi.SubItems.Add(ListViewGetEndTimeMillisecond(FocusedRow).ToString());
                    lvi.SubItems.Add("0");

                    //新しい行にフォーカスを当てる
                    listView1.Items[FocusedRow].Focused= false;
                    listView1.Items[FocusedRow+1].Focused = true;
                    listView1.Items[FocusedRow].Selected = false;
                    listView1.Items[FocusedRow + 1].Selected = true;
                }

                else //上に挿入                        
                {
                    if (FocusedRow <=1)//一番上に挿入するとき
                    {
                        lvi.SubItems.Add("00:00:00.000");
                        lvi.SubItems.Add("00:00:00.000");

                    }
                    else 
                    {
                        lvi.SubItems.Add(VideoPosition(ListViewGetEndTimeMillisecond(FocusedRow - 1)));
                        lvi.SubItems.Add("00:00:00.000");



                    }

                    //新しい行にフォーカスを当てる
                    listView1.Items[FocusedRow + 1].Focused = false;
                    listView1.Items[FocusedRow].Focused = true;
                    listView1.Items[FocusedRow + 1].Selected = false;
                    listView1.Items[FocusedRow].Selected = true;                   
                }

                //字幕を編集する
                listView1.FocusedItem.BeginEdit();
            }
            else if(listView1.Items.Count == 0)
            {              
                listView1.Items.Add("");
                listView1.Items[0].SubItems.Add("00:00:00.000");
                listView1.Items[0].SubItems.Add("00:00:00.000");
                listView1.Items[0].Selected = true;

                Addhistory("", "Add", 0, "");

                //リストビューにテキストを追加できないようにする
                TextMode = false;
                InputSubtitleButton.Text = "↑";
            }
            listviewAction = "Add";

            //リストビューの行数をカウント
            listLineNum = listView1.Items.Count;
        }
        //ヘルプの表示
        private void ヘルプHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            Help.ShowHelp(this, @"./chm/" + lang + ".chm");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                FocusedRow = listView1.SelectedItems[0].Index;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //終了する前に保存がされているかの確認
            if (!CheckSave())
            {
                e.Cancel = true;//終了しない
            }
        }



        


        /// <summary>
        /// 指定した行の終了時間をミリ秒で取得する
        /// </summary>
        /// <param name="row">何行目を取得するか</param>
        /// <returns>ミリ秒</returns>
        private double  ListViewGetEndTimeMillisecond(int row)
        {
            double time =VideoPositionToSec( listView1.Items[row].SubItems[(int)column.EndTime].Text)*1000 - rewindStartTime;


            return time; //ミリ秒
        }

        
        /// <summary>
        /// 終了時間が０だったら開始時間と同じにする
        /// </summary>
        private void ListviewCheckTime()
        {
            //リストビューの行数をカウント
            listLineNum = listView1.Items.Count;

            for (int i = 0; i < listLineNum; i++)
            {
                if (listView1.Items[i].SubItems[(int)column.EndTime].Text=="00:00:00.000")
                {
                    listView1.Items[i].SubItems[(int)column.EndTime].Text = listView1.Items[i].SubItems[(int)column.StartTime].Text;
                }
            }
        }

        /// <summary>
        /// 開始時間と終了時間が適切かを調べるエラーがあればその行にフォーカスを当てる
        /// </summary>
        /// <returns>エラーならtrue</returns>
        private bool ListviewCheck()
        {
            //リストビューの行数をカウント
            listLineNum = listView1.Items.Count;

            int index;
            int result;
            bool error = false;

            ////初期値のアイテムの下に時間が書き込まれているエラー
            result = CheckListTime(0);
            if (result > 0)
            {
                index = result;
                error = ListErrorFocus(index);
                MessageBox.Show(Properties.Resources.failed4,
Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                index = -1;
                for (int i = 0; i < listLineNum; i++)
                {
                    ///開始時間の順番がおかしいエラー
                    //ただし時間が０のときはエラーにしない
                    if (i < listLineNum - 1 && VideoPositionToSec(listView1.Items[i].SubItems[(int)column.StartTime].Text) > VideoPositionToSec(listView1.Items[i + 1].SubItems[(int)column.StartTime].Text)
                        && !(result == -2 && VideoPositionToSec(listView1.Items[i + 1].SubItems[(int)column.StartTime].Text) == 0 && VideoPositionToSec(listView1.Items[i + 1].SubItems[(int)column.EndTime].Text) == 0))
                    {
                        index = i;
                        error = ListErrorFocus(index);
                        MessageBox.Show(Properties.Resources.failed4,
                        Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    //終了時間より開始時間のほうが遅いエラー
                    else if (VideoPositionToSec(listView1.Items[i].SubItems[(int)column.StartTime].Text) > VideoPositionToSec(listView1.Items[i].SubItems[(int)column.EndTime].Text) &&
                    VideoPositionToSec(listView1.Items[i].SubItems[(int)column.EndTime].Text) != 0)
                    {
                        index = i;
                        error = ListErrorFocus(index);
                        MessageBox.Show(Properties.Resources.failed5,
                        Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            
            return error;

        }

        private bool ListErrorFocus(int index)
        {
            bool error;
            if (index > -1)   //エラーがある時
            {
                error = true;

                try
                {
                    //エラーの箇所にフォーカスを当てる
                    listView1.Items[FocusedRow].Selected = false;
                    listView1.Items[index].Selected = true;

                    //リストビューをスクロール
                    listView1.EnsureVisible(index);
                    listView1.Focus();
                }
                catch
                {

                }
            }
            else{
                error = false;
            }

            return error;
        }

        private void AxVLCPlugin21_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //再生
            if (e.KeyData.ToString() == stopKey)
            {
                VideoPlay();
            }
            //シーク
            else if (e.KeyData.ToString() == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (e.KeyData.ToString() == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }
        }

        private void InputSubtitleButton_KeyDown(object sender, KeyEventArgs e)
        {
            //再生
            if (e.KeyData.ToString() == stopKey)
            {
                VideoPlay();
            }
            //シーク
            else if (e.KeyData.ToString() == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (e.KeyData.ToString() == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            //再生
            if (e.KeyData.ToString() == stopKey)
            {
                VideoPlay();
            }
            //シーク
            else if (e.KeyData.ToString() == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (e.KeyData.ToString() == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }
        }

        private void AxVLCPlugin21_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            //再生
            if (e.KeyData.ToString() == stopKey)
            {
                VideoPlay();
            }
            //シーク
            else if (e.KeyData.ToString() == backKey)
            {
                AxVLCPlugin21.input.time -= seekValue;
            }
            else if (e.KeyData.ToString() == nextKey)
            {
                AxVLCPlugin21.input.time += seekValue;
            }
        }







        /// <summary>
        /// 履歴を追加する
        /// </summary>
        /// <param name="Undotxt">変更前の字幕</param>
        /// <param name="Action">何を実行したか</param>
        /// <param name="row">何行目か</param>
        /// <param name="Redotxt">変更後の字幕</param>
        private void Addhistory(string Undotxt,string Action,int row,string Redotxt="")
        {

            string subtitle;
            if (Redotxt == "")
            {
                subtitle = listView1.Items[row].SubItems[(int)column.Subtitle].Text;
            }
            else
            {
                subtitle = Redotxt;
            }

            if (Action == "Delete")//削除する時
            {
                //変更前を記録
                history.AddUndo(listView1.Items[row].SubItems[(int)column.Subtitle].Text, Action, row,
                                listView1.Items[row].SubItems[(int)column.StartTime].Text, listView1.Items[row].SubItems[(int)column.EndTime].Text);

                //変更後を記録
                history.AddRedo(subtitle, Action, row);

            }
            else if (Action == "Edit")
            {
                //変更前を記録
                history.AddUndo(listView1.Items[row].SubItems[(int)column.Subtitle].Text, Action, row,
                               listView1.Items[row].SubItems[(int)column.StartTime].Text, listView1.Items[row].SubItems[(int)column.EndTime].Text);


                //変更後を記録
                history.AddRedo(subtitle, Action, row,
                                listView1.Items[row].SubItems[(int)column.StartTime].Text, listView1.Items[row].SubItems[(int)column.EndTime].Text);

            }
            else
            {
                history.AddUndo(Undotxt, Action, row); ;//変更前を記録

                //変更後を記録
                history.AddRedo(subtitle, Action, row,
                                listView1.Items[row].SubItems[(int)column.StartTime].Text, listView1.Items[row].SubItems[(int)column.EndTime].Text);

            }
        }




        /// <summary>
        /// 字幕を保存されていなければメッセージを表示
        /// </summary>
        /// <returns>保存されているかどうかの結果</returns>
        private bool CheckSave()
        {
            if (close == true)
            {
                return true;
            }
            else
            {
                //変更を保存しますかのメッセージを表示
                DialogResult result = MessageBox.Show(Properties.Resources.save1,
                 Properties.Resources.error, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 字幕を上書きするときに確認する
        /// </summary>
        /// <returns>上書きするかどうか</returns>
        private bool CheckOverWrite()
        {
            string subtitlePath = Path.GetDirectoryName(videoPath) + "\\" + Path.GetFileNameWithoutExtension(videoPath) + ".vtt";
            //すでに字幕が存在する時
            if (videoPath !=null && File.Exists(subtitlePath))
            {
                //変更を保存しますかのメッセージを表示
                DialogResult result = MessageBox.Show(Properties.Resources.overwrite,
                 Properties.Resources.error, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }

        /// <summary>
        /// 指定した行より下に０以外の時間が入力されている行を見つける
        /// </summary>
        /// <param name="index">何行目から探すか</param>
        /// <returns>エラーが何行目か。エラーがなければ -1。リストの順番がおかしいが０なのでエラーにしない時 -2</returns>
        private int CheckListTime(int index=0)
        {
            //リストビューの行数をカウント
            listLineNum = listView1.Items.Count;

            double TimeNext;
            int max = listLineNum;
            int pos=-1;
            int count = 0;
            TimeNext = -1;
            for (int i = index; i < max; i++)
            {
                TimeNext = VideoPositionToSec(listView1.Items[i].SubItems[(int)column.StartTime].Text)+VideoPositionToSec(listView1.Items[i].SubItems[(int)column.EndTime].Text);

                if (TimeNext == 0)
                {
                    count++;

                }
                else if (TimeNext != 0 && count>0)
                {
                    pos = i;

                    break;//エラーがあればここで抜ける
                }
            }
            if (count > 0 &&TimeNext == 0)//０を見つけてもその下が全て０の時
            {
                pos = -2;
            }
            return pos;
        }




        /// <summary>
        /// 言語の読み取り
        /// </summary>
        private void Language()
        {
            this.Text = Properties.Resources.text;
            モードToolStripMenuItem.Text = Properties.Resources.mode;
            設定ToolStripMenuItem.Text = Properties.Resources.Edit;
            設定ToolStripMenuItem1.Text = Properties.Resources.Edit1;
            ファイルToolStripMenuItem.Text = Properties.Resources.file;
            言語ToolStripMenuItem.Text = Properties.Resources.language;
            開始終了終了ToolStripMenuItem.Text = Properties.Resources.mode1;
            ノーマルToolStripMenuItem.Text = Properties.Resources.mode2;
            開くToolStripMenuItem.Text = Properties.Resources.video;
            字幕を開くToolStripMenuItem.Text = Properties.Resources.subtitle;
            保存ToolStripMenuItem.Text = Properties.Resources.save;
            追加ToolStripMenuItem.Text = Properties.Resources.add;
            編集ToolStripMenuItem.Text = Properties.Resources.edit2;
            削除ToolStripMenuItem.Text = Properties.Resources.delete;
            redoToolStripMenuItem.Text = Properties.Resources.undo;
            やり直すToolStripMenuItem.Text = Properties.Resources.redo;
            上に追加ToolStripMenuItem.Text = Properties.Resources.add2;
            下に追加ToolStripMenuItem.Text=Properties.Resources.add3;
            字幕の遅延ToolStripMenuItem.Text = Properties.Resources.fix;
            listView1.Columns[0].Text = Properties.Resources.subtitle1;
            listView1.Columns[1].Text = Properties.Resources.starttime;
            listView1.Columns[2].Text = Properties.Resources.endtime;
            ヘルプHToolStripMenuItem.Text = Properties.Resources.help;

            label2Text();

            アラビア語ToolStripMenuItem.Text = Properties.Resources.ar;
            英語ToolStripMenuItem.Text = Properties.Resources.en;
            ドイツ語ToolStripMenuItem.Text = Properties.Resources.de;
            スペイン語ToolStripMenuItem.Text = Properties.Resources.es;
            フランス語ToolStripMenuItem.Text = Properties.Resources.fr;
            日本語ToolStripMenuItem.Text = Properties.Resources.ja;
            ロシア語ToolStripMenuItem.Text = Properties.Resources.ru;
            中国語ToolStripMenuItem.Text = Properties.Resources.zh;
        }
    }
}
