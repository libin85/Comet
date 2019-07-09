﻿using System;
using UIKit;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace HotUI.iOS
{
    public class ButtonHandler : AbstractHandler<Button, UIButton>
    {
        public static readonly PropertyMapper<Button> Mapper = new PropertyMapper<Button>(ViewHandler.Mapper)
        {
            [nameof(Button.Text)] = MapTextProperty
        };
        
        public ButtonHandler() : base(Mapper)
        {

        }

        protected override UIButton CreateView()
        {
            var button = new UIButton();
            button.TouchUpInside += HandleTouchUpInside;
            button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            /*Layer.BorderColor = UIColor.Blue.CGColor;
            Layer.BorderWidth = .5f;
            Layer.CornerRadius = 3f;*/

            return button;
        }
        
        private void HandleTouchUpInside(object sender, EventArgs e)
        {
            VirtualView?.OnClick();
        }

        public static bool MapTextProperty(IViewHandler viewHandler, Button virtualView)
        {
            var nativeView = (UIButton) viewHandler.NativeView;
            nativeView.SetTitle(virtualView.Text, UIControlState.Normal);
            nativeView.SizeToFit();
            return true;
        }
    }
}