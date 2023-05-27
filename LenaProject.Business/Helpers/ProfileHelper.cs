using AutoMapper;
using LenaProject.Business.Mappings.AutoMapper;
using System.Collections.Generic;

namespace LenaProject.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new UserProfile(),
                new FormProfile(),
                new FieldProfile(),
            };
        }
    }
}
