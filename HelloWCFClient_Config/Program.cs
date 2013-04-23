using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWCFClient_Config
{
    class Program
    {
        static void Main(string[] args)
        {
            string strRes = "";
            //建立一个客户端代理类,名字以服务名+Client来命名
            MyService.HelloWCFServiceClient client = new MyService.HelloWCFServiceClient();
            try
            {
                Console.WriteLine("正在调用WCF服务…………");
                //使用client对象调用服务中公开的操作
                strRes = client.HelloWCF();
                Console.WriteLine(strRes);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                //关闭代理
                client.Close();
            }
        }
    }
}
