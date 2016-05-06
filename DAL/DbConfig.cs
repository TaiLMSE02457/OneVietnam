using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unities;

namespace DAL
{
    public class DbConfig
    {
        public static OneVietnamContext GetMongoConnection()
        {            
            try
            {
                var context = (OneVietnamContext)CacheBase.Instance.GetCache(Constants.MongoCacheKey);
                if (context != null)
                {
                    return context;
                }
                context = new OneVietnamContext();
                CacheBase.Instance.Add(Constants.MongoCacheKey, context);
                return context;                
            }
            catch (Exception ex)
            {
                return new OneVietnamContext();
            }
        }
    }
}
