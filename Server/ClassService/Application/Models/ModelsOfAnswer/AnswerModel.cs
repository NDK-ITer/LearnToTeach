using Application.Services;
using Domain.Entities;

namespace Application.Models.ModelsOfAnswer
{
    public class AnswerModel
    {
        public string IdMember { get; set; }
        public DateTime DateAnswer { get; set; }
        public string? Content { get; set; }
        public string? LinkFile { get; set; }
        public AnswerModel()
        {
            
        }
        public AnswerModel(Answer answer)
        {
            IdMember = answer.IdMember;
            DateAnswer = answer.DateAnswer;
            Content = answer.Content;
            LinkFile = $"{answer.LinkFile}/{answer.FileName}";
        }
    }
}
