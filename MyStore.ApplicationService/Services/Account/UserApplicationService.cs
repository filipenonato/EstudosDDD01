using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infrastructure.Transaction;

namespace MyStore.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnityOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Username, command.Password);

            user.Register();

            if(Commit())
            {
                DomainEvent.Raise(new OnUserRegisteredEvent(user));

                return user;
            }

            return null;
        }
    }
}
