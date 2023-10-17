﻿using Application.Services;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GenerateCancelAddClassroomConsumer : IConsumer<ICancelAddClassroomEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateCancelAddClassroomConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<ICancelAddClassroomEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                unitOfWork_ClassroomService._classroomService.DeleteClassroom(data.idClassroom.ToString());
            }
        }
    }
}
