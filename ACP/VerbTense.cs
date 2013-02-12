using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    public class VerbTense
    {
        public static string ConvertToSimplePast(string verb)
        {
            var item = ConstantValue.GetIrregularVerbs().FirstOrDefault(c => c.Infinitive == verb);
            if (item != null)
            {
                //always get the first Item
                return item.SimplePast.Split(',')[0].Trim();
            }
            if (verb[verb.Length - 1] == 'e')
            {
                return verb + "d";
            }
            return verb + "ed";
        }

        public static string ConvertToPastParticiple(string verb)
        {
            var item = ConstantValue.GetIrregularVerbs().FirstOrDefault(c => c.Infinitive == verb);
            if (item != null)
            {
                return item.PastParticiple.Split(',')[0].Trim();
            }
            if (verb[verb.Length - 1] == 'e')
            {
                return verb + "d";
            }
            return verb + "ed";
        }
    }
}