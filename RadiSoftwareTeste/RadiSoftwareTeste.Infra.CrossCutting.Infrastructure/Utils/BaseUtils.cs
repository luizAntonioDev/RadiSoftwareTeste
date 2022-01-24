using System;
using System.Collections.Generic;
using System.Linq;

namespace RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Utils
{
    public static class BaseUtils
    {

        public static int NextIdList<T>(List<T> list)
        {
            if (list.Any())
            {
                return list.Count + 1;
            }
            else
            {
                return 1;
            }
        }

        public static int? AgeCalculator(DateTime? birthDate)
        {
            if (birthDate == null) return null;

            var castBirthDate = (DateTime)birthDate;
            var age = DateTime.Now.Year - castBirthDate.Year;

            if (DateTime.Now.Month == castBirthDate.Month)
            {
                if (DateTime.Now.Day < castBirthDate.Day)
                {
                    age--;
                }
            }

            if (DateTime.Now.Month < castBirthDate.Month) age--;

            return age;
        }

    }
}
