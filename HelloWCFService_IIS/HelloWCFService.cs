using System;
using System.Collections.Generic;
using System.Web;
using System.ServiceModel;
namespace HelloWCFService_IIS
{
    [ServiceContract]
    public interface IHelloWCFService
    {
        [OperationContract]
        string HelloWCF();
    }
    public class HelloWCFService : IHelloWCFService
    {
        public string HelloWCF()
        {
            return "IIS中寄存WCF服务--Hello WCF! ";
        }
    }
}