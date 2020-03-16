using System;
using System.Threading;

namespace clock
{
    class Clock
    {
        public static int Time = 1;
        public delegate void ClickHanlder();
        public delegate void AlarmHanlder();
        public event ClickHanlder ClockClick;
        public event AlarmHanlder ClockAlarm;
        public void click()
        {
            if (ClockClick != null)
            {
                ClockClick();
            }
        }
        public void Alarm()
        {
            if (ClockAlarm != null)
            {
                ClockAlarm();
            }
        }
        public void Work()
        {
            while (true)
            {
                click();
                if (Time == 5)
                {
                    Alarm();
                }
                Thread.Sleep(1000);
                Time++;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Clock clock = new Clock();
            clock.ClockAlarm += Clock_AlarmClick;
            clock.ClockClick += Clock_GoClick;
            clock.Work();
        }
        private static void Clock_GoClick()
        {
            Console.WriteLine("嘀嗒！");
        }
        private static void Clock_AlarmClick()
        {
            Console.WriteLine("叮铃铃铃！");
        }
    }
}