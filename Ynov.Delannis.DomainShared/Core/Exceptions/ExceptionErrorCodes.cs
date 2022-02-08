namespace Ynov.Delannis.DomainShared.Core.Exceptions
{
    public class ExceptionErrorCodes
    {
        public const string DomainExceptionBase = nameof(DomainExceptionBase);
        public const string CantCreateAccountWhenLoggedException = nameof(CantCreateAccountWhenLoggedException);
        public const string EmailAlreadyExistException = nameof(EmailAlreadyExistException);
        public const string UserNameAlreadyExistException = nameof(UserNameAlreadyExistException);
        public const string UnvalidPasswordException = nameof(UnvalidPasswordException);
        public const string UnvalidUsernameException = nameof(UnvalidUsernameException);
        public const string UnvalidEmailException = nameof(UnvalidEmailException);
        public const string CantLogAccountWhenLoggedException = nameof(CantLogAccountWhenLoggedException);
        public const string UserNotFoundException = nameof(UserNotFoundException);
    }
}