using Akka.Actor;
using Akka.Routing;
using API.ActorModel.Commands;
using API.ActorModel.SM.TaskEngine.Api.ActorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Client
{
    class SystemActors
    {
        ActorSystem _system;

        public IActorRef _api { get; }

        public SystemActors(ActorSystem system)
        {
            _system = system;

            _api = _system.ActorOf(Props.Create(() => new ApiMaster()).WithRouter(FromConfig.Instance), "taskApi");

            /*
            _system.Scheduler.Advanced.ScheduleRepeatedly(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), () =>
            {
                if (_api.Ask<Routees>(new GetRoutees()).Result.Members.Any())
                {
                    _api.Tell("ping", null);
                }

            });*/
        }


        public Task<UserResponse> GetUser(string email)
        {
            return _api.Ask<UserResponse>(new GetUser(email));
        }

    }
}
