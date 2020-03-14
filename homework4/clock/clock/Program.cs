using System;
using System.Threading;

namespace clock
{
    public delegate void TickHandler(object sender);
    public delegate void AlarmHandler(object sender);

    public class AlarmClock
    {
        private int AlarmHour, AlarmMinute, AlarmSecond;
        public event TickHandler ClockTick;
        public event AlarmHandler ClockAlarm;

        public void SetAlarm(int h, int m, int s)
        {
            AlarmHour = h;
            AlarmMinute = m;
            AlarmSecond = s;
        }

        public void TurnOn()
        {
            int hour, minute, second;
            while (true)
            {
                Thread.Sleep(1000);
                hour = DateTime.Now.Hour;
                minute = DateTime.Now.Minute;
                second = DateTime.Now.Second;
                Tick(hour, minute, second);
                if (hour == AlarmHour && minute == AlarmMinute && second == AlarmSecond)
                    Alarm();
            }
        }

        public void Tick(int h, int m, int s)
        {
            Console.Write(h + ":" + m + ":" + s + " ");
            ClockTick(this);
        }

        public void Alarm()
        {
            ClockAlarm(this);
        }
    }

    public class Manage
    {
        public AlarmClock clock1 = new AlarmClock();

        public Manage()
        {
            clock1.ClockTick += new TickHandler(Clock_Tick);
            clock1.ClockAlarm += new AlarmHandler(Clock_Alarm);
        }

        void Clock_Tick(object sender)
        {
            Console.WriteLine("嘀嗒！");
        }

        void Clock_Alarm(object sender)
        {
            Console.WriteLine("叮铃铃铃！");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Manage m1 = new Manage();
            m1.clock1.SetAlarm(10, 25, 0);
            m1.clock1.TurnOn();
        }
    }
}
