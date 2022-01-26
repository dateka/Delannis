namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class UnvalidUsernameException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.UnvalidUsernameException;
    }
}