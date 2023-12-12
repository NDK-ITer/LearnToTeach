using Domain.Entities;

namespace Application.Models.ModelsOfExercise
{
    public class ElementPoint
    {
        public string NameMember { get; set; }
        public string Email { get; set; }
        public float? Point { get; set; }
        public ElementPoint(Answer anw)
        {
            NameMember = anw.Member.Name;
            Email = anw.Member.Email;
            Point = anw.Point;
        }
    }
    public class PointExerciseModel
    {
        public string NameExercise { get; set;}
        public List<ElementPoint> ListPoint { get; set; } = new List<ElementPoint>();
        public PointExerciseModel(Exercise exc)
        {
            NameExercise = exc.Name;
            foreach (var item in exc.ListAnswer)
            {
                ListPoint.Add(new ElementPoint(item));
            }
        }
    }
}
