using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer
{
    public interface ICacheType
    {
        int Id { get; set; }

        string Description { get; set; }

        int Active { get; set; }


    }
}
