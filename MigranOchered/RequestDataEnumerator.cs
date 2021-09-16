using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace RequestToCash
{
    public class RequestDataEnumerator : IEnumerator<RequestData>
    {
        RequestDataCollection dataCollection;
        int currentIndex;
        RequestData current;

        public RequestDataEnumerator(RequestDataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
            currentIndex = -1;
            current = default(RequestData);
        }

        public RequestData Current => current;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (++currentIndex >= dataCollection.Count)
            {
                return false;
            }
            else
            {
                current = dataCollection[currentIndex];
            }
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
            return;
        }
    }
}
