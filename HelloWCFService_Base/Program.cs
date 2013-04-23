using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HelloWCFService_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            //3、建立一个Uri对象,作为基地址传送给ServiceHost
            //localhost 表示本机，8000是端口(不能保留端口冲突)，MyService哦服务地址(随便起)，可与服务实现类名相同，他们没有联系！
            Uri baseAddress = new Uri("http://localhost:8000/MyService");
            //4、建立一个ServiceHost对象
            //注意:第一个参数是HelloWCFService类，而不是IHelloWCFService接口，由此看出，服务的本体是服务实现类，而非协定接口，毕竟实实在在的逻辑在实现类里面，我们要寄宿的是它
            ServiceHost host = new ServiceHost(typeof(HelloWCFService), baseAddress);
            //5、为服务添加一个终结点
            //第一个参数指定了服务协定，注意这里是协定接口类型，一个服务实现类可能实现多个服务协定接口，这样每个服务协定接口都有一个终结点与之对应了。
            //第二个参数定义了绑定，即客户端与服务端沟通的方式，这里指定了一个WSHttpBinding的实例
            //第三个参数是终结点的地址。这里给了一个相对地址，终结点的最终地址将会把这个相对地址与基地址组合,形如：http://localhost:8000/MyService/HelloWCFService  
            host.AddServiceEndpoint(typeof(IHelloWCFService), new WSHttpBinding(), "HelloWCFService");
            //6、建立一个服务元数据行为对象
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;//启用元数据交换行为。设置HttpGetEnabled属性,设为true ，客户端就可用HTTP GET的方法从服务端下载元数据了。
            host.Description.Behaviors.Add(smb);//把这个服务元数据行为对象添加到宿主ServiceHost对象的行为集合中去
            //7、启动宿主，开始服务
            host.Open();

            Console.WriteLine("Service is Ready");
            Console.WriteLine("Press Any Key to Terminated...");
            Console.ReadLine(); 

            //8、关闭宿主
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
            return "Hello WCF!";
        }
    }  
}
