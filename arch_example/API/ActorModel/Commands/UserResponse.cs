

namespace API.ActorModel.Commands
{
    public class GetUser
    {
        public GetUser(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
