using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace targil2
{
    class Host : IEnumerable
    {
        private string HostKey;
        private List<HostingUnit> HostingUnitCollection;
        public Host(string HostKey, int HostingUnitNum)
        {
            this.HostKey = HostKey;
            HostingUnitCollection = new List<HostingUnit>(HostingUnitNum);
        }
        new void ToString()
        {
            foreach (HostingUnit n in HostingUnitCollection)
            {
                n.ToString();
                Console.WriteLine();
            }
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit n in HostingUnitCollection)
            {
                if (n.ApprovedRequest(guestReq))
                    return n.HostingUnitKey1;
            }
            return -1;
        }
        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            foreach (HostingUnit n in HostingUnitCollection)
            {
                sum += n.GetAnnualBusyDays();
            }
            return sum;
        }
        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params GuestRequest[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (SubmitRequest(list[i]) == -1)
                    return false;
            return true;
        }
        public HostingUnit this[int index]
        {
            get
            {
                return HostingUnitCollection[index] as HostingUnit;
            }
        }
                    
        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

    
            

         
    }
}
