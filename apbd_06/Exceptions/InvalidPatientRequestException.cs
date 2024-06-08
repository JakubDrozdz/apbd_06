namespace apbd_06.Exceptions;

public class InvalidPatientRequestException : Exception
{
    public InvalidPatientRequestException(string? message) : base(message)
    {
    }
}