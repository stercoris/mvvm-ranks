using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Order.DataAccess
{
    //TODO: КАКАЯ ЖЕ ПАРАША ПЕРЕДЕЛАЙ НАДО ПЕРЕДЕЛАТЬ
    //TODO: КАКАЯ ЖЕ ПАРАША ПЕРЕДЕЛАЙ НАДО ПЕРЕДЕЛАТЬ
    //TODO: КАКАЯ ЖЕ ПАРАША ПЕРЕДЕЛАЙ НАДО ПЕРЕДЕЛАТЬ
    //TODO: КАКАЯ ЖЕ ПАРАША ПЕРЕДЕЛАЙ НАДО ПЕРЕДЕЛАТЬ
    //TODO: КАКАЯ ЖЕ ПАРАША ПЕРЕДЕЛАЙ НАДО ПЕРЕДЕЛАТЬ
    public static class DBProvider
    {
        private static OrderContext _dbcontext { get; set; }

        public static OrderContext DBContext // Global context 
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

        public static OrderContext DBLocalContext { 
            get => new OrderContext(new DbContextOptions<OrderContext>()); 
        } // Local context with using

    }
}
