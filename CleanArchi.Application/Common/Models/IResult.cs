namespace CleanArchi.Application.Common.Models
{
    public interface IResult
    {
        string[] Errors { get; init; }
        bool Succeeded { get; init; }
    }
}