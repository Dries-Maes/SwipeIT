using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel

    {
        private bool showImagePicker;

        public bool ShowImagePicker
        {
            get { return showImagePicker; }
            set
            {
                showImagePicker = value;
                OnPropertyChanged(nameof(ShowImagePicker));
            }
        }

        private Location selectedLocation;

        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        private ObservableCollection<Location> availableLocations;

        public ObservableCollection<Location> AvailableLocations
        {
            get { return availableLocations; }
            set
            {
                availableLocations = value;
                OnPropertyChanged(nameof(AvailableLocations));
            }
        }

        public List<string> AvatarList { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);
        public Command<Location> DeleteLocationCommand => new Command<Location>(DeleteLocationAsync);

        public Command AddLocationCommand => new Command(AddLocation);

        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command ImageClickedCommand => new Command(ImageClicked);

        public List<string> AvatarList { get; set; }

        public SettingsViewModel()
        {
            BuildAvailableLocationsList();
            BuildAvatarList();
            SetRoleBools();
        }

        private void BuildAvailableLocationsList()
        {
            AvailableLocations = new ObservableCollection<Location>();
            foreach (Location item in Enum.GetValues(typeof(Location)))
            {
                if (item != Location.Unassigned && !((User)CurrentUserSingleton.CurrentUser).Locations.Contains(item))
                {
                    AvailableLocations.Add(item);
                }
            }
        }

        private void SetRoleBools()
        {
            if (CurrentUserSingleton.CurrentUser is Developer)
            {
                IsDeveloper = true;
                IsRecruiter = false;
            }
            else if (CurrentUserSingleton.CurrentUser is Recruiter)
            {
                IsDeveloper = false;
                IsRecruiter = true;
            }
        }

        private void BuildAvatarList()
        {
            AvatarList = new List<string>();
            for (int i = 1; i < 31; i++)
            {
                AvatarList.Add($"Icon{i.ToString("00")}.png");
            }
            AvatarList = AvatarList.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void DeleteLocationAsync(Location location)
        {
            ((User)CurrentUserSingleton.CurrentUser).Locations.Remove(location);
            AvailableLocations.Add(location);
        }

        private void AddLocation()
        {
            if (SelectedLocation != Location.Unassigned)
            {
                ((User)CurrentUserSingleton.CurrentUser).Locations.Add(SelectedLocation);
                AvailableLocations.Remove(SelectedLocation);
                SelectedLocation = AvailableLocations.Count == 0 ? Location.Unassigned : AvailableLocations[0];
            }
        }

        private void ImageClicked()
        {
            ShowImagePicker = ShowImagePicker == true ? false : true;
        }

        private void AvatarSelected(string imageURL)
        {
            ((User)CurrentUserSingleton.CurrentUser).Image = imageURL;
            ShowImagePicker = false;
        }

        private async void SaveAsync(Account account)
        {
            if (account is Developer)
            {
                await DeveloperRepo.UpdateItemAsync((Developer)account);
            }
            else if (account is Recruiter)
            {
                await RecruiterRepo.UpdateItemAsync((Recruiter)account);
            }
        }
    }
}