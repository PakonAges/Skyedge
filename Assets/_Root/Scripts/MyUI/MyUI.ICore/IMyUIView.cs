﻿using UnityEngine;

namespace myUI
{
    public interface IMyUIView
    {
        Canvas MyCanvas { get;}
        bool HideOnClose { get; }
        bool HideAllOtherViews { get; }
        void SetViewModel(IMyUIViewModel viewModel);
    }
}