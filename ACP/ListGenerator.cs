using System.Collections.Generic;
using System.Linq;

namespace ACP
{
    public class ListGenerator
    {
        private readonly List<int> _indices = new List<int>();
        private readonly List<int> _limits = new List<int>();

        private readonly List<WordCollection> _inputList = new List<WordCollection>();

        public ListGenerator(List<WordCollection> inputList)
        {
            foreach (var item in inputList)
            {
                _limits.Add(item.Count());
                _indices.Add(0);
            }
            _inputList = inputList;
        }

        private bool End { get; set; }

        private void Increment(int value = 1, int index = 0)
        {
            if (End) return;
            int tryAdd = _indices[index] + value;
            if (tryAdd >= _limits[index])
            {
                _indices[index] = tryAdd%_limits[index];
                int nextIndex = index + 1;
                if (nextIndex < _indices.Count)
                {
                    tryAdd = tryAdd/_limits[index];
                    index++;
                    Increment(tryAdd, index);
                }
                else
                {
                    End = true;
                }
            }
            else
            {
                _indices[index] = tryAdd;
            }
        }

        public List<string> Generate()
        {
            var rtVal = new List<string>();
            while (!End)
            {
                var str = string.Empty;
                var LastType = new Word(string.Empty);

                for (int i = 0; i < _indices.Count; i++)
                {
                    int index = _indices[i];

                    if (LastType.Type == "SUBJECT")
                    {
                        str += VerbTense.ConvertToPresent(LastType,_inputList[i][index].Value )+ " ";
                    }
                    else
                    {
                        str += _inputList[i][index].Value + " ";
                    }

                    LastType.Type = _inputList[i].Type;
                    LastType.Value = _inputList[i][index].Value;
                }
                rtVal.Add(str);
                Increment();
            }
            return rtVal;
        }
        public List<string> GenerateSentances()
        {
            var rtVal = new List<string>();
            while (!End)
            {
                var str = string.Empty;
                for (int i = 0; i < _indices.Count; i++)
                {
                    int index = _indices[i];

                    str += _inputList[i][index] + " ";
                }
                rtVal.Add(str);
                Increment();
            }
            return rtVal;
        }
    }
}