using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class BenchmarkClass
    {
        public void NotMaterializedQueryTest(IEnumerable<int> elements, Func<string, string> makeASound, string sound)
        {

            var filteredElements = elements.Where(_ => _ % 100000 == 0);


            foreach (var element in filteredElements)
            {
                makeASound(sound);
            }

            string longString = string.Empty;

            foreach (var element in filteredElements)
            {

                longString += element.ToString();
            }

            List<int> gtfifty = new List<int>();

            foreach (var element in filteredElements)
            {
                if (element > 50)
                {
                    gtfifty.Add(element);
                }
            }

        }

        public void MaterializedQueryTest(IEnumerable<int> elements, Func<string, string> makeASound, string sound)
        {

            var filteredElements = elements.Where(_ => _ % 100000 == 0).ToList();

            foreach (var element in filteredElements)
            {
                makeASound(sound);
            }

            string longString = string.Empty;

            foreach (var element in filteredElements)
            {
                longString += element.ToString();
            }

            List<int> gtfifty = new List<int>();

            foreach (var element in filteredElements)
            {
                if (element > 50)
                {
                    gtfifty.Add(element);
                }
            }

        }
    }
}