namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class UserNotFoundException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.UserNotFoundException;
    }
}