using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel

    {
        private bool showImagePicker;

        public bool ShowImagePicker
        {
            get => showImagePicker;
            set
            {
                showImagePicker = value;
                OnPropertyChanged(nameof(ShowImagePicker));
            }
        }

        private Province selectedLocation;

        public Province SelectedLocation
        {
            get => selectedLocation;
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        private ObservableCollection<Province> availableLocations;

        public ObservableCollection<Province> AvailableLocations
        {
            get => availableLocations;
            set
            {
                availableLocations = value;
                OnPropertyChanged(nameof(AvailableLocations));
            }
        }

        private string skillEntry;

        public string SkillEntry
        {
            get => skillEntry;
            set
            {
                skillEntry = value;
                OnPropertyChanged(nameof(SkillEntry));
            }
        }

        public List<string> AvatarList { get; set; }

        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);
        public Command<Location> DeleteLocationCommand => new Command<Location>(DeleteLocationAsync);

        public Command AddLocationCommand => new Command(AddLocation);
        public Command SkillEnteredCommand => new Command(SkillEnteredAsync);

        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command<string> SkillDeletedCommand => new Command<string>(SkillDeleted);

        public Command ImageClickedCommand => new Command(ImageClicked);

        public SettingsViewModel()
        {
            BuildAvailableLocationsList();
            BuildAvatarList();
        }

        private void SkillDeleted(string skill)
        {
            var temp = ((User)CurrentUserSingleton.CurrentUser).Skills;
            temp.Remove(temp.FirstOrDefault(x => x.SkillName == skill));
        }

        internal async void UpdateCurrentUser()
        {
            if (CurrentUserSingleton.CurrentUser is Developer)
            {
                await DeveloperRepo.AddItemAsync((Developer)CurrentUserSingleton.CurrentUser);
            }
            else if (CurrentUserSingleton.CurrentUser is Recruiter)
            {
                await RecruiterRepo.AddItemAsync((Recruiter)CurrentUserSingleton.CurrentUser);
            }
            else
            {
                //AdminRepo
            }
        }

        private async void SkillEnteredAsync()
        {
            var skills = await SkillsRepo.GetAllItemsAsync();
            if (!skills.Select(x => x.SkillName).Contains(SkillEntry))
            {
                await SkillsRepo.AddItemAsync(new Skill { SkillName = SkillEntry, IsCreatedByUser = true });
                skills.Add(new Skill { SkillName = SkillEntry, IsCreatedByUser = true });
            }
            ((User)CurrentUserSingleton.CurrentUser).Skills.Add(skills.FirstOrDefault(x => x.SkillName == SkillEntry));
            SkillEntry = "";
        }

        private void BuildAvailableLocationsList()
        {
            AvailableLocations = new ObservableCollection<Province>();
            foreach (Province item in Enum.GetValues(typeof(Province)))
            {
                if (item != Province.Select && ((User)CurrentUserSingleton.CurrentUser).Locations.FirstOrDefault(x => x.Province == item) == null)
                {
                    AvailableLocations.Add(item);
                }
            }
        }

        private void BuildAvatarList()
        {
            AvatarList = new List<string>();
            for (int i = 1; i < 31; i++)
            {
                AvatarList.Add($"Icon{i:00}.png");
            }
            AvatarList = AvatarList.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void DeleteLocationAsync(Location locationClass)
        {
            var location = locationClass.Province;
            var userLocations = ((User)CurrentUserSingleton.CurrentUser).Locations;
            userLocations.Remove(userLocations.FirstOrDefault(x => x.Province == location));
            AvailableLocations.Add(location);
        }

        private void AddLocation()
        {
            var userLocations = ((User)CurrentUserSingleton.CurrentUser).Locations;
            if (SelectedLocation != Province.Select)
            {
                userLocations.Add(new Location { Province = SelectedLocation });
                AvailableLocations.Remove(SelectedLocation);
                SelectedLocation = AvailableLocations.Count == 0 ? Province.Select : AvailableLocations[0];
            }
            SelectedLocation = Province.Select;
        }

        private void ImageClicked()
        {
            ShowImagePicker = ShowImagePicker != true;
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
                await DeveloperRepo.AddItemAsync((Developer)account);
            }
            else if (account is Recruiter)
            {
                await RecruiterRepo.AddItemAsync((Recruiter)account);
            }
        }
    }
}