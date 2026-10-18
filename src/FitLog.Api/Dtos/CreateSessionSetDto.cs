namespace FitLog.Api.Dtos;

public class CreateSessionSetDto
{
    public int SetNumber { get; set; }
    public decimal Weight { get; set; }
    public int RepetitionCount { get; set; }
}