using Application.Models;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public interface IClassroomInforService
    {
        int AddClassroomInfor(AddClassroomInforModel addClassroomInforModel);
        int UpdateClassroomInfor(UpdateClassroomInforModel updateClassroomInforModel);
        int DeleteClassroomInfor(string idUser, string idClassroom);
        int DeleteClassroomInfor(string idClassroom);
        ClassroomInfor GetClassroomInfor(string idUser, string idClassroom);
        List<ClassroomInfor> GetClassroomInfor(string idClassroom);
    }
    public class ClassroomInforService : IClassroomInforService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassroomInforService(UserServiceDbContext context, IMemoryCache cache)
        {
            _unitOfWork = new UnitOfWork(context, cache);
        }

        public int AddClassroomInfor(AddClassroomInforModel addClassroomInforModel)
        {
            try
            {
                if (addClassroomInforModel == null) return 0;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == addClassroomInforModel.IdClassroom).FirstOrDefault();
                var classroomInfor = new ClassroomInfor()
                {
                    IdClassroom = addClassroomInforModel.IdClassroom,
                    IdUser = addClassroomInforModel.IdUser,
                    Name = "",
                    Description = "",
                    IsHost = false
                };
                if (classroom != null)//add member
                {
                    classroomInfor.Name = classroom.Name;
                    classroomInfor.Description = classroom.Description;
                }
                else//add new classroom
                {
                    if (!addClassroomInforModel.Name.IsNullOrEmpty()) classroomInfor.Name = addClassroomInforModel.Name;
                    if (!addClassroomInforModel.Description.IsNullOrEmpty()) classroomInfor.Description = addClassroomInforModel.Description;
                    classroomInfor.IsHost = true;
                }
                _unitOfWork.classroomRepository.Add(classroomInfor);
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int DeleteClassroomInfor(string idUser, string idClassroom)
        {
            try
            {
                if (idUser.IsNullOrEmpty() && idClassroom.IsNullOrEmpty()) return 0;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == idClassroom && p.IdUser == idUser).FirstOrDefault();
                if (classroom != null)
                {
                    _unitOfWork.classroomRepository.Remove(classroom);
                    _unitOfWork.SaveChange();
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int DeleteClassroomInfor(string idClassroom)
        {
            try
            {
                if (!idClassroom.IsNullOrEmpty()) return 0;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == idClassroom);
                if (classroom != null)
                {
                    _unitOfWork.classroomRepository.RemoveRange(classroom);
                    _unitOfWork.SaveChange();
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public ClassroomInfor? GetClassroomInfor(string idUser, string idClassroom)
        {
            try
            {
                if (idUser.IsNullOrEmpty() && idClassroom.IsNullOrEmpty()) return null;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == idClassroom && p.IdUser == idUser).FirstOrDefault();
                if (classroom != null) return classroom;
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ClassroomInfor>? GetClassroomInfor(string idClassroom)
        {
            try
            {
                if (idClassroom.IsNullOrEmpty()) return null;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == idClassroom);
                if (classroom != null) return classroom;
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public int UpdateClassroomInfor(UpdateClassroomInforModel updateClassroomInforModel)
        {
            try
            {
                if (updateClassroomInforModel == null) return 0;
                var classroom = _unitOfWork.classroomRepository.GetClassroomInfor(p => p.IdClassroom == updateClassroomInforModel.IdClassroom);
                foreach (var item in classroom)
                {
                    item.Description = updateClassroomInforModel.Description;
                    item.Name = updateClassroomInforModel.Name;
                    _unitOfWork.classroomRepository.UpdateClassroomInfor(item);
                };
                _unitOfWork.SaveChange();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
