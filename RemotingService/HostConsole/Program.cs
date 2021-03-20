using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace HostConsole
{
    class Program
    {
        static void Main()
        {
            RemotingService_hello.HelloRemotingservice remotingService = new RemotingService_hello.HelloRemotingservice();
            TcpChannel channel = new TcpChannel(8080);

            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingService_hello.HelloRemotingservice), "GetMessage" , WellKnownObjectMode.Singleton ) ;
            Console.WriteLine("Remoted service started @ "+ DateTime.Now);
            Console.ReadLine();
        }
    }
}
