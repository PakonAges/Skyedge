﻿using UnityEngine;

namespace FieldGameplay
{
    public interface ITouchProcessor
    {
        void TapOnObject(Transform tappedObject);
        void PanObject(Transform pannedObject, float panX, float panY);
    }
}