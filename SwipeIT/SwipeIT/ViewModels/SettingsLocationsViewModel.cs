using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    internal class SettingsLocationsViewModel : BaseViewModel
    {
        private AvailableLocation selectedLocation;

        public AvailableLocation SelectedLocation
        {
            get => selectedLocation;
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        private ObservableCollection<AvailableLocation> selectedLocationsList;

        public ObservableCollection<AvailableLocation> SelectedLocationsList
        {
            get => selectedLocationsList;
            set
            {
                selectedLocationsList = value;
                OnPropertyChanged(nameof(SelectedLocationsList));
            }
        }

        public Command<AvailableLocation> DeleteLocationCommand => new Command<AvailableLocation>(DeleteLocationAsync);

        public Command AddLocationCommand => new Command(AddLocation);

        public SettingsLocationsViewModel()
        {
            BuildAvailableLocationsList();
        }

        private void BuildAvailableLocationsList()
        {
            SelectedLocationsList = new ObservableCollection<AvailableLocation>();
            foreach (Province item in Enum.GetValues(typeof(Province)))
            {
                if (item == Province.Select ||
                    (Current.User).AvailableLocations.FirstOrDefault(x => x.Province == item) != null) continue;
                AvailableLocation location = new AvailableLocation { Province = item };
                SelectedLocationsList.Add(location);
            }
        }

        private async void DeleteLocationAsync(AvailableLocation location)
        {
            var userLocations = Current.User.AvailableLocations;
            userLocations.Remove(location);
            SelectedLocationsList.Add(location);
        }

        private async void AddLocation()
        {
            if (SelectedLocation == null) return;
            var userLocations = Current.User.AvailableLocations;
            userLocations.Add(SelectedLocation);
            SelectedLocationsList.Remove(SelectedLocation);
            SelectedLocation = (SelectedLocationsList[0]) ?? SelectedLocation;
        }
    }
}