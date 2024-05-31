namespace apbd_06.Exceptions;

public class InvalidPrescriptionRequestException : Exception
{
    public InvalidPrescriptionRequestException(string? message) : base(message)
    {
    }
}