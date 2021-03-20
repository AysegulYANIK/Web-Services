using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingService_hello
{
    public class HelloRemotingservice : MarshalByRefObject, RemotingClassLibrary.RemotingService
    {
        //remotable : another application can be able to call this object
        //to provide a class be remotable >> way1. decorate the class with Serializable Attributes, way2. make the class inherit from MarshalByRef object class

        public string GetMessage(string name)
        {
            return "Hello " + name;
        }

    }
}
