using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class OdradenoDb
    {
        public int ukupnaSatnica { get; private set; }
        public bool Greska { get; private set; }
        /// <summary>
        /// Unos Satnice sa ScheduleEntryUc kontrole u bazu podataka.
        /// </summary>
        /// <param name="dan"></param>
        /// <param name="sati"></param>
        /// <returns></returns>
        public Odradeno Unos(DateTime dan, int sati)
        {
            Greska = false;
            Odradeno OdrUnos = new Odradeno();
            OdrUnos.Dan = dan;
            OdrUnos.Sati = sati;
            OdrUnos.UserId = UserDb.LoggedUserId;
            OdrUnos.SatnicaId = SatnicaDb.SatnicaId;
            using (DbEntities ctx = new DbEntities())
            {
                if (ctx.Odradeno.Any(x => x.UserId == UserDb.LoggedUserId && x.Dan == OdrUnos.Dan))
                {
                    Greska = true;
                    return null;
                }
                else
                {
                    OdrUnos = ctx.Odradeno.Add(OdrUnos);
                    ctx.SaveChanges();
                    return OdrUnos;
                }
            }
            
        }
        /// <summary>
        /// Izvlaci UserId i prikazuje ukupnu svotu za odabrani mjesec.
        /// </summary>
        public void showSum()
        {
            
            using (DbEntities ctx = new DbEntities())
            {

                List<Odradeno> _Odradeno;
                _Odradeno = ctx.Odradeno.ToList();
                int brojSati = _Odradeno.Sum(x => x.Sati);
                int brojSatiVikendom = _Odradeno.Where(x => x.SatnicaId == 2 && x.UserId == UserDb.LoggedUserId)
                                    .Sum(x => x.Sati)*25;
                int brojSatiRadniTjedan = _Odradeno.Where(x => x.SatnicaId == 1 && x.UserId == UserDb.LoggedUserId)
                                    .Sum(x => x.Sati)*20;
                ukupnaSatnica = brojSatiVikendom + brojSatiRadniTjedan;
                
                //satnica za tekuci mjesec, ili odredeni mjesec!***
                //Hash za password 

            }
        }
    }
}
