using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TrashIT.Models
{
    public class LazyEntity
    {
        protected ILazyLoader lazyLoader;

        public LazyEntity() { }

        public LazyEntity(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
    }
}
