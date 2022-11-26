using System;
using System.Collections.Generic;
using System.Linq;

namespace StableMatchProblem
{

    /*
     * find stable match between 2 equal size set of elements
     * given an ordering of preference for each element
     * like:
     * m1:[w1,w2,w3]        w1:[m1,m3,m2]
     * m2:[w1,w3,w2]        w2:[m2,m3,m1]
     * m3:[w3,w1,w2]        w3:[m3,m1,m2]
     * 
     * m1,w1; m2,w2; m3w3
     */

    public class match
    {
        public string man { get; set; }
        public string woman { get; set; }
    }

    class Program
    {

        public static void getMarriageMatch(Dictionary<string, string[]> men, Dictionary<string, string[]> women)
        {
            List<string> menInPool = men.Keys.ToList(); ;
            List<string> womenInPool = women.Keys.ToList();
            List<match> match = new List<match>();


            while (menInPool.Count > 0)
            {
                var pickedMan = menInPool.FirstOrDefault();

                foreach (var woman in men[pickedMan])
                {
                    if (womenInPool.Contains(woman))
                    {
                        match.Add(new match() { man = pickedMan, woman = woman });
                        womenInPool.Remove(woman);
                        menInPool.Remove(pickedMan);
                        break;
                    }
                    else
                    {
                        var matchedCouple = match.Where(x => x.woman == woman).Select((v, i) => new { match = v, index = match.IndexOf(v) }).FirstOrDefault();

                        if (Array.IndexOf(women[woman], pickedMan) < Array.IndexOf(women[woman], matchedCouple.match.man))
                        {
                            menInPool.Add(matchedCouple.match.man);
                            menInPool.Remove(pickedMan);
                            match[matchedCouple.index].man = pickedMan;
                            break;
                        }
                    }
                }
            }
            foreach (var item in match)
            {
                Console.WriteLine(item.man + " " + item.woman);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, string[]> men = new Dictionary<string, string[]>();
            men.Add("m1", new string[] { "w1", "w2", "w3" });
            men.Add("m2", new string[] { "w1", "w3", "w2" });
            men.Add("m3", new string[] { "w3", "w1", "w2" });

            Dictionary<string, string[]> women = new Dictionary<string, string[]>();
            women.Add("w1", new string[] { "m1", "m3", "m2" });
            women.Add("w2", new string[] { "m2", "m3", "m1" });
            women.Add("w3", new string[] { "m3", "m1", "m2" });

            Program.getMarriageMatch(men, women);
            // Console.WriteLine("Hello World!");
        }
    }
}
