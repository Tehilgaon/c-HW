﻿//Sarah Ben Soussan 001475614
//Tehila Gaon 315136952
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil2
{
    class GuestRequest
    {
        private bool isApproved;
        private DateTime EntryDate;
        private DateTime ReleaseDate;

        //properties
        public bool IsApproved { get => isApproved; set => isApproved = value; }
        public DateTime EntryDate1 { get => EntryDate; set => EntryDate = value; } 
        public DateTime ReleaseDate1 { get => ReleaseDate; set => ReleaseDate = value; } 

        //overriding the ToString function
        public override string ToString()
        {
            string str = "Entry Date: ";
            str += Convert.ToString(EntryDate);
            str += " Release Date: ";
            str += Convert.ToString(ReleaseDate);
            if (isApproved)
                str += " Approved";
            else
                str += " Not Approved";
            return str;

        }
    }

}