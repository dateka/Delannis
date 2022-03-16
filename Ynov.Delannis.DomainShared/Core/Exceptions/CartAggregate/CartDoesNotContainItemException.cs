namespace Ynov.Delannis.DomainShared.Core.Exceptions.CartAggregate
{
    public class CartDoesNotContainItemException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.CartDoesNotContainItemException;
    }
}