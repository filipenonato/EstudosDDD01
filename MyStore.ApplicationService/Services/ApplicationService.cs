using DomainNotificationHelper;
using DomainNotificationHelper.Events;
using MyStore.Infrastructure.Transaction;

namespace MyStore.ApplicationService.Services
{
    public class ApplicationService
    {
        private readonly IHandler<DomainNotification> _notifications;
        private readonly IUnityOfWork _unitOfWork;

        public ApplicationService(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }
        
        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            DomainEvent.Raise<DomainNotification>(new DomainNotification("BusinessError", message));
            _unitOfWork.Rollback();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
