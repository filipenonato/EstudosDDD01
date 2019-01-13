namespace MyStore.Infrastructure.Transaction
{
    public interface IUnityOfWork
    {
        void Commit();

        void Rollback();
    }
}
