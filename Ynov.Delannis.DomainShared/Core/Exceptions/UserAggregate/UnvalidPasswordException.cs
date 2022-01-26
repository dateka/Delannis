namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class UnvalidPasswordException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.UnvalidPasswordException;
    }
}