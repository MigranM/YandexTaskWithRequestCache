using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToCash
{
    class Program
    {
        static void Main(string[] args)
        {

            RequestDataCollection myCollection = new RequestDataCollection(3);
            RequestData firstReq = new RequestData("Price", 14);
            RequestData secondReq = new RequestData("History", 3);
            RequestData thirdReq = new RequestData("status", 10);
            RequestData req6 = new RequestData("status", 17);
            RequestData req4 = new RequestData("Price", 2);
            RequestData req5 = new RequestData("new", 4);

            myCollection.Add(firstReq);
            myCollection.Add(secondReq);
            myCollection.Add(thirdReq);
            myCollection.Add(req4);
            myCollection.Add(req5);
            myCollection.Add(req6);

            myCollection.Sort();
            foreach (var a in myCollection)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine();
        }
    }
}
