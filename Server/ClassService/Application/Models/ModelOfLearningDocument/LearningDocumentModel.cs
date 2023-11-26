using Domain.Entities;

namespace Application.Models.ModelOfLearningDocument
{
    public class LearningDocumentModel
    {
        public string NameFile { get; set; }//primary key
        public string Description { get; set; }
        public string LinkFile { get; set; }

        public LearningDocumentModel()
        {
                
        }
        public LearningDocumentModel(LearningDocument learningDocument)
        {
            NameFile = learningDocument.NameFile;
            Description = learningDocument.Description;
            LinkFile = learningDocument.LinkFile;
        }
    }
}
