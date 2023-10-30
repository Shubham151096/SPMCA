using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.Search;
using SPCMA.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xamarin.Essentials;

namespace SPCMA.Activity
{
    [Activity(Theme = "@style/MyTheme.Layout")]
    public class AppListActivity : AppCompatActivity
    {
        ListView listView;
        List<DeviceItemModel> deviceItemModels = new List<DeviceItemModel>();
        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AppListLayout);
            listView = FindViewById<ListView>(Resource.Id.ItemListView);
            ItemListCreator();
        }
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Drawable.Menu, menu);
        //    return true;
        //}

        public override bool OnContextItemSelected(IMenuItem item)
        {
            return base.OnContextItemSelected(item);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Drawable.Menu, menu);

            var logout = menu.FindItem(Resource.Id.logout);
            var hey = logout.TooltipText;
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.logout)
            {
                StartActivity(new Intent(this, typeof(LoginActivity)));
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }



        public override void OnBackPressed()
        {
            return;
            //base.OnBackPressed();
        }

        private void ItemListCreator()
        {
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "COM 100",
                DeviceImage = Resource.Drawable.com100
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "3VA",
                DeviceImage = Resource.Drawable.va3
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "3WA",
                DeviceImage = Resource.Drawable.wa3
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "RCA",
                DeviceImage = Resource.Drawable.RCA
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "COM 800",
                DeviceImage = Resource.Drawable.com800
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "PAC 1000",
                DeviceImage = Resource.Drawable.pac1000
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "PAC 3100",
                DeviceImage = Resource.Drawable.pac3100
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "PAC 3200",
                DeviceImage = Resource.Drawable.pac3200
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "PAC 3220",
                DeviceImage = Resource.Drawable.pac3220
            });
            deviceItemModels.Add(new DeviceItemModel()
            {
                DeviceName = "PAC 4200",
                DeviceImage = Resource.Drawable.pac4200
            });
            listView.Adapter = new ListViewAdapter(this, deviceItemModels);

        }
    }
    public class ListViewAdapter : BaseAdapter<DeviceItemModel>
    {

        List<DeviceItemModel> items;
        Android.App.Activity context;
        public ListViewAdapter(Android.App.Activity context, List<DeviceItemModel> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override DeviceItemModel this[int position]
        {
            get
            {
                return items[position];
            }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.AppListItemLayout, null);
            view.FindViewById<TextView>(Resource.Id.DeviceNameTxt).Text = item.DeviceName;
            view.FindViewById<ImageView>(Resource.Id.DeviceImage).SetImageResource(item.DeviceImage);
            view.FindViewById<ImageView>(Resource.Id.DeviceImage).ContentDescription = item.DeviceName[0].ToString();
            return view;
        }
    }
}