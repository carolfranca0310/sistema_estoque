namespace InventoryManagement.Domain.Exceptions
{
    public class InvalidProductInfoException : Exception
    {
        public InvalidProductInfoException()
        {

        }

        public InvalidProductInfoException(string message) : base(message)
        {

        }
    }
}
