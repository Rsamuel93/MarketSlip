﻿using Xamarin.Forms;

namespace MarketSlip.Renderers
{
    public class CameraView : View
    {
        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            "Camera",
            typeof(CameraOptions),
            typeof(CameraView),
            CameraOptions.Rear);

        public CameraOptions Camera
        {
            get => (CameraOptions)GetValue(CameraProperty);
            set => SetValue(CameraProperty, value);
        }
    }
}
