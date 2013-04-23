using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace HelloWCFService_Config
{
    class Program
    {
        /// <summary>
        /// 使用配置文件配置WCF
        /// </summary>
        static void Main(string[] args)
        {
            //3、建立一个ServiceHost对象
            ServiceHost host = new ServiceHost(typeof(HelloWCFService));
            host.Open();

            Console.WriteLine("Service is Ready");
            Console.WriteLine("Press Any Key to Terminated...");
            Console.ReadLine();

            //、关闭宿主
            host.Close();
        }
    }
    /*=============================================================================================
    * 我们把服务协定表示为一个接口，然后用一个类去实现这个接口，实现这个接口的类就叫做服务类了。
    * 这个接口和这个类共同描述了一个服务。
    * 编写接口的过程叫做创建服务协定，编写实现接口的类叫做实现服务协定
    *=============================================================================================*/
    /// <summary>
    /// 1、创建一个服务协定(接口)
    /// </summary>
    [ServiceContract]//表示该接口是一个服务协定
    interface IHelloWCFService
    {
        [OperationContract]//表示该方法是一个操作协定
        string HelloWCF();
    }
    /// <summary>
    ///2、 实现一个服务协定(服务类)
    /// </summary>
    public class HelloWCFService : IHelloWCFService
    {
        public string HelloWCF()
        {
            return "使用配置文件配置WCF!  Hello WCF";
        }
    }  
}
