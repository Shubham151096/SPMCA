using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCMA.Model
{
    public class DeviceItemModel
    {
        public int DeviceImage { get; set; } = Resource.Drawable.defaultImg;
        public string DeviceName { get; set; }
        public bool IshavingChild { get; set; } = false;
        //public List<DeviceItemModel> childlist {get ; set;} = new List<DeviceItemModel>();
    }
}