HelloWCFService.svc文件说明：

<%%>:表示这个是一个服务器端包含
@ServiceHost:标签表示这是个WCF的服务（ServiceHost 对象）
language=c#:表示我们用C#语言来写代码，
Debug=true:顾名思义了
Service:它表示这个服务的实现类是什么，这里要用完全限定名，即要包括命名空间HelloWCFService_IIS，我们把服务定义都放在这个命名空间下，后面的HelloWCFService就是服务的实现类了

=======================================
在测试及调试的时候一直在VS环境右键浏览去访问WCF服务，没有问题。
后来把服务寄宿到IIS，就把服务移到IIS上的默认站点下面。
接着问题就来了，当我访问svc页面的时候，竟然是提示404错误。

用cmd进入到C:\Windows\Microsoft.NET\Framework\v3.0\Windows Communication Foundation，
用ServiceModelReg重新注册，敲上ServiceModelReg -r。
这样一来，2.0的服务将来被重新引用。
========================================
505错误
将C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe 注册一下
