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

        public Command<AvailableLocation> DeleteLocationCommand => new Command<AvailableLocation>(DeleteLocationAsync);

        public Command AddLocationCommand => new Command(AddLocation);
        public Command SkillEnteredCommand => new Command(SkillEntryAsync);

        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command<string> SkillDeletedCommand => new Command<string>(DeleteSkill);

        public Command ImageClickedCommand => new Command(ImageClicked);

        public SettingsViewModel()
        {
            BuildAvailableLocationsList();
            BuildAvatarList();
        }

        private void DeleteSkill(string skill)
        {
            Current.User.Skills.Remove(Current.User.Skills.FirstOrDefault(x => x.SkillName == skill));
        }

        internal async void UpdateCurrentUser()
        {
            if (Current.User is Developer developer)
            {
                Current.User.DateLog.DateModified = DateTime.Now;
                await DeveloperRepo.AddItemAsync(developer);
            }
            else if (Current.User is Recruiter recruiter)
            {
                Current.User.DateLog.DateModified = DateTime.Now;
                await RecruiterRepo.AddItemAsync(recruiter);
            }
        }

        private async void SkillEntryAsync()
        {
            var db = await SkillsRepo.GetAllItemsAsync();
            var dbskill = db.FirstOrDefault(x => x.SkillName == SkillEntry);

            if (dbskill == null)
            {
                dbskill = new Skill { SkillName = SkillEntry, IsCreatedByUser = true };
                await SkillsRepo.AddItemAsync(dbskill);
            }
            Current.User.Skills.Add(dbskill);
            SkillEntry = "";
        }

        private void BuildAvailableLocationsList()
        {
            SelectedLocationsList = new ObservableCollection<AvailableLocation>();
            foreach (Province item in Enum.GetValues(typeof(Province)))
            {
                if (item != Province.Select && (Current.User).AvailableLocations.FirstOrDefault(x => x.Province == item) == null)
                {
                    AvailableLocation location = new AvailableLocation { Province = item };
                    SelectedLocationsList.Add(location);
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

        private void DeleteLocationAsync(AvailableLocation location)
        {
            var userLocations = Current.User.AvailableLocations;
            userLocations.Remove(location);
            SelectedLocationsList.Add(location);
        }

        private void AddLocation()
        {
            var userLocations = Current.User.AvailableLocations;

            userLocations.Add(SelectedLocation);
            SelectedLocationsList.Remove(SelectedLocation);
            SelectedLocation = (SelectedLocationsList[0]) ?? SelectedLocation;
        }

        private void ImageClicked()
        {
            ShowImagePicker = ShowImagePicker != true;
        }

        private void AvatarSelected(string imageURL)
        {
            Current.User.Image = imageURL;
            ShowImagePicker = false;
        }
    }
}