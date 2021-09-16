using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToCash
{
    public class RequestDataComperer : IEqualityComparer<RequestData>
    {
        /// <summary>
        /// Сравнивает запросы по содержанию запроса
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(RequestData x, RequestData y)
        {
            return x.Data == y.Data;
        }

        public int GetHashCode(RequestData obj)
        {
            return base.GetHashCode();
        }

    }
}
