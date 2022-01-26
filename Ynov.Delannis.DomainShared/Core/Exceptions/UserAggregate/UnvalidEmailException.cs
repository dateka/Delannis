namespace Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate
{
    public class UnvalidEmailException : DomainExceptionBase    
    {
        public override string ErrorCode => ExceptionErrorCodes.UnvalidEmailException;
    }
}