using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace tour_planner.ViewModels {

    internal class MainViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _filterText = "";

        public string FilterText { 
            get => _filterText; 
            set {
                _filterText = value;
                PropertyChanged?.Invoke(this, new(nameof(FilterText)));
                FilterTours();
            }
        }

        private readonly List<Tour> _tours = new() {
            new Tour("Tour 1", 1000, 200, 2.5),
            new Tour("Tour 2", 2000, 400, 3.5),
            new Tour("Tour 3", 3000, 600, 4.5)
        };

        public ObservableCollection<Tour> Tours { get; private set; }

        public MainViewModel() {
            Tours = new ObservableCollection<Tour>(_tours);
        }

        public void FilterTours() {
            Tours.Clear();
            if (FilterText.Equals("")) {
                Tours = new ObservableCollection<Tour>(_tours);
                _tours.ForEach(tour => Tours.Add(tour));
            } else {
                _tours.Where(tour => tour.Name.Contains(FilterText)).ToList().ForEach(tour => Tours.Add(tour));
            }
        }
    }
}
