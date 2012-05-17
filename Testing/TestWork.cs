using System;
using System.Collections.Generic;
using System.Linq;
using Meddle;

namespace Testing
{
    public class TestWork : IWork, IDisposable
    {
        public TestWork(int size)
        {
            this.Size = size;
        }

        public int Size { get; set; }

        private IEnumerable<TestEntity> _entities;
        public IEnumerable<TestEntity> Entities
        {
            get 
            {
                if (_entities == null)
                    _entities = Enumerable.Repeat<TestEntity>(new TestEntity(), this.Size);
                return _entities;
            }
        }

        public IEnumerable<IAddable> Added
        {
            get { return this.Entities.OfType<IAddable>(); }
        }

        public IEnumerable<IUpdatable> Updated
        {
            get { return this.Entities.OfType<IUpdatable>(); }
        }

        public IEnumerable<IDeletable> Deleted
        {
            get { return this.Entities.OfType<IDeletable>(); }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
