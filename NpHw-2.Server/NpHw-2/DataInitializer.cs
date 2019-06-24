using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpHw_2
{
    class DataInitializer : DropCreateDatabaseAlways<StreetContext>
    {
        protected override void Seed(StreetContext context)
        {
            List<Street> streets = new List<Street>
            {
                new Street
                {
                   Name = "Сатпаева",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Мунайтпасова",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Тауелсыздык",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Ташенова",
                   PostIndex = "000000"
                },
                new Street
                {
                   Name = "Кварцова",
                   PostIndex = "111111"
                },
                new Street
                {
                   Name = "Иманова",
                   PostIndex = "111111"
                },
                new Street
                {
                   Name = "Абая",
                   PostIndex = "111111"
                }
            };
            context.Streets.AddRange(streets);
            base.Seed(context);
        }
    }
}
