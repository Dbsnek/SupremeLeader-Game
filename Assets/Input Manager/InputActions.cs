// GENERATED AUTOMATICALLY FROM 'Assets/Input Manager/InputActions.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""d29efc65-a5e6-4500-88c2-cf5c7ed601ab"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1a78b797-d399-46ae-a0d0-64d4d843b812"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Abutton"",
                    ""type"": ""Button"",
                    ""id"": ""f6f5ffc2-3f9a-4746-9a0d-0c1e96b31574"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bbutton"",
                    ""type"": ""Button"",
                    ""id"": ""058249de-a292-4de2-96ab-1d84aa25a43a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Xbutton"",
                    ""type"": ""Button"",
                    ""id"": ""9780b04a-a6dd-4bfb-8f76-303a1fcc070f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ybutton"",
                    ""type"": ""Button"",
                    ""id"": ""b2e6d329-16b9-4f89-bfef-91ded8e60d0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Dpad"",
                    ""id"": ""41399bf7-2834-4af3-b1b1-e928b09131ae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78349bc9-a6d9-41cc-b544-04349017a84f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""748ae224-a67c-4f55-853d-51a0e9592f91"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2dee03b4-c753-47b6-afda-dda8555ba3d9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""93261caf-663b-4a8e-8356-fb465670872d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""4eeeec69-17e1-4d25-ab9b-7179b62ab834"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d9801f3f-2622-436c-8e3b-eea53b574de9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""904e4148-36dc-4efd-8b86-ca0dad9f1dba"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4110ac83-c73f-499a-a04e-8b407ccc5df8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fecf99e0-4ad2-44fd-8472-0dd02cc284db"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b4b421a7-f587-4603-8a5b-c2353bd5f7e3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Abutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee9f094f-cfa6-444e-8a0d-db295b31f3e4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Abutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f9e3773-fc13-4a99-96f8-3ca8eae8a8fc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Bbutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2021d462-8ad9-4b63-a60a-096c8b25bd8a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Bbutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbdc82d0-77f6-4c1a-96d2-8297fe5b574a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Xbutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c07b415-c54e-4a27-b511-990767facf9b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Xbutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5286204-bcc7-4aae-a8fa-b7f18875637e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Ybutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5390bb64-0631-4f52-bf90-d4c88ddb7f97"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Ybutton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gameplay"",
            ""bindingGroup"": ""Gameplay"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Abutton = m_Gameplay.FindAction("Abutton", throwIfNotFound: true);
        m_Gameplay_Bbutton = m_Gameplay.FindAction("Bbutton", throwIfNotFound: true);
        m_Gameplay_Xbutton = m_Gameplay.FindAction("Xbutton", throwIfNotFound: true);
        m_Gameplay_Ybutton = m_Gameplay.FindAction("Ybutton", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Abutton;
    private readonly InputAction m_Gameplay_Bbutton;
    private readonly InputAction m_Gameplay_Xbutton;
    private readonly InputAction m_Gameplay_Ybutton;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Abutton => m_Wrapper.m_Gameplay_Abutton;
        public InputAction @Bbutton => m_Wrapper.m_Gameplay_Bbutton;
        public InputAction @Xbutton => m_Wrapper.m_Gameplay_Xbutton;
        public InputAction @Ybutton => m_Wrapper.m_Gameplay_Ybutton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Abutton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbutton;
                @Abutton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbutton;
                @Abutton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbutton;
                @Bbutton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBbutton;
                @Bbutton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBbutton;
                @Bbutton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBbutton;
                @Xbutton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnXbutton;
                @Xbutton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnXbutton;
                @Xbutton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnXbutton;
                @Ybutton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYbutton;
                @Ybutton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYbutton;
                @Ybutton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYbutton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Abutton.started += instance.OnAbutton;
                @Abutton.performed += instance.OnAbutton;
                @Abutton.canceled += instance.OnAbutton;
                @Bbutton.started += instance.OnBbutton;
                @Bbutton.performed += instance.OnBbutton;
                @Bbutton.canceled += instance.OnBbutton;
                @Xbutton.started += instance.OnXbutton;
                @Xbutton.performed += instance.OnXbutton;
                @Xbutton.canceled += instance.OnXbutton;
                @Ybutton.started += instance.OnYbutton;
                @Ybutton.performed += instance.OnYbutton;
                @Ybutton.canceled += instance.OnYbutton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_GameplaySchemeIndex = -1;
    public InputControlScheme GameplayScheme
    {
        get
        {
            if (m_GameplaySchemeIndex == -1) m_GameplaySchemeIndex = asset.FindControlSchemeIndex("Gameplay");
            return asset.controlSchemes[m_GameplaySchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAbutton(InputAction.CallbackContext context);
        void OnBbutton(InputAction.CallbackContext context);
        void OnXbutton(InputAction.CallbackContext context);
        void OnYbutton(InputAction.CallbackContext context);
    }
}
