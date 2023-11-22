using Application.Models;
using Application.Services;
using Events.UserServiceEvents.User;
using MassTransit;

namespace UserServer.Consumers.UploadFile
{
    public class GenerateUploadFileIsValidConsumer : IConsumer<IUserServiceUploadIsValid>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;

        public GenerateUploadFileIsValidConsumer(IUnitOfWork_UserService unitOfWork_UserService)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
        }
        public async Task Consume(ConsumeContext<IUserServiceUploadIsValid> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var userUpdate = new UpdateUserModel()
                {
                    IdUser = data.IdUser,
                    LinkAvatar = data.LinkImage,
                    Avatar = data.NameImage
                };
                var updateUserCheck = unitOfWork_UserService.UserService.UpdateUser(userUpdate);
            }
        }
    }
}
