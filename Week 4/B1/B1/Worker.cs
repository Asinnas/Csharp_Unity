using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1
{
    public enum Level
    {
        Leader,
        Deputy,
        WorkerLevel3,
        WorkerLevel2,
        WorkerLevel1,
        Other
    }
    class Worker : Person
    {
        private string code;

        private Level level;
        public Worker() { }

        public Worker(string code, string fullName, int age, string locate, Level level) : base(fullName, age, locate)
        {
            this.code = code;
            this.level = level;
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public Level Level
        {
            get { return level; }
            set { level = value; }
        }

        public double payroll()
        {
            double coefficient;
            switch (level)
            {
                case Level.Leader: coefficient = 3.0; break;
                case Level.Deputy: coefficient = 2.5; break;
                case Level.WorkerLevel3: coefficient = 2.0; break;
                case Level.WorkerLevel2: coefficient = 1.5; break;
                case Level.WorkerLevel1: coefficient = 1.2; break;
                default: coefficient = 1.0; break;
            }
            return 8000000 * coefficient;
        }

        public void showInfo()
        {
            Console.WriteLine($"Full Name: {FullName}, Age: {Age}, Locate: {Locate}, Code: {code}, Level: {level}, Payroll: {payroll()}");
        }
    }
}
