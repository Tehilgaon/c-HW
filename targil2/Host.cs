//Sarah Ben Soussan 001475614
//Tehila Gaon 315136952
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace targil2
{
    class Host : IEnumerable   //the class uses the interface IEnumerable in order to go over it with an iterator 
    {
        private int HostKey; //host's ID
        private List<HostingUnit> HostingUnitCollection; //a list with the HostingUnit that belongs to the host

        //properties
        internal List<HostingUnit> HostingUnitCollection1 { get => HostingUnitCollection; set => HostingUnitCollection = value; }

        //c-tor
        public Host(int HostKey, int HostingUnitNum)
        {
            this.HostKey = HostKey;
            HostingUnitCollection1 = new List<HostingUnit>(HostingUnitNum);
            for (int i = 0; i < HostingUnitNum; i++)
                HostingUnitCollection1.Add(new HostingUnit());
        }
        //The function calls HostingUnit's ToString function
        public override string ToString()
        {
            foreach (HostingUnit n in HostingUnitCollection1)
            {
                n.ToString();
                Console.WriteLine();
            }
            return " ";
        }
        private long SubmitRequest(GuestRequest guestReq) //The function receives a guestRequest and return its HostingUnitKey 
        {
            foreach (HostingUnit n in HostingUnitCollection1)
            {
                if (n.ApprovedRequest(guestReq))
                    return n.HostingUnitKey1;
            }
            return -1;
        }
        public int GetHostAnnualBusyDays() //The function sums up the busyDays of all the hostingUnit 
        {
            int sum = 0;
            foreach (HostingUnit n in HostingUnitCollection1)
            {
                sum += n.GetAnnualBusyDays();
            }
            return sum;
        }
        public void SortUnits() //The function calls the list's sorting function, according to the compareTo function
        {
            HostingUnitCollection1.Sort();
        }
        public bool AssignRequests(params GuestRequest[] list)//The function receives few GuestRequests and returns true if all of them are accepted
        {
            for (int i = 0; i < list.Length; i++)
                if (SubmitRequest(list[i]) == -1)
                    return false;
            return true;
        }
        public HostingUnit this[int index] //indexer
        {
            get
            {
                return HostingUnitCollection1[index] as HostingUnit;
            }
        }

        public IEnumerator GetEnumerator() ////The function calls the list's GetEnumerator that wrote the moveNext and Current functions
        {
            return HostingUnitCollection1.GetEnumerator();
        }





    }
}