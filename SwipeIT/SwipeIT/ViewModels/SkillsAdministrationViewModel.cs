using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SkillsAdministrationViewModel : BaseViewModel
    {
        private ObservableCollection<Skill> skill;

        public ObservableCollection<Skill> Skills
        {
            get => skill;
            set
            {
                skill = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        public Command<Skill> InvertIsUserCreatedBoolCommad => new Command<Skill>(InvertIsUserCreated);
        public Command<Skill> DeleteSkillCommand => new Command<Skill>(DeleteSkill);
        public ICommand SaveSkillsCommand => new Command(SaveSkills);

        public SkillsAdministrationViewModel()
        {
            GetSkills().Wait();
        }

        private async Task GetSkills()
        {
            SkillRepo repo = new SkillRepo();
            Skills = new ObservableCollection<Skill>(await repo.GetAllUserCreatedSkillsAsync());
        }

        private async void SaveSkills()
        {
            await SkillsRepo.UpdateItemsAsync(Skills);
            await GetSkills();
        }

        private async void DeleteSkill(Skill skill)
        {
            Skills.Remove(skill);
            await SkillsRepo.DeleteItemAsync(skill.Id);
        }

        private void InvertIsUserCreated(Skill skill)
        {
            skill.IsCreatedByUser = !skill.IsCreatedByUser;
        }
    }
}