using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace OFDF3TailControlGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка перетаскивания файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length>1)
                {
                    MessageBox.Show("Перетаскивайте только по одному файлу");
                    return;
                }

                string fname = files[0];
                if (!File.Exists(fname))
                {
                    MessageBox.Show("Странно, но файл не найден");
                    return;
                }
                else
                {
                    if ( Path.GetExtension(fname).Contains("xlsx"))
                    {
                        tbFile.Text = fname;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("У файла не то расширение");
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Поддерживаются только файлы");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            
            cbAnalize.Checked = false;
            cbReadOFD.Checked = false;
            cbReadF3tail.Checked = false;

            

            if (tbFile.Text.Length == 0) // для отладки 
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    tbFile.Text = openFileDialog1.FileName;
                }
            }

            if (!File.Exists(tbFile.Text))
            {
                MessageBox.Show("Нет такого файла");
                return;
            }

            if (!Path.GetExtension(tbFile.Text).Contains("xlsx"))
            {
                MessageBox.Show("Расширение файла не excel");
                return;
            }



            // Получаем чеки из файла и F3Tail
            ReadOFDCheque oFDCheque;
            if (tbFile.Text.Length > 0)
            {
                oFDCheque = new ReadOFDCheque(tbFile.Text); /// если что то выбрали 
            }else
            {
                oFDCheque = new ReadOFDCheque(); /// если пусто 
            }
            
            cbReadOFD.Checked = true;
            
            
            ReadF3tailCheque f3TailCheque = new ReadF3tailCheque(Properties.Settings.Default.ConnectionString, oFDCheque.MinDate, oFDCheque.MaxDate);
            
            cbReadF3tail.Checked = true;
            CompareMe(oFDCheque.CL, f3TailCheque.CL);
            cbAnalize.Checked = true;
            MessageBox.Show("Анализ закончен");
        }
        public void CompareMe(List<Cheque> dtofd, List<Cheque> dtef)
        {

            var wbook = new XLWorkbook();
            var ws = wbook.AddWorksheet("Результаты анализа");

            int i = 1;
            ws.FirstCell().Value = 2;
                        
            List<string> ofdhashes = new List<string>();
            List<string> efhashes = new List<string>();
           

            List<string> ofd = new List<string>();
            List<string> f3tail = new List<string>();


            foreach (Cheque c in dtofd)
            {
                ofdhashes.Add(c.hash);
            }

            foreach (Cheque c in dtef)
            {
                efhashes.Add(c.hash);
            }

            StringBuilder sb = new StringBuilder();

            
            i++;
            progressBar1.Value = 0;
            progressBar1.Maximum = efhashes.Count;
            int pb = 0;
            foreach (string s in efhashes)
            {
                if (!ofdhashes.Contains(s))
                {
                    //i++;
                    //ws.Cell(i, 1).Value = s;
                    Console.WriteLine(s);
                    sb.AppendLine(s);
                    f3tail.Add(s);                    
                }
                pb++;
                progressBar1.Value = pb;
            }

            i++;
            
            File.WriteAllText("result.txt", sb.ToString());
            pb = 0;
            progressBar1.Maximum = ofdhashes.Count;
            
            sb = new StringBuilder();
            foreach (string s in ofdhashes)
            {
                if (!efhashes.Contains(s))
                {
                    
                    Console.WriteLine(s);
                    sb.AppendLine(s);
                    ofd.Add(s);
                }
                pb++;
                progressBar1.Value = pb;
            }

            File.WriteAllText("result2.txt", sb.ToString());
            i++;
            ws.Cell(i, 1).Value = "Отличия в чеках ОФД";
            
            i++;
            foreach (Cheque c in dtofd)
            {
                if (ofd.Contains(c.hash))
                {
                    i++;

                    ws.Cell(i, 1).Value = c.cheque_date;
                    ws.Cell(i, 2).Value = c.kassa;
                    ws.Cell(i, 3).Value = c.summ_cheque;
                    ws.Cell(i, 4).Value = c.cheque_number;
                    ws.Cell(i, 5).Value = c.fp;


                }

            }
            
            i++;
            ws.Cell(i, 1).Value = "Отличия в чеках Ефарма";
            i++;
            foreach (Cheque c in dtef)
            {
                if (f3tail.Contains(c.hash))
                {
                    i++;
                    ws.Cell(i, 1).Value = c.cheque_date;
                    ws.Cell(i, 2).Value = c.kassa;
                    ws.Cell(i, 3).Value = c.summ_cheque;
                    ws.Cell(i, 4).Value = c.cheque_number;
                    ws.Cell(i, 5).Value = c.fp;

                }

            }

            // Сравнение сумм
            i++;
            ws.Cell(i, 1).Value = "Отличия в суммах по чекам";
            i++;
                    
            pb = 0;
            progressBar1.Maximum = dtef.Count;
            int cnt = 0;
            foreach (Cheque c in dtef)
            {
                List<Cheque> selected = dtofd.FindAll(item => item.hash == c.hash);
                foreach (Cheque s in selected)
                {
                    if (s.summ_cheque!=c.summ_cheque)
                    {
                        i++;
                        ws.Cell(i, 1).Value = c.cheque_date;
                        ws.Cell(i, 2).Value = c.kassa;
                        ws.Cell(i, 3).Value = c.summ_cheque;
                        ws.Cell(i, 4).Value = c.cheque_number;
                        ws.Cell(i, 5).Value = c.fp;
                    }
                }
                progressBar1.Value = cnt;
                cnt++;

            }

            wbook.SaveAs("data.xlsx");
           
        }
    }
}
