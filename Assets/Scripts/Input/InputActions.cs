// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""ac7af241-e15f-48f9-9c22-ff6568bd2ffb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""27b28fba-82f8-46b5-a75c-630137dda358"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a68cdf86-b312-4081-951c-24ee0fb0225f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""0eb84159-ce68-4752-9f9a-850d16fbf3fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Overdrive"",
                    ""type"": ""Button"",
                    ""id"": ""fa1031e8-1a5e-47ee-bdfc-5c89bfc5be68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""01ab2953-3d54-4209-a877-34605655b5f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""71d034ce-c49a-4702-8a9e-b1e6879152a1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a62f930e-165f-4a9d-ba26-8a5c59211fe6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ed7efb81-5bef-42f6-901a-9b228d4bcffa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dd9c5463-8d9f-48df-ad26-e684f8bdad1f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e9770c11-6935-422d-8be2-4d95353ed148"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1df9af12-faee-4a6d-bdcd-45d8d2475aba"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f88727f4-8c6d-47c9-98df-e76da8fd277f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a963e0b-540e-4053-bfac-273f54872b8e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Overdrive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2547bec-0340-49bf-92ab-5ad7ee2d0cb6"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Overdrive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f8a8f80-8192-453d-b7e0-c6ceebcc6b12"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""c0223446-95a9-47bc-bb13-29589222e3b3"",
            ""actions"": [
                {
                    ""name"": ""Unpause"",
                    ""type"": ""Button"",
                    ""id"": ""cdd7c549-76b5-4898-9d3a-b79dec0da5f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21867c83-00f0-4314-a577-d8450bcb1421"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Input"",
                    ""action"": ""Unpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Input"",
            ""bindingGroup"": ""Input"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Fire = m_GamePlay.FindAction("Fire", throwIfNotFound: true);
        m_GamePlay_Dodge = m_GamePlay.FindAction("Dodge", throwIfNotFound: true);
        m_GamePlay_Overdrive = m_GamePlay.FindAction("Overdrive", throwIfNotFound: true);
        m_GamePlay_Pause = m_GamePlay.FindAction("Pause", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_Unpause = m_PauseMenu.FindAction("Unpause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Fire;
    private readonly InputAction m_GamePlay_Dodge;
    private readonly InputAction m_GamePlay_Overdrive;
    private readonly InputAction m_GamePlay_Pause;
    public struct GamePlayActions
    {
        private @InputActions m_Wrapper;
        public GamePlayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Fire => m_Wrapper.m_GamePlay_Fire;
        public InputAction @Dodge => m_Wrapper.m_GamePlay_Dodge;
        public InputAction @Overdrive => m_Wrapper.m_GamePlay_Overdrive;
        public InputAction @Pause => m_Wrapper.m_GamePlay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Fire.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Dodge.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDodge;
                @Overdrive.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Overdrive.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Overdrive.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOverdrive;
                @Pause.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Overdrive.started += instance.OnOverdrive;
                @Overdrive.performed += instance.OnOverdrive;
                @Overdrive.canceled += instance.OnOverdrive;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_Unpause;
    public struct PauseMenuActions
    {
        private @InputActions m_Wrapper;
        public PauseMenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Unpause => m_Wrapper.m_PauseMenu_Unpause;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @Unpause.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
                @Unpause.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
                @Unpause.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnpause;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Unpause.started += instance.OnUnpause;
                @Unpause.performed += instance.OnUnpause;
                @Unpause.canceled += instance.OnUnpause;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
    private int m_InputSchemeIndex = -1;
    public InputControlScheme InputScheme
    {
        get
        {
            if (m_InputSchemeIndex == -1) m_InputSchemeIndex = asset.FindControlSchemeIndex("Input");
            return asset.controlSchemes[m_InputSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnOverdrive(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnUnpause(InputAction.CallbackContext context);
    }
}
