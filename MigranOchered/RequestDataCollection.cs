using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToCash
{
    public class RequestDataCollection : ICollection<RequestData>, IEnumerable<RequestData>
    {
        int maxBufferSize;
        List<RequestData> innerList;
        RequestData oldestRequest;

        public int Count
        {
            get { return innerList.Count; }
        }

        public RequestData this[int index]
        {
            get { return innerList[index]; }
            set { innerList[index] = value; }
        }

        public RequestDataCollection(int bufSise)
        {
            oldestRequest = null;
            maxBufferSize = bufSise;
            innerList = new List<RequestData>();
        }

        int GetOldestReqIndex()
        {
            int index = 0;
            if (Count == 1) return 0;
            for (int i = 1; i < innerList.Count - 1; i++)
            {
                if (innerList[index] > innerList[i]) index = i;
            }
            return index;
        }

        public void Sort()
        {
            innerList.Sort((x, y) => x.CompareTo(y));
        }

        public void Add(RequestData item)
        {
            if (innerList.Contains(item, new RequestDataComperer()))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (new RequestDataComperer().Equals(innerList[i], item) && item > oldestRequest)
                    {
                        innerList[i] = item;
                        Console.WriteLine($"LOG: UPDATE {item}");
                        break;
                    }

                }
            }
            else
            {
                if (Count == maxBufferSize)
                {
                    if (item > oldestRequest)
                    {
                        Remove();
                        Console.WriteLine($"LOG: ADDED {item}");
                        innerList.Add(item);
                    }
                }
                else
                {
                    Console.WriteLine($"LOG: ADDED {item}");
                    innerList.Add(item);
                }
            }
            oldestRequest = innerList[this.GetOldestReqIndex()];

        }
        private bool Remove()
        {
            Console.WriteLine($"LOG: DELETE {oldestRequest}");
            innerList.Remove(oldestRequest);
            oldestRequest = innerList[this.GetOldestReqIndex()];
            return true;
        }
        public bool Remove(RequestData item)
        {
            innerList.Remove(item);
            return true;
        }
        public void Clear()
        {
            innerList.Clear();
        }
        public bool Contains(RequestData item)
        {
            bool found = false;
            foreach (RequestData a in innerList)
            {
                if (this.Equals(item)) found = true;
            }
            return found;
        }

        public void CopyTo(RequestData[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<RequestData> GetEnumerator()
        {
            return new RequestDataEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new RequestDataEnumerator(this);
        }
        public bool IsReadOnly => throw new NotImplementedException();

    }
}
