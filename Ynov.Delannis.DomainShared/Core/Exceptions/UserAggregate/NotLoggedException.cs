namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class NotLoggedException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.NotLoggedException;
    }
}