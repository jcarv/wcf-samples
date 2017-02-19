using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;

namespace Zza.Services
{
    [ServiceContract]
    public interface IZzaService
    {
        List<Product> GetProducts();
        List<Customer> GetCustomers();
        void SubmitOrder(Order order);
    }
}
