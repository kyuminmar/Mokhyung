using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokhyung_Management.Model.ViewModel.IO
{
    public class View_IOList
    {
        public int RowNum { get; set; }

        public long IOLSEQ { get; set; }

        public string Mok_Name { get; set; }

        public string SC_Name { get; set; }

        public string IO_Type { get; set; }

        public DateTime RegDate { get; set; }
    }
}
