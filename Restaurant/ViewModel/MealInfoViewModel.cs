using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Model.Tables;

namespace Restaurant.ViewModel
{
    public class MealInfoViewModel : INotifyPropertyChanged
    {
        private Meal meal;
        private string imagePath;
        private int curImageIdx;

        private bool isOrder;
        private bool canAddComments;

        private ObservableCollection<CommentMeal> commentMeals;


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsOrder
        {
            get => isOrder;
            set => isOrder = value;
        }

        public bool CanAddComments
        {
            get => canAddComments;
            set => canAddComments = value;
        }

        public Meal Meal
        {
            get => meal;
            set => meal = value;
        }

        public string ImagePath
        {
            get => imagePath;
            set { imagePath = value;  this.OnPropertyChanged();}
        }

        public int CurImageIdx
        {
            get => curImageIdx;
            set { curImageIdx = value;  this.OnPropertyChanged();}
        }

        public ObservableCollection<CommentMeal> CommentMeals
        {
            get => commentMeals;
            set => commentMeals = value;
        }
    }
}
