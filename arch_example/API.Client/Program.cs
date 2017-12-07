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

            System.Scheduler.Advanced.ScheduleRepeatedly(TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(5), () =>
            {
                ApiClient.GetUser("olt.egor@gmail.com")
                .ContinueWith(t => Console.WriteLine(t.Result.Name));
            });

            System.WhenTerminated.Wait();
        }
    }
}
