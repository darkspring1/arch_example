namespace API.ActorModel
{
    using Akka.Actor;
    using API.ActorModel.Commands;
    using Domain.Model;
    using Domain.Persistent;
    using StructureMap;
    using System;

    namespace SM.TaskEngine.Api.ActorModel
    {

 
        public class ApiMaster : ReceiveActor
        {
            IActorRef _userActor;

            IContainer _container;

            public ApiMaster()
            {

                _container = Program.Container.GetNestedContainer();

                Executing();
            }


            T Resolve<T>()
            {
                return _container.GetInstance<T>();
            }


            private void Executing()
            {
                Receive<string>(c => {
                    Console.WriteLine($"{Self.Path.Name} {c}");
                });


                Receive<GetUser>(cmd => {
                    Console.WriteLine($"{Self.Path.Name} {cmd}");
                    var unitOfWork = Resolve<IUnitOfWork>();
                    unitOfWork.UserRepository.FindAsync(cmd.Email)
                    .ContinueWith(t => new UserResponse(t.Result.UserName))
                    .PipeTo(this.Sender);
                });


            }


            protected override void PostStop()
            {
                try
                {
                    _container.Dispose();
                }
                finally
                {
                    base.PostStop();
                }
            }





        }
    }

}
