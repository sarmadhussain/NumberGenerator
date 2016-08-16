using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace NumberGenerator.Models
{
    public class NumberViewModel
    {
        public List<Int64> evenNumbers { get; set; }
        public List<Int64> oddNumbers { get; set; }
        public List<Int64> allNumbers { get; set; }
        public List<string> cezNumbers { get; set; }
        public List<Int64> fibNumbers { get; set; }

        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public NumberViewModel()
        {
            oddNumbers = new List<Int64>();
            evenNumbers = new List<Int64>();
            allNumbers = new List<Int64>();
            cezNumbers = new List<string>();
            fibNumbers = new List<Int64>();
            IsError = false;
            ErrorMessage = "";
        }
    }
}