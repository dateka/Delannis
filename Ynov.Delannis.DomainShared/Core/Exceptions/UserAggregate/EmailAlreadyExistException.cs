namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class EmailAlreadyExistException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.EmailAlreadyExistException;
    }
}