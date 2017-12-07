namespace API.ActorModel
{
    using Akka.Actor;
    using API.ActorModel.Commands;
    using System;

    namespace SM.TaskEngine.Api.ActorModel
    {

        public interface ITest
        {

        }

        public class Test : ITest {

}

        public class ApiMaster : ReceiveActor
        {
            IActorRef _userActor;

            public ApiMaster(ITest test)
            {
                Executing();
            }



            private void Executing()
            {
                Receive<string>(c => {
                    Console.WriteLine($"{Self.Path.Name} {c}");
                });


                Receive<GetUser>(c => {
                    Console.WriteLine($"{Self.Path.Name} {c}");
                });


            }



        }
    }

}
