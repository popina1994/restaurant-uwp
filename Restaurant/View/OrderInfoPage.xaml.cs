﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Restaurant.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderInfoPage : Page
    {
        private OrderViewModel viewModel;
        public OrderInfoPage()
        {
            this.InitializeComponent();
            ViewModel = new OrderViewModel();
        }

        public OrderViewModel ViewModel
        {
            get => viewModel;
            set => viewModel = value;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            OrderInfoParams orderInfoParams = (OrderInfoParams)e.Parameter;
            ViewModel.Order= orderInfoParams.Order;
        }


        private void ButtonDeliver_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Order.Status = Order.Delivered;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Order.Status = Order.Canceled;
        }
    }
}