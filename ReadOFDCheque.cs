using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML.Excel;
using System.Data;
using System.ComponentModel;

namespace OFDF3TailControlGUI
{
       
    
    /// <summary>
    /// Базовый класс чеки для проверки
    /// </summary>
    

    class ReadOFDCheque : ReadChequeBase
    {

        private string fname;
        public DataTable dtofd;
        /// <summary>
        /// Нужно передать имя файла для анализа. Или оставить пустым - тогда будет загружен тестовый файл 
        /// </summary>
        /// <param name="filename"></param>
        public ReadOFDCheque (string filename="ofd_test.xlsx")
        {

            
            
            int cheque_date = Properties.Settings.Default.cheque_date;
            int cheque_number = Properties.Settings.Default.cheque_number;
            int sum_cheque = Properties.Settings.Default.sum_cheque;
            int fp = Properties.Settings.Default.fp;
            int kassa = Properties.Settings.Default.kassa;

            DTMAXMIN vtime = new DTMAXMIN();
            fname = filename;
            CL = new List<Cheque>();
            using (var excelWorkbook = new XLWorkbook(filename))
            {
                var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();

                foreach (var dataRow in nonEmptyDataRows)
                {
                    Cheque c = new Cheque();
                    if (dataRow.RowNumber() >= 2)

                    {
                        /*
                        c.cheque_date = DateTime.Parse(dataRow.Cell(1).Value.ToString());
                        c.cheque_number = int.Parse(dataRow.Cell(8).Value.ToString());
                        c.summ_cheque = decimal.Parse(dataRow.Cell(24).Value.ToString());
                        c.fp = dataRow.Cell(7).Value.ToString();
                        c.kassa = dataRow.Cell(3).Value.ToString();
                        c.hash = c.cheque_number.ToString().Trim() + "|" + c.fp.ToString().Trim();
                        */
                        c.cheque_date = DateTime.Parse(dataRow.Cell(cheque_date).Value.ToString());
                        c.cheque_number = int.Parse(dataRow.Cell(cheque_number).Value.ToString());
                        c.summ_cheque = decimal.Parse(dataRow.Cell(sum_cheque).Value.ToString());
                        c.fp = dataRow.Cell(fp).Value.ToString();
                        c.kassa = dataRow.Cell(kassa).Value.ToString();
                        c.hash = c.cheque_number.ToString().Trim() + "|" + c.fp.ToString().Trim();
                        CL.Add(c);

                            vtime.CompareDate(c.cheque_date);
                        
                        
                    }
                }
            }


            MaxDate = vtime.GetMaxDate();
            MinDate = vtime.GetMinDate();
            this.dtofd = ToDataTable(CL);

        }
        

        /// <summary>
        ///Трансформируем список в datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public  DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Читаем и заполняем список чеков из 
        /// </summary>
        private  void ReadCheque ()
        {
            
            if (!File.Exists(fname))
            {
                throw new Exception("Нет файла для анализа!");
            }

            DTMAXMIN vtime = new DTMAXMIN();
            using (var excelWorkbook = new XLWorkbook(fname))
            {
                var nonEmptyDataRows = excelWorkbook.Worksheet(1).RowsUsed();

                foreach (var dataRow in nonEmptyDataRows)
                {
                    Cheque c = new Cheque();
                    if (dataRow.RowNumber() >= 2)

                    {
                            c.cheque_date = DateTime.Parse(dataRow.Cell(1).Value.ToString());
                            c.cheque_number = int.Parse(dataRow.Cell(8).Value.ToString());
                            c.summ_cheque = decimal.Parse(dataRow.Cell(24).Value.ToString());
                            c.fp = dataRow.Cell(7).Value.ToString();
                            c.kassa = dataRow.Cell(3).Value.ToString();
                            c.hash = c.cheque_number.ToString().Trim() + "|" + c.fp.ToString().Trim(); // составной индекс по номерам из чеков

                            CL.Add(c);

                            vtime.CompareDate(c.cheque_date); // сравниваем даты с минимальной и максимальной
                     }
                        
                    
                }

                MaxDate = vtime.GetMaxDate();
                MinDate = vtime.GetMinDate();
            }


        }


     

    }
}
