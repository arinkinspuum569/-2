using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace анимация_кружка_проба_2
{
    public class CircleModel
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
