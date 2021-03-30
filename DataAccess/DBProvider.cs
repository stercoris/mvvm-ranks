using Microsoft.EntityFrameworkCore;

namespace Order.DataAccess
{
    public static class DBProvider
    {
        private static OrderContext _dbcontext { get; set; }

        public static OrderContext DBContext
        {
            get
            {
                if (_dbcontext == null)
                {
                    _dbcontext = new OrderContext(new DbContextOptions<OrderContext>());
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        //FakeDataLoader.Load(_dbcontext);
                    }
                }

                return (_dbcontext);
            }
        }
    }
}
