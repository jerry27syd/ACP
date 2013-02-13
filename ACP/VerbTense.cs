using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    public class VerbTense
    {
        public static string ConvertToPresent(Word lastWord, string verb)
        {
            if (lastWord.Type == "SUBJECT" && lastWord.Value.ToUpper() == "I")
            {
                var verbT = verb.ToUpper();
                if (verbT == "IS")
                {
                    verb = "am";
                }

                return verb;
            }else if (lastWord.Type == "SUBJECT" && IsPlural(lastWord.Value))
            {
                var verbT = verb.ToUpper();
                if (verbT == "IS")
                {
                    verb = "are";
                }

                return verb;
            }
            else
            {
                var verbT = verb.ToUpper();
                if (verbT == "IS")
                {
                    return verb;
                }
                else
                {
                    if (verb[verb.Length - 1] == 'h')
                    {
                        return verb + "es";
                    }
                    return verb + "s";
                }
            }
        }


        public static string ConvertToSimplePast(Word lastWord, string verb)
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


        public static string ConvertBe(string subject, string verb)
        {
            verb = verb.ToUpper();
            if (verb == "IS" || verb == "AM" || verb == "ARE")
            {
                subject = subject.ToUpper();
                if (subject == "I")
                {
                    return "am";
                }
                else if (subject == "YOU" || subject == "WE" || subject == "THEY")
                {
                    return "are";
                }
                else
                {
                    return "is";
                }
            }
            return null;
        }


        public static bool IsPlural(string subject)
        {
            subject = subject.ToUpper();
            return subject[subject.Length - 1] == 's' || subject == "YOU" || subject == "WE" || subject == "THEY";
        }

        public static bool IsSingular()
        {
            return true;
        }
    }
}