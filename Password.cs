using System;
using System.Text;

namespace PasswordGen
{
    public class Password
    {
        private string upperCase = "abcdefghijklmnopqrstuvwxyz";
        private string digits = "0123456789";
        private string symbols = @"!@#$%^&*_-+=|(){}[]:;'<>,.?/";

        public enum Variations
        {
            Digits,
            Symbols
        }

        private int _lenght = 8;
        public int Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        public bool UseUcase = true;



        public Password()
        {

        }

        public string Generate()
        {
            StringBuilder result = new StringBuilder();
            /**
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
            **/

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
