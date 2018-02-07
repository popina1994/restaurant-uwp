using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Restaurant.Logic.Params;
using Restaurant.Model;
using Restaurant.Model.Tables;
using Restaurant.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restaurant.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
            mapObjects = new Dictionary<MapIcon, object>();
        }

        private Dictionary<MapIcon, Object> mapObjects;

        private void MapControlRestaurant_OnLoaded(object sender, RoutedEventArgs e)
        {
            Geopoint snPoint = new Geopoint(new BasicGeoposition() { Latitude = 44.8173, Longitude = 20.5096 });
            var landmarksMapElements = new List<MapElement>();
            MapIcon globalPin = null;
            foreach (var itOrder in DatabaseModel.OrdersTable.Values)
            {
                if (itOrder.Status == Order.NotDelivered)
                {
                    string orderTitle = itOrder.Id + ",";
                    string colour = Order.GroupsColoursStr[itOrder.Group];
                    LinkedList<RestaurantSpec> restaurantSpecs = new LinkedList<RestaurantSpec>();
                    LinkedList<User> users = new LinkedList<User>();
                    foreach (var it in itOrder.OrderMealOptions.Values)
                    {
                        if (!restaurantSpecs.Contains(it.Meal.Restaurant))
                        {
                            restaurantSpecs.AddLast(it.Meal.Restaurant);
                        }
                    };
                    if (!users.Contains(itOrder.User))
                    {
                        users.AddLast(itOrder.User);
                    }

                    foreach (var itRest in restaurantSpecs)
                    {
                        var tempTitle = orderTitle + itRest.Id;
                    
                        var pinIcon = new MapIcon
                        {
                            Location = itRest.LocationGeopoint,
                            NormalizedAnchorPoint = new Point(0.5, 1.0),
                            ZIndex = 0,
                            Title = itRest.Name,
                            CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible 
                        };
                        mapObjects.Add(pinIcon, itRest);
                        string path = "ms-appx:///Assets/Icons/Pin/";
                        var tempColour = path + colour + ".png";
                        //pinIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri(tempColour));
                        landmarksMapElements.Add(pinIcon);
                        MapControlRestaurant.MapElements.Add(pinIcon);
                        globalPin = pinIcon;
                    }

                    foreach (var itUser in users )
                    {
                        var pinIcon = new MapIcon
                        {
                            Location = itUser.LocationGeopoint,
                            NormalizedAnchorPoint = new Point(0.5, 1.0),
                            ZIndex = 0,
                            Title = itUser.FirstName + " " + itUser.LastName,
                            CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible
                        };
                        MapControlRestaurant.MapElements.Add(pinIcon);
                    }
                }
            }
            /*
            var landmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = landmarksMapElements
            };

            //MapControlRestaurant.Layers.Add(landmarksLayer);
            */
            MapControlRestaurant.Center = snPoint;
            MapControlRestaurant.ZoomLevel = 14;
            updateUserPosition();
        }

        private void MapControlRestaurant_OnMapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon clickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            RestaurantSpec restaurant;
            if (mapObjects.ContainsKey(clickedIcon))
            {
                restaurant = mapObjects.First(x=>x.Key == clickedIcon).Value as RestaurantSpec;
            }
            else
            {
                return;
            }
            RestaurantInfoParams restaurantInfoParams = new RestaurantInfoParams(restaurant);
            Navigation.Navigate(typeof(RestaurantInfoPage), restaurantInfoParams);
        }

        async private void updateUserPosition()
        {
            Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 100 };

            Geoposition pos = await geolocator.GetGeopositionAsync();
            var pinIcon = new MapIcon
            {
                Location = pos.Coordinate.Point,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Trenutna",
                CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible
            };
            /*
            string path = "ms-appx:///Assets/Icons/Pin/";
            var tempColour = path + "Black" + ".png";
            pinIcon.Image =
                RandomAccessStreamReference.CreateFromUri(new Uri(tempColour));
            */
            MapControlRestaurant.MapElements.Add(pinIcon);
        }
    }
}
