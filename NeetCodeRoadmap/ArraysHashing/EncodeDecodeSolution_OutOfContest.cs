using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    /// <summary>
    /// !!! На литкоде доступен только по подписке, поэтому будем без реальных тестов обходиться.
    /// Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.
    /// Input: ["we", "say", ":", "yes"]
    /// Output: ["we", "say", ":", "yes"]
    /// Explanation:
    /// One possible encode method is: "we:;say:;:::;yes"
    /// </summary>
    internal class EncodeDecodeSolution_OutOfContest
    {
        private char _separator = '_';
        
        public string Encode(List<string> stringsToEncode)
        {
            var result = new StringBuilder();
            for (int i = 0; i < stringsToEncode.Count; i++)
            {
                var stringToEncode = stringsToEncode[i];
                result.Append(stringToEncode.Length);
                result.Append(_separator);
                foreach (var symbol in stringToEncode)
                {
                    result.Append(symbol);
                }          
            }
            return result.ToString();
        }

        
        public List<string> Decode(string stringToDecode)
        {
            var currentWord = new StringBuilder();
            var words = new List<string>();

            var lengthString = new StringBuilder();
            var counter = 0;
            var length = -1;
            var isProcessingWord = false;
            for (int i = 0; i < stringToDecode.Length; i++)
            {
                var symbol = stringToDecode[i];

                if (isProcessingWord)
                {
                    if (counter == length)
                    {
                        words.Add(currentWord.ToString());
                        currentWord.Clear();
                        counter = 0;
                        isProcessingWord = false;
                    }
                    else
                    {
                        currentWord.Append(symbol);
                        counter++;
                        continue;
                    }
                }


                if (!isProcessingWord)
                {
                    if (char.IsDigit(symbol))
                    {
                        lengthString.Append(symbol);
                        continue;
                    }

                    if (symbol == _separator)
                    {
                        length = int.Parse(lengthString.ToString());
                        lengthString.Clear();
                        isProcessingWord = true;
                        continue;
                    }
                }
            }

            words.Add(currentWord.ToString());

            return words;
        }
    }
}
