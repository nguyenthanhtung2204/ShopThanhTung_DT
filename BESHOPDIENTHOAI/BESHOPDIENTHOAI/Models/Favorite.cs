﻿using System;
using System.Collections.Generic;

namespace BESHOPDIENTHOAI.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdProduct { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
