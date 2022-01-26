using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ynov.Delannis.UnitTest.Commons
{
    public class UnitTestFixture : IClassFixture<UnitTestConfiguration>
    {
        public UnitTestConfiguration UnitTestConf { get; set; }
        
        public UnitTestFixture(UnitTestConfiguration unitTestConf)
        {
            this.UnitTestConf = unitTestConf;
        }

        protected virtual Task InitFixtureAsync()
        {
            UnitTestConf.Configure();

            return Task.CompletedTask;
        }

        protected T GetImplementationFromService<T>()
        {
            return UnitTestConf.ServiceProvider.GetService<T>() ?? throw new InvalidOperationException();
        }
    }
}