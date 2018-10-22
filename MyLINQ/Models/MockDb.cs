using System;
using System.Collections.Generic;
using System.Text;

namespace MyLINQ.Models
{
    public static class MockDb
    {
        public static IEnumerable<Mobile> GetAllMobiles()
        {
            return new List<Mobile>()
            {
                new Mobile()
                {
                    Id=1,
                    Name="IPhone X",
                    Price=1000
                },
                new Mobile()
                {
                    Id=2,
                    Name="Samsung Note 9",
                    Price=800
                },
                new Mobile()
                {
                    Id=3,
                    Name="Sony ZX",
                    Price=500
                },
                new Mobile()
                {
                    Id=45,
                    Name="Samsung S9+",
                    Price=790
                },
            };
        }
    }
}
