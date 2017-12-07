using Akka.Actor;
using API.Ioc;
using Common;
using StructureMap;

namespace API
{
    class Program
    {
        internal static ActorSystem System;

        internal static IContainer Container;

        static void Main(string[] args)
        {
            Container = new Container(new ApiRegistry());
            System = AkkaConfig.CreateActorSystem();
            System.WhenTerminated.Wait();
        }
    }
}
