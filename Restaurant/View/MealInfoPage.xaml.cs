using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Restaurant.Logic.Params;
using Restaurant.Model;
using Restaurant.Model.Tables;
using Restaurant.Services;
using Restaurant.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MealInfoPage : Page
    {
        private MealInfoViewModel viewModel;
        public MealInfoPage()
        {
            this.InitializeComponent();
            viewModel = new MealInfoViewModel();
        }

        public MealInfoViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }


        private void ButtonLeftImage_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CurImageIdx = (ViewModel.CurImageIdx - 1 + ViewModel.Meal.ImagePathLinkedList.Count)
                                    % ViewModel.Meal.ImagePathLinkedList.Count;
            ViewModel.ImagePath = ViewModel.Meal.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MealInfoParams restaurantInfoParams = (MealInfoParams)e.Parameter;
            ViewModel.Meal = restaurantInfoParams.Meal;
            ViewModel.CurImageIdx = 0;
            ViewModel.ImagePath = ViewModel.Meal.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);

            ObservableCollection<CommentMeal> ocComm = new ObservableCollection<CommentMeal>();
            foreach (var it in DatabaseModel.CommentMealTable)
            {
                if (it.Value.Meal.Id == ViewModel.Meal.Id)
                {
                    ocComm.Add(it.Value);
                }
            }

            ViewModel.CommentMeals = ocComm;

            User user = Navigation.Shell.Model.User;

            ViewModel.IsOrder = user.Type == User.TYPE_ORDERER;
            ViewModel.CanAddComments = false;
            foreach (var it in DatabaseModel.OrdersTable.Values)
            {
                if ((it.User.Id == user.Id) && (it.Status != Order.NotDelivered))
                {
                    foreach (var itIn in it.OrderMealOptions.Values)
                    {
                        if (itIn.Meal.Id == ViewModel.Meal.Id)
                        {
                            ViewModel.CanAddComments = true;
                            break;
                        }
                    }
                    if (ViewModel.CanAddComments) break;
                }
            }
        }

        private void ButtonRightImage_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CurImageIdx = (ViewModel.CurImageIdx + 1) % ViewModel.Meal.ImagePathLinkedList.Count;
            ViewModel.ImagePath = ViewModel.Meal.ImagePathLinkedList.ElementAt(ViewModel.CurImageIdx);
        }

        private void calculateMealRating(Meal meal)
        {
            double rating = 0;
            double cnt = 0;
            foreach (var it in DatabaseModel.CommentMealTable.Values)
            {
                if ((it.Meal.Id == meal.Id))
                {
                    rating += it.Rating;
                    cnt++;
                }
            }

            if (cnt > 0)
            {
                rating /= cnt;
            }

            Meal mealDB= DatabaseModel.MealsTable.First(x => x.Value.Id == meal.Id).Value;
            mealDB.Rating = rating;
            meal.Rating = meal.Rating;
        }

        private void ButtonAddComment_OnClick(object sender, RoutedEventArgs e)
        {
            User user = DatabaseModel.UserTable.First(x => x.Value.UserName == Navigation.Shell.Model.UserName).Value;
            CommentMeal commentMeal= new CommentMeal(TextBoxComment.Text, user, ViewModel.Meal, (int)SliderRating.Value);
            ViewModel.CommentMeals.Add(commentMeal);
            DatabaseModel.CommentMealTable.Add(commentMeal.Id, commentMeal);
            calculateMealRating(ViewModel.Meal);
        }
    }
}
