using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Dapper;

namespace OFDF3TailControlGUI
{
    class ReadF3tailCheque : ReadChequeBase
    {
        public DataTable dtf3tail;
        private string ConnectionString;
        public ReadF3tailCheque (string connectionString, DateTime mindate, DateTime maxdate)
        {
            MaxDate = maxdate;
            MinDate = mindate;
            ConnectionString = connectionString;
            dtf3tail = getEfCheque(mindate, maxdate);
            CL = new List<Cheque>();
            foreach (DataRow dr in dtf3tail.AsEnumerable())
            {
                Cheque c = new Cheque();
                c.fp = dr["fp"].ToString();
                c.hash = dr["hash"].ToString();
                c.cheque_number = int.Parse (dr["cheque_number"].ToString());
                c.kassa = dr["kassa"].ToString();
                c.cheque_date = DateTime.Parse(dr["cheque_date"].ToString());
                c.summ_cheque = decimal.Parse(dr["summ_cheque"].ToString());
                CL.Add(c);
            }
        }

        /// <summary>
        /// Получаем список чеков из F3Tail
        /// </summary>
        /// <param name="mindate">Начальный период выборки чеков</param>
        /// <param name="maxdate">Конечный период</param>
        /// <returns>Возвращаем Datatable с чеками</returns>
        public  DataTable getEfCheque(DateTime mindate, DateTime maxdate)
        {

            String conSTR = ConnectionString; //Properties.Settings.Default.ConnectionString;
            SqlConnection sqlConn = new SqlConnection(conSTR);
            string query = File.ReadAllText("CHEQUE.SQL");
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@MINDATE", SqlDbType.DateTime);
            cmd.Parameters["@MINDATE"].Value = mindate;
            cmd.Parameters.Add("@MAXDATE", SqlDbType.DateTime);
            cmd.Parameters["@MAXDATE"].Value = maxdate;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConn.Close();
            return dt;
            
        }

    }
}
