using System;

namespace Ynov.Delannis.DomainShared.Core.Exceptions
{
    public abstract class DomainExceptionBase : Exception
    {
        public virtual string ErrorCode => ExceptionErrorCodes.DomainExceptionBase;
    }
}