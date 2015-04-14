/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Eisk.Helpers
{
    /// <summary>
    /// Architectural Note:
    /// The mock DbContext works with the in memory IDbSet (the current class) and performs queries using "LINQ to Object" technology.
    /// Where as the actual data operation in the application uses "LINQ to Entities" technologies to perform queries.
    /// Since these two scenarios uses different technologies behind the hood, please note that in some cases it is possible the mock test may pass,
    /// where the the real application may fail in the same scenario, so care needs to be taken when writing mock tests using FakeDbSet.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class FakeDbSet<T> : IDbSet<T>
    where T : class
    {
        HashSet<T> _data;
        IQueryable _query;

        public FakeDbSet()
        {
            _data = new HashSet<T>();
            _query = _data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            _data.Remove(item);
            return item;
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }


        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }
    }
}
