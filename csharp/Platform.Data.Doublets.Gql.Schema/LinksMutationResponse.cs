﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data.Doublets.Gql.Schema
{
    class LinksMutationResponse
    {
        public int affected_rows { get; set; }

        public IList<Link> returning { get; set; }
    }
}
