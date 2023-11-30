using Application.Models.ModelOfLearningDocument;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services
{
    public interface ILearningDocumentService
    {
        Tuple<string, LearningDocument> AddLearningDocument(AddLearningDocumentModel addDocument);
        Tuple<string, LearningDocument> UpdateLearningDocument(UpdateLearningDocumentModel updateDocument);
        Tuple<bool, string> DeleteLearningDocument(string nameFile);
    }
    public class LearningDocumentService : ILearningDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LearningDocumentService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }

        public Tuple<string, LearningDocument?>? AddLearningDocument(AddLearningDocumentModel addDocument)
        {
            try
            {
                if (addDocument != null)
                {
                    var check = _unitOfWork.learningDocumentRepository.GetById(addDocument.NameFile);
                    if (check == null)
                    {
                        var addModel = new LearningDocument()
                        {
                            NameFile = addDocument.NameFile,
                            Description = addDocument.Description,
                            LinkFile = addDocument.LinkFile + "/doc/"+addDocument.NameFile,
                            IdClassroom = addDocument.IdClassroom
                        };
                        _unitOfWork.learningDocumentRepository.Add(addModel);
                        _unitOfWork.SaveChange();
                        return new Tuple<string, LearningDocument?>("add Successful",addModel);
                    }
                    return new Tuple<string, LearningDocument?>("this document has availeble", null);
                }
                return new Tuple<string, LearningDocument?>("parameter is null", null);
            }
            catch (Exception e)
            {

                return new Tuple<string, LearningDocument?>(e.Message, null);
            }
        }

        public Tuple<bool, string> DeleteLearningDocument(string nameFile)
        {
            try
            {
                var check = _unitOfWork.learningDocumentRepository.GetById(nameFile);
                if (check != null)
                {
                    _unitOfWork.learningDocumentRepository.Remove(check);
                    _unitOfWork.SaveChange();
                    return new Tuple<bool, string>(true, "delete successful");
                }
                return new Tuple<bool, string>(false, "not found this document");
            }
            catch (Exception e)
            {

                return new Tuple<bool, string>(false, e.Message);
            }
        }

        public Tuple<string, LearningDocument?>? UpdateLearningDocument(UpdateLearningDocumentModel updateDocument)
        {
            try
            {
                if (updateDocument != null)
                {
                    var check = _unitOfWork.learningDocumentRepository.GetById(updateDocument.NameFile);
                    if (check != null)
                    {
                        check.Description = updateDocument.Description;
                        _unitOfWork.learningDocumentRepository.Update(check);
                        _unitOfWork.SaveChange();
                        return new Tuple<string, LearningDocument?>("update Successful", check);
                    }
                    return new Tuple<string, LearningDocument?>("this document has availeble", null);
                }
                return new Tuple<string, LearningDocument?>("parameter is null", null);
            }
            catch (Exception e)
            {
                return new Tuple<string, LearningDocument?>(e.Message, null);
            }
        }
    }
}
