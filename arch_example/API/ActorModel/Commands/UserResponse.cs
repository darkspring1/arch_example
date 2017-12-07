

namespace API.ActorModel.Commands
{
    public class GetUser
    {
        public GetUser(string email)
        {
            Email = email;
        }
        public string Email { get; }
    }
}
