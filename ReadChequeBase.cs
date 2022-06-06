using System;
using System.Collections.Generic;

namespace OFDF3TailControlGUI
{
    internal abstract class ReadChequeBase
    {
        public List<Cheque> CL;// список загруженных чеков
        public DateTime MaxDate;//дата последнего чека 
        public DateTime MinDate;//дата первого чека


        /// <summary>
        /// Получаем максимальную и минимальную дату для перебора значений чеков
        /// Будет использоваться при получении чеков ефарма
        /// </summary>
        internal class DTMAXMIN
        {

            private DateTime maxdate;
            private DateTime mindate;
            public DTMAXMIN()
            {
                maxdate = DateTime.Now.AddDays(-1000);
                mindate = DateTime.Now.AddDays(1000);
            }

            public void CompareDate(DateTime DateForCompare)
            {
                if (DateForCompare > maxdate)
                    maxdate = DateForCompare;

                if (DateForCompare < mindate)
                    mindate = DateForCompare;
            }

            public DateTime GetMaxDate()
            {
                return maxdate;
            }

            public DateTime GetMinDate()
            {

                return mindate;
            }
        }
    }
}