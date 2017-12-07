using Akka.Actor;
using Common;
using System;

namespace API.Client
{
    class Program
    {
        internal static ActorSystem System;

        internal static SystemActors ApiClient;

        static void Main(string[] args)
        {
            System = AkkaConfig.CreateActorSystem();
            ApiClient = new SystemActors(System);
            System.WhenTerminated.Wait();
        }
    }
}
