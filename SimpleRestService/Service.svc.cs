using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleRestService
{
    [ServiceContract]
    public class Service
    {
        [WebInvoke(UriTemplate = "multiples/{number}", Method = "POST")] 
        [OperationContract]
        public Result GetMultiples(int number)
        {
            var list = Enumerable.Range(1, 100);
            var multiples = list.Where(x => x % number == 0);
            return new Result
            {
                Number = number,
                Multiples = multiples.ToArray()
            };
        }
    }

    [DataContract]
    public class Result
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int[] Multiples { get; set; }
    }
}
