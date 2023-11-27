using Application.Models.ModelOfNotifyClassroom;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using XAct;

namespace Application.Services
{
    public interface INotifyClassroomService
    {
        Tuple<string, NotifyClassroom?> Add(AddNotifyClassroomModel notifyClassroom);
        Tuple<string, NotifyClassroom?> Update(UpdateNotifyClassroomModel notifyClassroom);
        Tuple<bool, string> Delete(string idNotify);
    }
    public class NotifyClassroomService : INotifyClassroomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotifyClassroomService(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _unitOfWork = new UnitOfWork(context, memoryCache);
        }

        public Tuple<string, NotifyClassroom?> Add(AddNotifyClassroomModel notifyClassroom)
        {
            try
            {
                if (notifyClassroom == null || notifyClassroom.IdClassroom.IsNullOrEmpty()) { return new Tuple<string, NotifyClassroom?>("parameter is null", null); }
                if (notifyClassroom.NameNotify.IsNullOrEmpty() || notifyClassroom.Description.IsNullOrEmpty()) return new Tuple<string, NotifyClassroom?>("nothing to add", null);
                var addNotify = new NotifyClassroom()
                {
                    IdNotify = Convert.ToBase64String((notifyClassroom.IdClassroom + DateTime.Now).ToString().ToByteArray()).Substring(0, 30),
                    NameNotify = notifyClassroom.NameNotify,
                    Description = notifyClassroom.Description,
                    IdClassroom = notifyClassroom.IdClassroom,
                    CreateDate = DateTime.Now,
                };
                _unitOfWork.notifyClassroomRepository.Add(addNotify);
                _unitOfWork.SaveChange();
                return new Tuple<string, NotifyClassroom?>("Successful",addNotify);
            }
            catch (Exception e)
            {
                return new Tuple<string, NotifyClassroom?>(e.Message, null);
            }
        }

        public Tuple<bool, string> Delete(string idNotify)
        {
            try
            {
                if (idNotify.IsNullOrEmpty()) return new Tuple<bool, string>(false, "parameter is null");
                var deleteNotify = _unitOfWork.notifyClassroomRepository.GetById(idNotify);
                if (deleteNotify == null) { return new Tuple<bool, string>(false,"not found this notify"); }
                _unitOfWork.notifyClassroomRepository.Remove(deleteNotify);
                _unitOfWork.SaveChange();
                return new Tuple<bool, string>(true, "Successful");
            }
            catch (Exception e)
            {

                return new Tuple<bool, string>(false, e.Message);
            }
        }

        public Tuple<string, NotifyClassroom?> Update(UpdateNotifyClassroomModel notifyClassroom)
        {
            try
            {
                try
                {
                    if (notifyClassroom == null || notifyClassroom.IdNotify.IsNullOrEmpty()) { return new Tuple<string, NotifyClassroom?>("parameter is null", null); }
                    if (notifyClassroom.NameNotify.IsNullOrEmpty() || notifyClassroom.Description.IsNullOrEmpty()) return new Tuple<string, NotifyClassroom?>("nothing to update", null);
                    var updateNotify = _unitOfWork.notifyClassroomRepository.GetById(notifyClassroom.IdNotify);
                    if (updateNotify == null) { return new Tuple<string, NotifyClassroom?>("not found this notify", null); }
                    updateNotify.NameNotify = notifyClassroom.NameNotify;
                    updateNotify.Description = notifyClassroom.Description;
                    _unitOfWork.notifyClassroomRepository.Update(updateNotify);
                    _unitOfWork.SaveChange();
                    return new Tuple<string, NotifyClassroom?>("Successful", updateNotify);
                }
                catch (Exception e)
                {
                    return new Tuple<string, NotifyClassroom?>(e.Message, null);
                }
            }
            catch (Exception e)
            {

                return new Tuple<string, NotifyClassroom?>(e.Message, null);
            }
        }
    }
}
