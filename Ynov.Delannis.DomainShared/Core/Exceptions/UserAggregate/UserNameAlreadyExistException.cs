namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class UserNameAlreadyExistException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.UserNameAlreadyExistException;
    }
}