using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Persistence;

namespace FCopr.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly FCorpDbContext Context;

        public TestCommandBase()
        {
            Context = OrdersContextFactory.Create();
        }

        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }
}