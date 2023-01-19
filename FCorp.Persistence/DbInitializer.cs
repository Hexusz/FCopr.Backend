﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCorp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(FCorpDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
