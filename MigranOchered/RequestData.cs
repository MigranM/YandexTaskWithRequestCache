using System;
using System.Collections.Generic;

namespace RequestToCash
{
    public class RequestData : IEquatable<RequestData>, IComparable<RequestData>
    {
        Guid id;
        int _time;
        string _data;

        public Guid Id { get => id; }

        public int Time
        {
            get => _time;
            set
            {
                if (value < 0) throw new Exception("Negative time exp");
                else
                {
                    _time = value;
                }
            }
        }

        public string Data
        {
            get => _data;
            set
            {
                if (String.IsNullOrEmpty(value)) _data = "empty request";
                else _data = value;
            }
        }

        public RequestData(string data, int time)
        {
            _time = time;
            _data = data;
            id = Guid.NewGuid();
        }

        public int CompareTo(RequestData other)
        {
            if (this.Time > other.Time) return 1;
            else if (this.Time < other.Time) return -1;
            else return 0;
        }

        public bool Equals(RequestData other)
        {
            return (this.Id == other.Id);
        }

        public bool Equals(RequestData other, IEqualityComparer<RequestData> comperer)
        {
            return comperer.Equals(this, other);
        }
        
        public override string ToString()
        {
            return $"id = \"{this.id}\" data = \"{this._data}\", time = \"{this._time}\"";
        }
        public static bool operator <(RequestData a, RequestData b)
        {
            return (a.Time < b.Time);
        }
        public static bool operator >(RequestData a, RequestData b)
        {
            return (a.Time > b.Time);
        }
        
    }
}
