//Sarah Ben Soussan 001475614
//Tehila Gaon 315136952
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class HostingUnit : IComparable
    {
        private int totalBusy; //The number of busy days per year
        private static long stSerialKey = 10000000;   // a running ID number
        private bool[,] Diary; //The matrix

        public long HostingUnitKey1 { get; set; } //the specific stSerialKey to this HostingUnit

        //c-tor
        public HostingUnit()
        {
            HostingUnitKey1 = stSerialKey++;
            Diary = new bool[12, 31];
        }

        //indexer
        public bool this[DateTime date]  
        {
            get
            {
                return Diary[date.Month - 1, date.Day - 1];
            }
            set
            {
                Diary[date.Month - 1, date.Day - 1] = value;
            }
        }
        
        //the function checks if all the days are free and synchronizes it 
        public bool ApprovedRequest(GuestRequest guestReq)
        {
            DateTime eDate = guestReq.EntryDate1;
            DateTime rDate = guestReq.ReleaseDate1;

            DateTime date = eDate;
            while (date != rDate)
            {
                if (this[date])
                {
                    guestReq.IsApproved = false;
                    return false;
                }
                date = date.AddDays(1); //adding a day 
            }
            while (eDate != rDate)
            {
                this[eDate] = true;
                totalBusy++;  //counting the number of 'true' values
                eDate = eDate.AddDays(1);
            }
            guestReq.IsApproved = true;
            return true;
        }

        public int CompareTo(object obj) //The function determines the preference for sorting, according to the totalbusy value
        {
            HostingUnit hostU = (HostingUnit)obj;
            return totalBusy.CompareTo(hostU.totalBusy);
        }
        public new void ToString()  //the function prints the entry and release dates 
        {
            DateTime yesterday, today;
            today = new DateTime(2020, 1, 1);
            Console.WriteLine(HostingUnitKey1);
            if (this[today])
               Console.WriteLine(" Entry Date {0}/{1}/2020 ", today.Day, today.Month);
            while (today.Year==2020)
            {
                yesterday = today; 
                today = today.AddDays(1);
                if (this[today] && !this[yesterday])
                    Console.WriteLine(" Entry Date {0}/{1}/2020 ", today.Day, today.Month);
                if (!this[today] && this[yesterday])
                    Console.WriteLine(" Release Date {0}/{1}/2020 ", today.Day, today.Month);
            }
        }
        public int GetAnnualBusyDays() { return totalBusy; }
        public float GetAnnualBusyPercentage() { return (totalBusy / 372) * 100; } 
    }
}