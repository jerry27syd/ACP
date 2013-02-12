using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    public class SimplePast
    {
        public static string ConvertToSimplePastTense(string verb)
        {
            if (verb[verb.Length - 1] == 'e')
            {
                return verb + "d";
            }

            return verb + "ed";
        }

        
    }
}