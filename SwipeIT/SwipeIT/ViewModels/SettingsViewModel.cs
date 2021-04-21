using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        private string skillEntry;

        public string SkillEntry
        {
            get { return skillEntry; }
            set
            {
                skillEntry = value;
                OnPropertyChanged(nameof(SkillEntry));
            }
        }

        public List<string> AvatarList { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);
        public Command<Location> DeleteLocationCommand => new Command<Location>(DeleteLocationAsync);

        public Command AddLocationCommand => new Command(AddLocation);
        public Command SkillEnteredCommand => new Command(SkillEnteredAsync);

        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command<string> SkillDeletedCommand => new Command<string>(SkillDeleted);

        private void SkillDeleted(string skill)
        {
            var temp = ((User)CurrentUserSingleton.CurrentUser).Skills;
            temp.Remove(temp.FirstOrDefault(x => x.SkillName == skill));
        }

        public Command ImageClickedCommand => new Command(ImageClicked);

        public SettingsViewModel()
        {
            BuildAvailableLocationsList();
            BuildAvatarList();
            SetRoleBools();
        }

        private async void SkillEnteredAsync()
        {
            if (!SkillsRepo.GetSkills().Select(x => x.SkillName).Contains(SkillEntry))
            {
                await SkillsRepo.AddItemAsync(new Skill { SkillName = SkillEntry, IsCreatedByUser = true });
            }
            ((User)CurrentUserSingleton.CurrentUser).Skills.Add(SkillsRepo.GetSkills().FirstOrDefault(x => x.SkillName == SkillEntry));
            SkillEntry = "";
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