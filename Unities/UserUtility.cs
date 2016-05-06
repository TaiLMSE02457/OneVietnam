using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;



namespace Utilities
{
    public class UserUtility
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
        public DateTimeOffset DOB { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LockoutEndDate { get; set; }

        public UserUtility()
        {
            Username = "";
            Email = "";
            Gender = -1;
            Phone = "";
            Role = -1;            

        }

        public FilterDefinition<User> ToFilterDefinition()
        {
            var builder = Builders<User>.Filter;
            FilterDefinition<User> filter = null;
            if (Username != null & Username!="" )
            {
                filter = builder.Eq("UserName", Username);
            }
            if (Email != null & Email!="")
            {
                if (filter != null)
                {
                    filter = filter & builder.Eq("Email", Email);
                }
                else
                {
                    filter = builder.Eq("Email", Email);
                }
            }
            if (Gender != -1)
            {
                if (filter != null)
                {
                    filter = filter & builder.Eq("Gender", Gender);
                }
                else
                {
                    filter = builder.Eq("Gender", Gender);
                }
            }
            if (Phone != "" & Phone != null)
            {
                if (filter != null)
                {
                    filter = filter & builder.Eq("Phone", Phone);
                }
                else
                {
                    filter = builder.Eq("Phone", Phone);
                }
            }
            if (Role !=-1)
            {
                if (filter != null)
                {
                    filter = filter & builder.Eq("Role", Role);
                }
                else
                {
                    filter = builder.Eq("Role", Role);
                }
            }

            return filter;
        }

    }
}
