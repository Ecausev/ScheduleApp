using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Database
{
    public class SatnicaDb
    {
        public static int SatnicaId { get; private set; }
        public static int SatnicaValue { get; private set; }

        private List<Satnica> _Satnica;

        /// <summary>
        /// Definira Id od satnice u bazi.
        /// </summary>
        /// <param name="entryDan"></param>
        public void defineSatnicaId(DayOfWeek entryDan)
        {
            using (DbEntities ctx = new DbEntities())
            {
                _Satnica = ctx.Satnica.ToList();

                var dayOfWeek = (int)entryDan;

                if (dayOfWeek == 0)
                {
                    dayOfWeek = 7;
                }

                foreach (var x in _Satnica)
                {
                    if (x.Dani.Substring(dayOfWeek - 1, 1) == "1")
                    {
                        SatnicaValue = x.Vrijednost;
                        SatnicaId = x.SatnicaId;
                        
                        break;
                    }
                }
            }
        }
    }
}

