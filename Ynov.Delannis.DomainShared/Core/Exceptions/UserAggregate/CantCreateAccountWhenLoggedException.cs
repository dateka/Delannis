namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class CantCreateAccountWhenLoggedException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.CantCreateAccountWhenLoggedException;
    }
}