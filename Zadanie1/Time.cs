using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public struct Time
    {
        const int maxValue = 59;
        const int secondsInMinute = 60;
        const int secondsInHour = 3600;

        int hours;
        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным!");
                hours = value;
            }
        }

        int minutes;
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным!");
                if (value > maxValue)
                    throw new ArgumentException("Значение должно быть не более 59!");
                minutes = value;
            }
        }

        int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным!");
                if (value > maxValue)
                    throw new ArgumentException("Значение должно быть не более 59!");
                seconds = value;
            }
        }

        public int DurationInSeconds
        {
            get => (Hours * secondsInHour + Minutes * secondsInMinute + Seconds);
        }

        public Time(int hours, int minutes, int seconds) : this()
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString() => $"{Hours}:{Minutes}:{Seconds}\"";

        public override bool Equals(object obj)
        {
            if (obj is Time)
                return DurationInSeconds == ((Time)obj).DurationInSeconds;
            throw new ArgumentException("Объект для сравнения не является структурой Time");
        }

        public override int GetHashCode() => DurationInSeconds.GetHashCode();
        public static bool operator ==(Time x, Time y) => x.Equals(y);
        public static bool operator !=(Time x, Time y) => !x.Equals(y);
        public static bool operator >(Time x, Time y) => x.DurationInSeconds > y.DurationInSeconds;
        public static bool operator <(Time x, Time y) => x.DurationInSeconds < y.DurationInSeconds;
        public static bool operator >=(Time x, Time y) => x.DurationInSeconds >= y.DurationInSeconds;
        public static bool operator <=(Time x, Time y) => x.DurationInSeconds <= y.DurationInSeconds;
        public static Time operator +(Time x, Time y) => GetTimeByValueInseconds(x.DurationInSeconds + y.DurationInSeconds);
        public static Time operator -(Time x, Time y)
        {
            if (x.DurationInSeconds >= y.DurationInSeconds)
                return GetTimeByValueInseconds(x.DurationInSeconds - y.DurationInSeconds);
            else throw new ArgumentException("Значение вычитаемого должно быть меньше или равно уменьшаемому");
        }
        public static Time operator *(double k, Time time) => GetTimeByValueInseconds((int)Math.Round(k * time.DurationInSeconds));

        private static Time GetTimeByValueInseconds(int val)
        {
            int seconds = val;
            int hours = seconds / secondsInHour;
            seconds %= secondsInHour;
            int minutes = seconds / secondsInMinute;
            seconds %= secondsInMinute;
            return new Time(hours, minutes, seconds);
        }
    }
}

