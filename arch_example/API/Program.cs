using Akka.Actor;
using Common;
using System;

namespace API
{
    class Program
    {
        internal static ActorSystem System;

        static void Main(string[] args)
        {
            System = AkkaConfig.CreateActorSystem();
            System.WhenTerminated.Wait();
        }
    }
}
