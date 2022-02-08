namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class CantLogAccountWhenLoggedException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.CantLogAccountWhenLoggedException;
    }
}