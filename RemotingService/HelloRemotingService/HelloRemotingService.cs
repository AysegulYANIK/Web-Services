using System;
using RemotingService;

namespace HelloRemotingService
{
    public class HelloRemotingService : MarshalByRefObject, RemotingService.RemotingService
    {
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }

        //After implementation you need to host a remoting service. IIS,IIS Express are options to host. In this project we will host in a console.
    }
}
