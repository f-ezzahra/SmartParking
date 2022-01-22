using Realms;

namespace gp.Models
{
    class User : RealmObject
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }


}
