using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseFilter
    {
        private int _itemsPerPage = 10;
        private int _skip =0;
        private int _currentPage =1;
        public bool IsNeedPaging { get; set; }
        public long TotalCount { get; set; }

        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        public int ItemPerPage
        {
            get { return _itemsPerPage; }
            set { _itemsPerPage = value; }
        }

        public int Skip
        {
            get
            {
                if (_skip == 0)
                    _skip = (_currentPage - 1) * _itemsPerPage;
                return _skip;
            }
            set { _skip = value; }
        }

        public int Take
        {
            get { return _itemsPerPage;}
            set { _itemsPerPage = value; }
        }

        public long TotalPageCount
        {
            get { return TotalCount/ItemPerPage + ((TotalCount%ItemPerPage > 0) ? 1 : 0); }
        }

        public BaseFilter()
        {
            IsNeedPaging = true;
        }
    }
}
