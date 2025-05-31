using ServiceLayer.IServices;

namespace ServiceLayer
{
    public class EmployeeDI : ITransient, IScope, ISingleton
    {
        Guid id;

        public EmployeeDI()
        {
            id = Guid.NewGuid();
        }

        public Guid GetOperationId()
        {
            return id;

        }
    }
}