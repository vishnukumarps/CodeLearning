using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {





          
           
            List<string> A = new List<string>();
            A.Add("8am-9am");
            A.Add("9am-10am");
            A.Add("10am-11am");
            A.Add("2pm-3pm");
            A.Add("3pm-4pm");
            A.Add("4pm-5pm");
            List<KeyValuePair<string, int>> AList = new List<KeyValuePair<string, int>>();
            foreach (var item in A)
            {
                AList.Add(new KeyValuePair<string, int>(item, 0));
            }

            // get all booked time slot  using date // check slotavlilabilty il vilikkune
            List<string> B = new List<string>();
            B.Add("2pm-3pm");
            B.Add("8am-9am");
            B.Add("8am-9am");
            B.Add("3pm-4pm");
            B.Add("4pm-5pm");
            B.Add("3pm-4pm");
            B.Add("4pm-5pm");
            B.Add("2pm-3pm");
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (var item in B)
            {
                int count = B.Where(x => x.Equals(item)).Count();
                         
                list.Add(new KeyValuePair<string, int>(item, count)); ;

            }
           
            var BList = list.Distinct().ToList();
            var x = AList;
            var finallist = (from l in AList.Concat(BList)
                             group l by l.Key into g
                             select new Data() { DisplayTime = g.Key, Status = g.Max(x => x.Value) })
           .ToList();

            foreach (var item in finallist)
            {
                Console.WriteLine(item.DisplayTime + " " + item.Status);
            }






            Console.ReadLine();

        }

        public List<Data>FindSlots(List<string> A,List <string> B)
        {
            List<KeyValuePair<string, int>> AList = new List<KeyValuePair<string, int>>();
            foreach (var item in A)
            {
                AList.Add(new KeyValuePair<string, int>(item, 0));
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (var item in B)
            {
                int count = B.Where(x => x.Equals(item)).Count();

                list.Add(new KeyValuePair<string, int>(item, count)); ;

            }
            var BList = list.Distinct().ToList();
          
            var finalList = (from l in AList.Concat(BList)
                             group l by l.Key into g
                             select new Data() { DisplayTime = g.Key, Status = g.Max(x => x.Value) })
                             .ToList();

            List<Data> slotList = new List<Data>();
            foreach (var item in finalList)
            {
                slotList.Add(new Data() {DisplayTime=item.DisplayTime,Status=item.Status});
            }

            return slotList;

        }

        public class Data
        {
            public int Status { get; set; }
            public string DisplayTime { get; set; }



        }
    }

 
}



