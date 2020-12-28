using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class PaginateDTO
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 10;
        private readonly int MaxrecordsPerPage = 25;
        public int RecordsPerPage
        {
            get => recordsPerPage;
            set
            {
                recordsPerPage = (value > MaxrecordsPerPage) ? MaxrecordsPerPage : value;
            }
        }
    }
}
