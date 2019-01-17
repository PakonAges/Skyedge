﻿using System.Threading.Tasks;

public interface IUiManager
{
    Task OpenWindowAsync(UIViewType window);
    void CloseWindow(IUiView window);
    void CloseTopWindow();
    void CloseAll();
}
