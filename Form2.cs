using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private int TempSizeWidth;
        public string backKey,nextKey,stopKey,stampKey;
        public int seekValue, rewindStartTime;
        public bool OneLine;
        private setting setting1, setting2;
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting1.Undo();


        }


        //OKボタン
        private void button1_Click(object sender, EventArgs e)
        {
            setting1.Undo();
            setting2.Undo();

            if( listView1.Items[0].SubItems[1].Text == "" ||
                listView1.Items[1].SubItems[1].Text == "" ||
                listView1.Items[2].SubItems[1].Text == "" ||
                listView1.Items[3].SubItems[1].Text == "" ||
                listView2.Items[0].SubItems[1].Text == "" ||
                listView2.Items[1].SubItems[1].Text == "")
            {
                MessageBox.Show(Properties.Resources.error, Properties.Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Properties.Settings.Default.backKey = listView1.Items[0].SubItems[1].Text;
                Properties.Settings.Default.nextKey = listView1.Items[1].SubItems[1].Text;
                Properties.Settings.Default.stopKey = listView1.Items[2].SubItems[1].Text;
                Properties.Settings.Default.stampKey = listView1.Items[3].SubItems[1].Text;
                Properties.Settings.Default.seekValue = Convert.ToInt32(listView2.Items[0].SubItems[1].Text);
                Properties.Settings.Default.RewindStartTime = Convert.ToInt32(listView2.Items[1].SubItems[1].Text);
                Properties.Settings.Default.OneLine = OneLinecheckBox1.Checked;
              
                //設定したキーを保存
                Properties.Settings.Default.Save();

                this.Close();
            }

            


            
        }




        private void tabPage2_Click(object sender, EventArgs e)
        {
            
            setting2.Undo();
        }



        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            setting2.SaveNum(e);

        }

       
        private void Form2_Click(object sender, EventArgs e)
        {
            setting1.Undo();
            setting2.Undo();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setting2.DoubleClick();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            setting1.Undo();
            setting2.Undo();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            setting2.EditMode = false;

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setting1.DoubleClick();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            setting1.EditMode = false;
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            //ウィンドウサイズを変えたときに列のサイズを変更する
            listView1.Columns[0].Width += this.Size.Width - TempSizeWidth;
            listView2.Columns[0].Width += this.Size.Width - TempSizeWidth;
            TempSizeWidth = this.Size.Width;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting2.Undo();



        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (setting1.EditMode)
            {
                string pushKey = e.KeyCode.ToString();

                //リストが選択されており、且つ同じキーが無いとき
                if (setting1.selectedIndex >= 0 && pushKey != listView1.Items[0].SubItems[1].Text &&
                    pushKey != listView1.Items[1].SubItems[1].Text &&
                    pushKey != listView1.Items[2].SubItems[1].Text &&
                    pushKey != listView1.Items[3].SubItems[1].Text
                    )
                {
                    //キーを変更する
                    listView1.Items[setting1.selectedIndex].SubItems[1].Text = e.KeyCode.ToString();                    
                }
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            TempSizeWidth = this.MinimumSize.Width;
            setting1 = new setting(listView1);
            setting2 = new setting(listView2);

            //キーの割り当て
            listView1.Items[0].SubItems.Add(backKey);
            listView1.Items[1].SubItems.Add(nextKey);
            listView1.Items[2].SubItems.Add(stopKey);
            listView1.Items[3].SubItems.Add(stampKey);


            listView2.Items[0].SubItems.Add(seekValue.ToString());
            listView2.Items[1].SubItems.Add(rewindStartTime.ToString());

            OneLinecheckBox1.Checked = OneLine;

            tabControl1.TabPages[0].Text = Properties.Resources.assignment;
            tabControl1.TabPages[1].Text = Properties.Resources.other;
            listView1.Columns[0].Text = Properties.Resources.action;
            listView1.Columns[1].Text = Properties.Resources.key; 
            listView1.Items[0].SubItems[0].Text= Properties.Resources.Backward;
            listView1.Items[1].SubItems[0].Text = Properties.Resources.forward;
            listView1.Items[2].SubItems[0].Text = Properties.Resources.pause;
            listView1.Items[3].SubItems[0].Text = Properties.Resources.cue;

            listView2.Columns[0].Text = Properties.Resources.action;
            listView2.Columns[1].Text = Properties.Resources.value;
            listView2.Items[0].SubItems[0].Text = Properties.Resources.seek1;
            listView2.Items[1].SubItems[0].Text = Properties.Resources.rewind;

            button1.Text = Properties.Resources.ok;
            button2.Text = Properties.Resources.cancel;
            OneLinecheckBox1.Text = Properties.Resources.load;
            this.Text= Properties.Resources.setting;        
        }
    }
}
