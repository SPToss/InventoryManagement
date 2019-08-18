using DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Types.Base
{
    public abstract class TypeCacheValue<T> where T : ICacheType
    {
        private IEnumerable<T> _cache;
        private IEnumerable<T> Cache
        {
            get
            {
                if(_cache == null || _lastRefreshTime == null)
                {
                    RefresCache();
                }

                if(_lastRefreshTime.Value.AddMinutes(_refreshInterval) < DateTime.Now)
                {
                    RefresCache();
                }

                return _cache;
            }
            set { _cache = value; }
        }


        private Func<IEnumerable<T>> _refreshAction;
        private DateTime? _lastRefreshTime;
        private int _refreshInterval;

        protected TypeCacheValue(Func<IEnumerable<T>> refreshAction, int refreshInterval)
        {
            _refreshAction = refreshAction;
            _refreshInterval = refreshInterval;
        }

        public T GetById(int id)
        {
            return Cache.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAllActive()
        {
            return Cache.Where(x => x.Active == 1);
        }


        private void RefresCache()
        {
            Cache = _refreshAction();
            _lastRefreshTime = DateTime.Now;
        }
    }
}