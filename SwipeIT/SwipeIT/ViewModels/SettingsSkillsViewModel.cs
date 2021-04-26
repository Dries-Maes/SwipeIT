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
    internal class SettingsSkillsViewModel : BaseViewModel
    {
        private Skill selectedSkill;

        public Skill SelectedSkill
        {
            get => selectedSkill;
            set
            {
                selectedSkill = value;
                OnPropertyChanged(nameof(SelectedSkill));
            }
        }

        private ObservableCollection<Skill> availableSkillsList;

        public ObservableCollection<Skill> AvailableSkillsList
        {
            get => availableSkillsList;
            set
            {
                availableSkillsList = value;
                OnPropertyChanged(nameof(AvailableSkillsList));
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

        public Command SkillPickedCommand => new Command(SkillPickedAsync);

        private void SkillPickedAsync()
        {
            if (SelectedSkill == null) return;
            var skills = Current.User.Skills;
            skills.Add(SelectedSkill);
            AvailableSkillsList.Remove(SelectedSkill);
            SelectedSkill = (AvailableSkillsList[0]) ?? SelectedSkill;
        }

        public Command SkillEnteredCommand => new Command(SkillEntryAsync);
        public Command<string> SkillDeletedCommand => new Command<string>(DeleteSkill);

        public SettingsSkillsViewModel()
        {
            BuildAvailableSkillsList().Wait();
        }

        private async Task BuildAvailableSkillsList()
        {
            AvailableSkillsList = new ObservableCollection<Skill>();

            List<Skill> Skills = (await SkillsRepo.GetAllItemsAsync()).Where(item => !item.IsCreatedByUser).ToList();

            foreach (var item in Skills.Where(item => !AvailableSkillsList.Select(x => x.SkillName).Contains(item.SkillName)))
            {
                AvailableSkillsList.Add(item);
            }
        }

        private void DeleteSkill(string skill)
        {
            Current.User.Skills.Remove(Current.User.Skills.FirstOrDefault(x => x.SkillName == skill));
        }

        private async void SkillEntryAsync()
        {
            var db = await SkillsRepo.GetAllItemsAsync();
            var dbskill = AvailableSkillsList.FirstOrDefault(x => x.SkillName == SkillEntry);

            if (dbskill == null)
            {
                dbskill = new Skill { SkillName = SkillEntry, IsCreatedByUser = true };
                await SkillsRepo.AddItemAsync(dbskill);
            }
            Current.User.Skills.Add(dbskill);
            SkillEntry = "";
        }
    }
}