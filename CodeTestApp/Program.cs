using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {





            List<Data> timeList = new List<Data>();
            string occur = "Test1";
            //List<String> words = new List<string>() { "Test1", "Test2", "Test3", "Test1" };
            //HashSet<string> _words = new HashSet<string>(words);

            //// int count = words.Where(x => x.Equals(occur)).Count();
            List<KeyValuePair<string, int>> Timelist = new List<KeyValuePair<string, int>>();
            //foreach (var item in words)
            //{
            //    int count = words.Where(x => x.Equals(item)).Count();
            //    //timeList.Add(new Data() { DisplayTime = item, Status = count });              
            //    list.Add(new KeyValuePair<string, int>(item,count)); ;

            //}



            //var x = list.Distinct().ToList();



            // all time slots
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
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (var item in B)
            {
                int count = B.Where(x => x.Equals(item)).Count();
                //timeList.Add(new Data() { DisplayTime = item, Status = count });              
                list.Add(new KeyValuePair<string, int>(item, count)); ;

            }
            var BList = list.Distinct().ToList();
            var x = AList;

            Console.WriteLine("Lit A\n \n   ___________________________________________________\n\n\n");
            foreach (var a in AList)
            {
                Console.WriteLine(a.Key + "  " + a.Value);
            }

            Console.WriteLine("Lit B\n\n\n      ___________________________________________________\n\n\n");
            foreach (var b in BList)
            {
                Console.WriteLine(b.Key + "  " + b.Value);
            }
            Console.WriteLine("Final \n  \n    ___________________________________________________\n\n\n\n");



            //LsitA and List B

            var finallist = (from l in AList.Concat(BList)
                             group l by l.Key into g
                             select new Data() { DisplayTime = g.Key, Status = g.Max(x => x.Value) })
           .ToList();

            foreach (var item in finallist)
            {
                Console.WriteLine(item.DisplayTime+ " " + item.Status);
            }





            //foreach (var item in AList)
            //{
            //    foreach (var item2 in BList)
            //    {
            //        if (item.Key == item2.Key)
            //        {
            //            Console.WriteLine(item2.Key + " " + item2.Value);
            //            continue;
            //        }
            //        else
            //        {


            //        }

            //    }
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}

            //   var Finalist = AList.Distinct().ToList();

            //foreach(var itm in Finalist)
            //   {
            //       Console.WriteLine(itm.Key + "  "+itm.Value);
            //   }
            //   var c = AList.Intersect(BList);




            // A-(AB)
            // var avilableSlot = AList.Except(c);

            // var timeLists = avilableSlot.Union(c);




            //List<Data> list1 = new List<Data>();
            //list1.Add(new Data() { DisplayTime="8am-9am",Status=0});
            //list1.Add(new Data() { DisplayTime = "9am-10am", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "10am-11am", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "11am-12pm", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "2pm-3pm", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "3pm-4pm", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "4pm-5pm", Status = 0 });
            //list1.Add(new Data() { DisplayTime = "5pm-6pm", Status = 0 });



            //List<Data> list2 = new List<Data>();
            //list2.Add(new Data() { DisplayTime = "8am-9am", Status = 2 });
            //list2.Add(new Data() { DisplayTime = "9am-10am", Status = 1 });
            //list2.Add(new Data() { DisplayTime = "10am-11am", Status = 2 });
            //list2.Add(new Data() { DisplayTime = "11am-12pm", Status = 1 });
            //list2.Add(new Data() { DisplayTime = "2pm-3pm", Status = 2 });



            //output required



            Console.ReadLine();

        }



        public class Data
        {
            public int Status { get; set; }
            public string DisplayTime { get; set; }

            

        }
    }
}
