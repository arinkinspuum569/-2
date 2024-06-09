using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace анимация_кружка_проба_2
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly CircleModel _circleModel; // это экземпляр класса CircleModel, который представляет круг.
        private ICommand _moveCircleCommand; //это объект, реализующий интерфейс ICommand, который будет использоваться для перемещения круга.

        public ViewModel() // конструктор класса ViewModel
        {
            _circleModel = new CircleModel(); // В нем создается новый экземпляр CircleModel и присваивается полю _circleModel.
        }

        public double X
        {
            get { return _circleModel.X; }
            set
            {
                _circleModel.X = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get { return _circleModel.Y; }
            set
            {
                _circleModel.Y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public ICommand MoveCircleCommand
        {
            get
            {
                if (_moveCircleCommand == null)
                {
                    _moveCircleCommand = new RelayCommand(MoveCircle());
                }
                return _moveCircleCommand;

            }
        }
        // - Это свойство, которое возвращает объект, реализующий интерфейс ICommand.
   // Если _moveCircleCommand равен null, создается новый экземпляр RelayCommand и
   // присваивается _moveCircleCommand.Этот RelayCommand будет вызывать метод MoveCircle
   // при выполнении команды.



        private void MoveCircle()
        {
            // Анимация кружка по прямой
            const double speed = 500;
            const double distance = 300;
            double currentX = X;
            double currentY = Y;

            for (double i = 0; i <= distance; i += speed)
            {
                X = currentX + (i / distance) * distance;
                Y = currentY;
                System.Threading.Thread.Sleep(5);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
