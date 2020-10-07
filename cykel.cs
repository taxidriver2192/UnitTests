using System;

namespace UnitTests
{
    public class cykel
    {
        private int _id;
        private string _farve;
        private int _pris;
        private int _gear;

        public cykel(int id, string farve, int pris, int gear)
        {
            Id = id;
            Farve = farve;
            Pris = pris;
            Gear = gear;
        }

        public cykel()
        {
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set
            {
                if (value.Length < 1) throw new ArgumentOutOfRangeException();
                _farve = value;
            }
        }

        public int Pris
        {
            get => _pris;
            set
            {
                if (value > 0)
                {
                    _pris = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Skal være over 0");
                }
            }
        }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value < 3 || value > 32) throw new ArgumentOutOfRangeException("Talet skal være mellem 3 og 32");
                _gear = value;
            }
        }
    }
}
