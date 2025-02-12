using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class setting
    {
        private int historyIndex;
        private string historytxt;
        public bool EditMode;
        public int selectedIndex;
        private ListView ListView;
        public setting(ListView listView)
        {
            this.ListView = listView;
            historyIndex = -1;
            historytxt = "";
            EditMode = false;
        }

        //前回選択した箇所を変更しなかった場合は履歴でもとに戻す
        public void Undo()
        {
            if (historyIndex > -1 && ListView.Items[historyIndex].SubItems[1].Text == "")
            {
                ListView.Items[historyIndex].SubItems[1].Text = historytxt;
            }
        }

        public void SaveNum(KeyPressEventArgs e)
        {
            string pushKey = e.KeyChar.ToString();
            int selectedIndex = ListView.SelectedItems[0].Index;
            if (EditMode == true)
            {
                //リストが選択されており、かつ数字を入力した時
                if (selectedIndex >= 0 && Regex.IsMatch(pushKey, @"[0-9]"))
                {
                    //キーを変更する
                    ListView.Items[selectedIndex].SubItems[1].Text += pushKey;
                }
                //バックスペースキーを押した時
                else if (selectedIndex >= 0 && pushKey == ((char)Keys.Back).ToString() && ListView.Items[selectedIndex].SubItems[1].Text.Length > 0)
                {
                    //文字を削除する
                    string txt = ListView.Items[selectedIndex].SubItems[1].Text;
                    ListView.Items[selectedIndex].SubItems[1].Text = txt.Substring(0, txt.Length - 1);

                }
                //escキーを押した時
                else if (selectedIndex >= 0 && pushKey == ((char)Keys.Escape).ToString())
                {
                    //前回選択した箇所を変更しなかった場合は履歴でもとに戻す
                    if (historyIndex > -1 && ListView.Items[historyIndex].SubItems[1].Text == "")
                    {
                        ListView.Items[historyIndex].SubItems[1].Text = historytxt;
                    }
                }
            }
        }
        public void DoubleClick()
        {
            EditMode = true;
            selectedIndex = ListView.SelectedItems[0].Index;

            //選択されているindex
            selectedIndex = ListView.SelectedItems[0].Index;



            if (ListView.Items[selectedIndex].SubItems[1].Text != "")
            {
                //変更前の履歴を残す
                historyIndex = selectedIndex;
                historytxt = ListView.Items[selectedIndex].SubItems[1].Text;

                //書き込む前に消す
                ListView.Items[selectedIndex].SubItems[1].Text = "";
            }

        }



    }
}
