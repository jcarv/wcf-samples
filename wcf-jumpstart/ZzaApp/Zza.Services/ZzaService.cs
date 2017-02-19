using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using Zza.Entities;

namespace Zza.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class ZzaService : IZzaService, IDisposable
    {
        readonly ZzaDbContext _context = new ZzaDbContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [OperationBehavior(TransactionScopeRequired=true)]
        public void SubmitOrder(Order order)
        {
            _context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _context.OrderItems.Add(oi));
            _context.SaveChanges();
        }
    }
}
