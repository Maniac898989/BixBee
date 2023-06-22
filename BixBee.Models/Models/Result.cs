using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Models.Models
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        public object ReturnedObject { get; set; }
        public string Message { get; set; }
    }

    public class Result<T> : Result
    {
        public new T ReturnedObject { get; set;}
    }
}
