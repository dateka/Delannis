namespace Ynov.Delannis.DomainShared.Core.Exceptions.ProductAggregate
{
    public class NotEnoughtStockException : DomainExceptionBase
    {
        public override string ErrorCode => ExceptionErrorCodes.NotEnoughtStockException;
    }
}