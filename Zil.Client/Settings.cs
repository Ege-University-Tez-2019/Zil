using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zil.Client
{
    public class Settings
    {
        public static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions()); 

    }
}
