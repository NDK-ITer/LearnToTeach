﻿using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Classroom;
using Events.ClassroomServiceEvents.Classroom.AddClassroom;
using MassTransit;
using UserServer.Models;
using XAct.Messages;

namespace UserServer.Consumers
{
    public class ConsumeValueClassroomConsumer : IConsumer<IConsumeValueClassroomEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;
        private readonly UserEventMessage userEventMessage;

        public ConsumeValueClassroomConsumer(IUnitOfWork_UserService unitOfWork_UserService, UserEventMessage userEventMessage)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
            this.userEventMessage = userEventMessage;
        }
        public async Task Consume(ConsumeContext<IConsumeValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                if (data.eventMessage == userEventMessage.Create)
                {
                    var user = unitOfWork_UserService.UserService.GetUserById(data.idUserHost);
                    if (user == null)
                    {
                        await context.Publish<ICancelAddClassroomEvent>(new
                        {
                            idMessage = data.idMessage,
                            idClassroom = data.idClassroom,
                            description = data.description,
                            idUserHost = data.idUserHost,
                            name = data.name,
                            isPrivate = data.isPrivate,
                        });
                    }
                    else
                    {
                        var classroomInfor = new AddClassroomInforModel()
                        {
                            IdClassroom = data.idClassroom,
                            IdUser = data.idUserHost,
                            Description = data.description,
                            NameClassroom = data.name
                        };
                        unitOfWork_UserService.ClassroomInforService.AddClassroomInfor(classroomInfor);
                        await context.Publish<IAddClassroomIsValidEvent>(new
                        {
                            idMessage = data.idMessage,
                            idClassroom = data.idClassroom,
                            idUserHost = data.idUserHost,
                            nameUserHost = $"{user.FirstName} {user.LastName}",
                            avatarMember = user.Avatar,
                            linkAvatar = user.LinkAvatar,
                        });
                    }
                }
                else if (data.eventMessage == userEventMessage.Update)
                {
                    var updateClassroomInforModel = new UpdateClassroomInforModel()
                    {
                        IdClassroom = data.idClassroom,
                        Description = data.description,
                        LinkAvatar = data.linkAvatar,
                        Avatar = data.avatar,
                        Name = data.name
                    };
                    unitOfWork_UserService.ClassroomInforService.UpdateClassroomInfor(updateClassroomInforModel);
                }
                else if (data.eventMessage == userEventMessage.Delete)
                {
                    var classroomInfor = unitOfWork_UserService.ClassroomInforService.DeleteClassroomInfor(data.idClassroom.ToString());
                    if (classroomInfor == 1)
                    {
                        await context.Publish<IRemoveClassroomIsValidEvent>(new
                        {
                            IdClassroom = data.idClassroom,
                        });
                    }
                }
            }
        }
    }
}
