using HomeControl.Data;

namespace HomeControl.Services
{
    internal class AddHelloResponse
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public AddHelloResponse(User newUser)
        {
            Id = newUser.Id;
            Forename = newUser.Forename;
            Surname = newUser.Surname;
        }
    }
}