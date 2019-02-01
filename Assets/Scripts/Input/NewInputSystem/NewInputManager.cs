// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/NewInputSystem/NewInputManager.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class NewInputManager : InputActionAssetReference
{
    public NewInputManager()
    {
    }
    public NewInputManager(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // MatchScene
        m_MatchScene = asset.GetActionMap("MatchScene");
        m_MatchScene_GenreateMap = m_MatchScene.GetAction("GenreateMap");
        m_MatchScene_Back = m_MatchScene.GetAction("Back");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_MatchSceneActionsCallbackInterface != null)
        {
            MatchScene.SetCallbacks(null);
        }
        m_MatchScene = null;
        m_MatchScene_GenreateMap = null;
        m_MatchScene_Back = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var MatchSceneCallbacks = m_MatchSceneActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        MatchScene.SetCallbacks(MatchSceneCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // MatchScene
    private InputActionMap m_MatchScene;
    private IMatchSceneActions m_MatchSceneActionsCallbackInterface;
    private InputAction m_MatchScene_GenreateMap;
    private InputAction m_MatchScene_Back;
    public struct MatchSceneActions
    {
        private NewInputManager m_Wrapper;
        public MatchSceneActions(NewInputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @GenreateMap { get { return m_Wrapper.m_MatchScene_GenreateMap; } }
        public InputAction @Back { get { return m_Wrapper.m_MatchScene_Back; } }
        public InputActionMap Get() { return m_Wrapper.m_MatchScene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(MatchSceneActions set) { return set.Get(); }
        public void SetCallbacks(IMatchSceneActions instance)
        {
            if (m_Wrapper.m_MatchSceneActionsCallbackInterface != null)
            {
                GenreateMap.started -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnGenreateMap;
                GenreateMap.performed -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnGenreateMap;
                GenreateMap.cancelled -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnGenreateMap;
                Back.started -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnBack;
                Back.performed -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnBack;
                Back.cancelled -= m_Wrapper.m_MatchSceneActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MatchSceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                GenreateMap.started += instance.OnGenreateMap;
                GenreateMap.performed += instance.OnGenreateMap;
                GenreateMap.cancelled += instance.OnGenreateMap;
                Back.started += instance.OnBack;
                Back.performed += instance.OnBack;
                Back.cancelled += instance.OnBack;
            }
        }
    }
    public MatchSceneActions @MatchScene
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new MatchSceneActions(this);
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get

        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.GetControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get

        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.GetControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
}
public interface IMatchSceneActions
{
    void OnGenreateMap(InputAction.CallbackContext context);
    void OnBack(InputAction.CallbackContext context);
}
