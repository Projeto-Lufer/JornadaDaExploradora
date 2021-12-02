// GENERATED AUTOMATICALLY FROM 'Assets/_Game/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Character actions"",
            ""id"": ""f05d443c-9aa5-44c3-8148-a980f743cad2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""731614d8-f28c-4b32-99f9-9b5f6e5c78d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""b702263f-4819-4925-9e58-df6d93d79436"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7646d5f5-af57-4a24-9f35-1edbcf7005ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""ea5cc2e4-94c0-4311-99dd-517f092d5484"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""460ca8a4-5f59-4dd8-a3b6-8763df8ba5c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""07aaab63-92ce-4f16-be6e-5b7bca00ca86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""b17f45b4-f183-444d-b086-9cb3b8568be2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7f9efcef-c428-4251-9bec-b6adf025a18e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""9ed5e953-cece-4903-96e7-3f270b80b2fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""38993a15-e09a-4025-b9e7-09902e66f28f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SpinPlayerInUI"",
                    ""type"": ""Value"",
                    ""id"": ""18f9d6f1-c50f-458a-b4fa-36cd0b540b21"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""35b063d6-d5e8-46f3-9d82-253e6f9fe15a"",
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
                    ""id"": ""42e0c353-589c-4fab-a2c6-62cfc82059e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""907c7b27-4ed2-443f-9c9a-7863ff036a96"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""61dfcc12-117d-479b-98b0-4d38694b66b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""593526d0-e69d-46e9-be02-c86f6e1371e4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d36b8c08-0aed-41b6-ac10-9cced03f2a9e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.5)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""308b304b-173f-4f25-a683-5989787d5787"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9118628f-3d18-406c-b095-ffae947dd0c0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66027e3a-f7f8-495f-8a4d-eb8476308291"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a021064d-0de5-4671-87ab-e2974c9036c6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b1ca91-87c5-4703-961f-7cecac21fc13"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87248d45-ccd0-4993-b4c1-9a6ef8565741"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de2aec2b-f115-4ce8-85d2-18a2058854a2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13529dbd-8f35-4f9a-9570-f7adc47ee2f1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c440aff0-4487-4360-82fc-8aa307e225c8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""569465ce-b89a-4522-8521-d15bacc115c5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0d13d31-86c1-4b35-8cbc-2caa88aabe90"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""942628be-c4f0-45ad-b8b4-fc5989ec1909"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2756b08-91ae-4dc8-b83b-b2ea99735ef4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc213efa-3eaf-4aeb-a877-599689afa8ac"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a58753ff-4c3e-43ec-8d5d-0768a836f701"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d75bf349-ae6a-4fb5-bfdc-159b757111cd"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf14f716-447c-49db-a6a5-45396a83f7f4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6a3d748-c878-4a10-aeca-a095671d3ba4"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7641508c-05e9-4e41-ab5f-d9641b14a350"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0febc0c-6a3f-433a-8b41-00f845a6222b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5fc61609-adec-4c02-8e5a-12f0d3e72478"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2c0178dc-44d4-4415-a3a6-9c005d03e493"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""95c60114-c144-417d-918b-07ee139d0389"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""62ea2a2b-1a67-42d2-a580-377a6007773f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""91c754b0-5a35-44fe-9bbe-bdb84d58a1b4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpinPlayerInUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard & mouse"",
            ""bindingGroup"": ""Keyboard & mouse"",
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
        // Character actions
        m_Characteractions = asset.FindActionMap("Character actions", throwIfNotFound: true);
        m_Characteractions_Move = m_Characteractions.FindAction("Move", throwIfNotFound: true);
        m_Characteractions_Escape = m_Characteractions.FindAction("Escape", throwIfNotFound: true);
        m_Characteractions_Interact = m_Characteractions.FindAction("Interact", throwIfNotFound: true);
        m_Characteractions_Attack1 = m_Characteractions.FindAction("Attack1", throwIfNotFound: true);
        m_Characteractions_Attack2 = m_Characteractions.FindAction("Attack2", throwIfNotFound: true);
        m_Characteractions_Cancel = m_Characteractions.FindAction("Cancel", throwIfNotFound: true);
        m_Characteractions_Defend = m_Characteractions.FindAction("Defend", throwIfNotFound: true);
        m_Characteractions_Jump = m_Characteractions.FindAction("Jump", throwIfNotFound: true);
        m_Characteractions_LeftTrigger = m_Characteractions.FindAction("LeftTrigger", throwIfNotFound: true);
        m_Characteractions_RightTrigger = m_Characteractions.FindAction("RightTrigger", throwIfNotFound: true);
        m_Characteractions_SpinPlayerInUI = m_Characteractions.FindAction("SpinPlayerInUI", throwIfNotFound: true);
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

    // Character actions
    private readonly InputActionMap m_Characteractions;
    private ICharacteractionsActions m_CharacteractionsActionsCallbackInterface;
    private readonly InputAction m_Characteractions_Move;
    private readonly InputAction m_Characteractions_Escape;
    private readonly InputAction m_Characteractions_Interact;
    private readonly InputAction m_Characteractions_Attack1;
    private readonly InputAction m_Characteractions_Attack2;
    private readonly InputAction m_Characteractions_Cancel;
    private readonly InputAction m_Characteractions_Defend;
    private readonly InputAction m_Characteractions_Jump;
    private readonly InputAction m_Characteractions_LeftTrigger;
    private readonly InputAction m_Characteractions_RightTrigger;
    private readonly InputAction m_Characteractions_SpinPlayerInUI;
    public struct CharacteractionsActions
    {
        private @PlayerControls m_Wrapper;
        public CharacteractionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Characteractions_Move;
        public InputAction @Escape => m_Wrapper.m_Characteractions_Escape;
        public InputAction @Interact => m_Wrapper.m_Characteractions_Interact;
        public InputAction @Attack1 => m_Wrapper.m_Characteractions_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_Characteractions_Attack2;
        public InputAction @Cancel => m_Wrapper.m_Characteractions_Cancel;
        public InputAction @Defend => m_Wrapper.m_Characteractions_Defend;
        public InputAction @Jump => m_Wrapper.m_Characteractions_Jump;
        public InputAction @LeftTrigger => m_Wrapper.m_Characteractions_LeftTrigger;
        public InputAction @RightTrigger => m_Wrapper.m_Characteractions_RightTrigger;
        public InputAction @SpinPlayerInUI => m_Wrapper.m_Characteractions_SpinPlayerInUI;
        public InputActionMap Get() { return m_Wrapper.m_Characteractions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacteractionsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacteractionsActions instance)
        {
            if (m_Wrapper.m_CharacteractionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnMove;
                @Escape.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnEscape;
                @Interact.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnInteract;
                @Attack1.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack1;
                @Attack2.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnAttack2;
                @Cancel.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnCancel;
                @Defend.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnDefend;
                @Defend.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnDefend;
                @Defend.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnDefend;
                @Jump.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnJump;
                @LeftTrigger.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnLeftTrigger;
                @RightTrigger.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnRightTrigger;
                @SpinPlayerInUI.started -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnSpinPlayerInUI;
                @SpinPlayerInUI.performed -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnSpinPlayerInUI;
                @SpinPlayerInUI.canceled -= m_Wrapper.m_CharacteractionsActionsCallbackInterface.OnSpinPlayerInUI;
            }
            m_Wrapper.m_CharacteractionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Defend.started += instance.OnDefend;
                @Defend.performed += instance.OnDefend;
                @Defend.canceled += instance.OnDefend;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @SpinPlayerInUI.started += instance.OnSpinPlayerInUI;
                @SpinPlayerInUI.performed += instance.OnSpinPlayerInUI;
                @SpinPlayerInUI.canceled += instance.OnSpinPlayerInUI;
            }
        }
    }
    public CharacteractionsActions @Characteractions => new CharacteractionsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    public interface ICharacteractionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnSpinPlayerInUI(InputAction.CallbackContext context);
    }
}
