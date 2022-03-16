using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Ynov.Delannis.DomainShared.Core.Exceptions;

namespace Ynov.Delannis.Specs.Drivers
{
    public class ErrorDriver
    {
        private readonly Queue<DomainExceptionBase> _exceptions = new Queue<DomainExceptionBase>();

        public void TryExecute(Action act)
        {
            try
            {
                act();
            }
            catch (DomainExceptionBase ex)
            {
                Trace.WriteLine($"The following exception was caught while executing {act.Method.Name}: {ex}");
                _exceptions.Enqueue(ex);
            }
        }

        public async Task TryExecuteAsync(Func<Task> act)
        {
            try
            {
                await act().ConfigureAwait(false);
            }
            catch (DomainExceptionBase ex)
            {
                Trace.WriteLine($"The following exception was caught while executing {act.Method.Name}: {ex}");
                _exceptions.Enqueue(ex);
            }
        }
        
        public async Task<T> TryExecuteAsync<T>(Func<Task<T>> act)
        {
            try
            {
                return await act().ConfigureAwait(false);
            }
            catch (DomainExceptionBase ex){
                Trace.WriteLine($"The following exception was caught while executing {act.Method.Name}: {ex}");
                _exceptions.Enqueue(ex);
            }

            return default;
        }

        public void AssertExceptionWasRaisedWithMessage(string expectedErrorType)
        {
            _exceptions.Any().Should()
                .BeTrue($"No exception was raised but expected exception for type: {expectedErrorType}Exception");
            DomainExceptionBase actualException = _exceptions.Dequeue();

            actualException.ErrorCode.Should().Be($"{expectedErrorType}Exception");
        }

        public void AssertNoUnexpectedExceptionsRaised()
        {
            if (_exceptions.Any())
            {
                Exception unexpectedException = _exceptions.Dequeue();
                unexpectedException.Should().BeNull($"No exception was expected to be raised but found exception: {unexpectedException}");
            }
        }
    }
}