using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseEntity
    {        
        private Profile _profile;

        public Profile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }


        public List<Post> Posts { get; set; }

        public string UserName
        {
            get { return _profile.UserName; }
            set { _profile.UserName = value; }
        }

        public int Gender
        {
            get { return _profile.Gender; }
            set { _profile.Gender = value; }
        }

        public string Email
        {
            get { return _profile.Email; }
            set { _profile.Email = value; }
        }
        public int Role { get; set; }

        public string PasswordHash
        {
            get { return _profile.Password; }
            set { _profile.Password = value; }
        }

        public string Location
        {
            get { return _profile.Location; }
            set { _profile.Location = value; }
        }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LockoutEndDate { get; set; }

        public User(Profile p)
        {
            _profile = p;
            _profile.UserName = p.UserName;
        }

        public User()
        {
            _profile = new Profile();
        }
    }
}
