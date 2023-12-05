using Application.Services;
using Domain.Entities;
using System.Drawing;

namespace Application.Models.ModelsOfAnswer
{
    public class AnswerModel
    {
        public string IdMember { get; set; }
        public DateTime DateAnswer { get; set; }
        public DateTime DateUpdateAnswer { get; set; }
        public string? Content { get; set; }
        public string? LinkFile { get; set; }
        public float? Point { get; set; }
        public AnswerModel()
        {
            
        }
        public AnswerModel(Answer answer)
        {
            IdMember = answer.IdMember;
            DateUpdateAnswer = answer.DateUpdateAnswer;
            DateAnswer = answer.DateAnswer;
            Content = answer.Content;
            Point = answer.Point;
            LinkFile = $"{answer.LinkFile}/doc/{answer.FileName}";
        }
    }
}
