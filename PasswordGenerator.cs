using System;

namespace PasswordGen
{
    public class PasswordGenerator
    {
        public enum SpecialChar { Upper, Digit, Symbol };

        private readonly string M_NORMALS = "abcdefghijklmnopqrstuvwxyz";

        private Tuple<SpecialChar, int, string>[] specialCharMaps = {
            new Tuple<SpecialChar, int, string>(SpecialChar.Upper, 0, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
            new Tuple<SpecialChar, int, string>(SpecialChar.Digit, 2, "0123456789"),
            new Tuple<SpecialChar, int, string>(SpecialChar.Symbol, 0, "!@#$%^&*()-_+=[]{}|:;<>,.?")
        };

        private int _lenght = 8;
        public int Lenght
        {
            get { return _lenght; }
            set { _lenght = value; }
        }

        public string Generate()
        {
            char[] password = new String(' ', Lenght).ToCharArray();

            foreach (Tuple<SpecialChar, int, string> specialCharMap in specialCharMaps)
                RandomizePassword(password, specialCharMap);

            return new string(password);
        }

        private void RandomizePassword(char[] map, Tuple<SpecialChar, int, string> specialCharMap)
        {
            if (specialCharMap.Item2 > 0)
            {
                Random random = new Random();
                int availablePositions = 0;

                foreach (char item in map)
                {
                    if (item != (char)specialCharMap.Item1)
                        availablePositions++;
                }

                while (specialCharMap.Item2 > 0)
                {
                    int position = random.Next(availablePositions);

                }
            }
        }
    }
}