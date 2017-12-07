using Akka.Actor;
using Akka.Routing;
using API.ActorModel.SM.TaskEngine.Api.ActorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Client
{
    class SystemActors
    {
        ActorSystem _system;

        public IActorRef api { get; }

        public SystemActors(ActorSystem system)
        {
            _system = system;

            api = _system.ActorOf(Props.Create(() => new ApiMaster()).WithRouter(FromConfig.Instance), "taskApi");


            //var printer = _system.ActorOf<Printer>();

            _system.Scheduler.Advanced.ScheduleRepeatedly(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), () =>
            {
                //api.Tell("ping", printer);

                if (api.Ask<Routees>(new GetRoutees()).Result.Members.Any())
                {
                    api.Tell("ping", null);
                }

            });

            //_system.WhenTerminated.Wait();
        }


        public Task<>
    }
}
