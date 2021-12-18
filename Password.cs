using System;
using System.Text;

namespace PasswordGen
{
    public class Password
    {
        public enum CharsetEnum { UpperCase, Digits, Symbols };

        private Dictionary<CharsetEnum, string> charactersMap = new Dictionary<CharsetEnum, string>();
        private Dictionary<string, int> trickyPassword;

        private readonly string M_NORMALS = "abcdefghijklmnopqrstuvwxyz";

        private int _lenght = 8;
        public int Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        public Password()
        {
            trickyPassword = new Dictionary<string, int>();

            charactersMap.Add(CharsetEnum.UpperCase, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            charactersMap.Add(CharsetEnum.Digits, "0123456789");
            charactersMap.Add(CharsetEnum.Symbols, @"!@#$%^&*_-+=|(){}[]:;'<>,.?/");
        }

        public void Tricky(int lenght, CharsetEnum charset)
        {
            trickyPassword.TryAdd(charactersMap[charset], lenght);
        }

        public string Generate()
        {
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            int trickyLenght = TrickyLenght(trickyPassword);
            int position;

            if (Lenght < trickyLenght)
                Lenght = trickyLenght + 1;

            trickyPassword.Add(M_NORMALS, Lenght - trickyLenght);
            foreach (KeyValuePair<string, int> trick in trickyPassword)
            {
                for (int i = 0; i < trick.Value; i++)
                {
                    position = rand.Next(result.Length);
                    result.Insert(position, trick.Key[rand.Next(trick.Key.Length)]);
                }
            }
            return result.ToString();
        }

        private int TrickyLenght(Dictionary<string, int> trick)
        {
            int trickLenght = 0;

            foreach (KeyValuePair<string, int> item in trick)
            {
                trickLenght += item.Value;
            }
            return trickLenght;
        }
    }
}
