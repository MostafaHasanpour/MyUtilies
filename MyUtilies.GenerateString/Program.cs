using System;
using System.Threading.Tasks;

namespace MyUtilies.GenerateString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generate string");
            var worker = new Worker();
            worker.DoWork();
            
            Console.ReadKey();
        }

    }
    public class Worker
    {
        public bool IsCompelete { get; private set; }
        public async void DoWork()
        {
            this.IsCompelete = false;
            Console.WriteLine("Doing Work");
            string txt = "";
            var startTime = DateTime.Now;
            for (int i = 1000000; i >= 0; i--)
            {
                string a=await LongOperation(i);
                if (!txt.Contains(a))
                {
                    txt += a;
                }
            }

            Console.WriteLine("");

            Console.WriteLine(txt);
            Console.WriteLine("Work Compeleted");
            var duration = DateTime.Now.Subtract(startTime).TotalSeconds;
            Console.WriteLine(duration);
            IsCompelete = true;
        }

        private async Task<string> LongOperation(int a)
        {
            
            return await LongOperation2(a); 
        }

        private Task<string> LongOperation2(int a)
        {
            return Task.Factory.StartNew(() =>
            {
                Console.Write(a+"-");
                Task.Delay(50);
                return a.ToString();
            });
        }
    }
}
