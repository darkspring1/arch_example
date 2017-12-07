namespace API.ActorModel.Commands
{
    public class UserResponse
    {
        public UserResponse(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
