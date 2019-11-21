using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class HostingUnit: IComparable
    {
        private int totalBusy;
        private static long stSerialKey=10000000;
        private long HostingUnitKey;
        private bool [,] Diary;

        public long HostingUnitKey1 { get => HostingUnitKey; set => HostingUnitKey = value; }

        HostingUnit()
        {
            HostingUnitKey1 = stSerialKey++;
            Diary = new bool[12, 31];
        }
        public bool ApprovedRequest (GuestRequest guestReq)
        {
            int eMonth = guestReq.EntryDate1.Month;
            int eDay = guestReq.EntryDate1.Day;

            int rMonth = guestReq.ReleaseDate1.Month;
            int rDay = guestReq.ReleaseDate1.Day;

            int period = (rMonth - eMonth) * 31 + (rDay - eDay);
            int day = eDay;
            int month = eMonth;
            for(int i=0; i<period; i++)
            {
                if (Diary[month-1, day-1])
                {
                    guestReq.IsApproved = false;
                    return false;
                }
                month = month + day / 30;
                day = (day + 1) % 31;
            }
            for (int i = 0; i < period-1; i++)
            {
                Diary[eMonth - 1, eDay - 1] = true;
                totalBusy++; 
                eMonth = eMonth + eDay / 30;
                eDay = (eDay + 1) % 31;
            }

            guestReq.IsApproved = true;
            return true;
        }

        public int CompareTo(object obj)
        {
            HostingUnit hostU = (HostingUnit)obj;
            return totalBusy.CompareTo(hostU.totalBusy);
        }
        new void ToString()
        {
            int month = 0;
            int day = 0;
            Console.WriteLine(HostingUnitKey1);
            bool yesterday, today = Diary[month, day];
            if (today)
                Console.WriteLine(" Entry Date {0}/{1} ", day+1, month+1);
            while (month<12)
            {
                yesterday = today;
                month = month + day / 30;
                day = (day + 1) % 31;
                today= Diary[month, day];
                if(today&&!yesterday)
                    Console.WriteLine(" Entry Date {0}/{1} ", day + 1, month + 1);
                if(!today&&yesterday)
                    Console.WriteLine(" Release Date {0}/{1} ", day + 1, month + 1);
            }
        }
        public int GetAnnualBusyDays() { return totalBusy; }
        public float GetAnnualBusyPercentage() { return (totalBusy / 31 * 12) * 100; }
    }
}
  
