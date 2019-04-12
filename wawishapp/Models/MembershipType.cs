﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wawishapp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string MembershipName { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}