using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class history
    {
        List<string[]> listUndo;
        List<string[]> listRedo;
        public ListView listView;
        private int pointer;
        private int FocusedRow;


        public history(ListView listView,int FocusedRow)
        {
            this.listView = listView;
            this.FocusedRow = FocusedRow;
            listUndo = new List<string[]>();
            listRedo = new List<string[]>();
            pointer = -1;

    

        }
        /// <summary>
        /// 履歴を追加
        /// </summary>
        /// <param name="txt">追加する文字</param>
        /// <param name="action">実行した動作</param>
        /// <param name="row">行数</param>
        /// <param name="start">開始時間：00：00：00.000</param>
        /// <param name="end">終了時間：00：00：00.000</param>
        public void AddRedo(string txt,string action,int row, string start = "00:00:00.000" ,string end = "00:00:00.000")
        {
            int count = listRedo.Count;


            listRedo.Add(new string[5]);
            listRedo[count][0] = Convert.ToString(row);//何行目か
            listRedo[count][1] = action;//何をするか
            listRedo[count][2] = txt;//字幕
            listRedo[count][3] = start;//開始時間
            listRedo[count][4] = end;//終了時間

            

        }
        /// <summary>
        /// 履歴を追加
        /// </summary>
        /// <param name="txt">追加する文字</param>
        /// <param name="action">実行した動作</param>
        /// <param name="row">行数</param>
        /// <param name="start">開始時間：00：00：00.000</param>
        /// <param name="end">終了時間：00：00：00.000</param>
        public void AddUndo(string txt, string action, int row, string start = "00:00:00.000", string end = "00:00:00.000")
        {
            int count = listUndo.Count;
            ListCheck(count);
            count = listUndo.Count;

            listUndo.Add(new string[5]);
            listUndo[count][0] = Convert.ToString(row);//何行目か
            listUndo[count][1] = action;//何をするか
            listUndo[count][2] = txt;//字幕
            listUndo[count][3] = start;//開始時間
            listUndo[count][4] = end;//終了時間
            
            pointer++;
        }



        /// <summary>
        /// Undoした状態でリストを変更した場合にそれ以降の履歴を消す
        /// </summary>
        /// <param name="Count">履歴の数</param>
        public void ListCheck(int Count)
        {
            //履歴の数と現在のポインターの値を比較する
            int num  = Count - (pointer + 1);
            if (num != 0)
            {

                listUndo.RemoveRange(Count - num, num);
                listRedo.RemoveRange(Count - num, num);
            }
        }



        /// <summary>
        /// 履歴を使ってもとに戻す
        /// </summary>
        public void Undo()
        {
            if (pointer > -1)
            {
                int index = Convert.ToInt32(listUndo[pointer][0]);
                if (listUndo[pointer][1] == "Add")
                {

                    listView.Items.RemoveAt(index);

                }
                else if(listUndo[pointer][1] == "Writing" || listUndo[pointer][1] == "Edit")
                {
                    listView.Items[index].SubItems[0].Text = listUndo[pointer][2];
                    listView.Items[index].SubItems[1].Text = listUndo[pointer][3];
                    listView.Items[index].SubItems[2].Text = listUndo[pointer][4];





                }
                else if (listUndo[pointer][1] == "Delete")
                {
                    ListViewItem lvi;
                    lvi = new ListViewItem();
                    lvi.Text = listUndo[pointer][2];
                    lvi.SubItems.Add(listUndo[pointer][3]);
                    lvi.SubItems.Add(listUndo[pointer][4]);
                    listView.Items.Insert(index, lvi);
                }
                    pointer--;

   


                
            }
            

        }


        /// <summary>
        /// 履歴を使ってやり直す
        /// </summary>
        public void Redo()
        {
            int count = listRedo.Count-1;
            if (pointer < count)
            {
                pointer++;
                int index = Convert.ToInt32(listRedo[pointer][0]);
                if (listRedo[pointer][1] == "Add")
                {
                    ListViewItem lvi;
                    lvi = new ListViewItem();
                    lvi.Text=listRedo[pointer][2];
                    lvi.SubItems.Add(listRedo[pointer][3]);
                    lvi.SubItems.Add(listRedo[pointer][4]);
                    listView.Items.Insert(index, lvi);

                    try
                    {
                        //フォーカスを当てる
                        listView.Items[FocusedRow].Selected = false;
                        listView.Items[index].Selected = true;
                        FocusedRow = index;
                    }
                    catch
                    {

                    }

                }
                else if (listRedo[pointer][1] == "Writing" || listRedo[pointer][1] == "Edit")
                {
                    listView.Items[index].SubItems[0].Text = listRedo[pointer][2];
                    listView.Items[index].SubItems[1].Text = listRedo[pointer][3];
                    listView.Items[index].SubItems[2].Text = listRedo[pointer][4];

                    try
                    {
                        //フォーカスを当てる
                        listView.Items[FocusedRow].Selected = false;
                        listView.Items[index].Selected = true;
                        FocusedRow = index;
                    }
                    catch
                    {

                    }
                }
                else if (listUndo[pointer][1] == "Delete")
                {
                    listView.Items.RemoveAt(index);
                }

                


   

            }
        }




    }
}
