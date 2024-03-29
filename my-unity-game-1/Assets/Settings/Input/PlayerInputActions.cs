//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Settings/Input/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Birdy
{
    public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""WorldCamera"",
            ""id"": ""e14be6c7-3b10-4f36-a403-0530c141d4e9"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""Value"",
                    ""id"": ""1081f2c6-e3f3-4c8b-95f0-c7a219871335"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""9b963163-1cd8-4442-9225-a8e5b1fa651d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PanDrag"",
                    ""type"": ""Button"",
                    ""id"": ""980d8d3f-edaa-4f7c-84a7-568b1c7db38d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Activate"",
                    ""type"": ""Button"",
                    ""id"": ""4d3eb00c-1d84-45f8-b35a-6498d9e0649d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelActivate"",
                    ""type"": ""Button"",
                    ""id"": ""2aa8005b-e5d6-4cdf-b072-e09c27f08a87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Append"",
                    ""type"": ""Button"",
                    ""id"": ""859ea2e1-37d4-4b02-8418-105500e2d7fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""de77af39-6254-4f74-8a2f-c57020135343"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Redo"",
                    ""type"": ""Button"",
                    ""id"": ""955ba23b-8116-4992-b380-d68b982e38c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DefaultCommand"",
                    ""type"": ""Button"",
                    ""id"": ""2c123b76-3416-47ab-ab7f-31f4f5dcca2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""2162a357-e732-451d-95be-e63032870d6e"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b13b6fc8-c2ba-4db0-8f3f-8f726b84c805"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""630a2ddd-55c9-4a93-b273-07b341b9ffe5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4edfdf5d-5653-4e00-b77f-36d6f369a718"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e64277b9-c2c4-4f32-bbcc-767d0afc2628"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c09cdde0-d165-424e-b86f-0fa292816236"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3825050d-1e3d-402b-a4eb-34ce8335de7c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""PanDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e92d62c1-5ef6-487f-bffd-169b8dcebeb7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4cf2510-4b3f-49b5-a865-a34072c58a36"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""CancelActivate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6172692-1420-4448-b7b8-f85e978dc03c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""CancelActivate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d2c16ee-7716-46e3-adc6-e621eda690dc"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Append"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""328edfdd-7bc6-49e7-a364-3909971afbe4"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""6cea13f2-5139-4a70-8319-bbb302281665"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""d4edb9f4-4382-4112-97f8-0878535c675a"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""b076d063-1725-4daa-8f7e-9f91af5c631c"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3529e85b-5222-4c33-b000-2cabddf5f43f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""85794f66-d12f-4bca-9635-a5f3cec119c5"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Redo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""055281d4-1462-4835-aa57-835f0f81e7e9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DefaultCommand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UnitCommands"",
            ""id"": ""de9dcf0c-4a92-41fe-988c-0117e396a660"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b2e38d6e-529c-4f52-a461-4ea810beb9a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""a921ef66-0f63-4225-a46a-82e834eb16b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""a81b652c-4873-4a4a-879e-7eaf8a1973af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Repair"",
                    ""type"": ""Button"",
                    ""id"": ""d39e441a-338d-45b5-862f-fe715ddba862"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Follow"",
                    ""type"": ""Button"",
                    ""id"": ""433dc1c5-0748-4785-8c9b-532742d7935a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""636ec567-9c00-45d2-9efa-27043b0d7b72"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56e2b900-a2f9-4969-8504-31dcfbce8670"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54da27af-dff0-4d43-b8da-0ae7dfbf7193"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0126ecb6-4619-4874-9489-135d9f0f6d0c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Repair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84340806-c152-46ff-9956-77141b960051"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Follow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
        },
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
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // WorldCamera
            m_WorldCamera = asset.FindActionMap("WorldCamera", throwIfNotFound: true);
            m_WorldCamera_Pan = m_WorldCamera.FindAction("Pan", throwIfNotFound: true);
            m_WorldCamera_Zoom = m_WorldCamera.FindAction("Zoom", throwIfNotFound: true);
            m_WorldCamera_PanDrag = m_WorldCamera.FindAction("PanDrag", throwIfNotFound: true);
            m_WorldCamera_Activate = m_WorldCamera.FindAction("Activate", throwIfNotFound: true);
            m_WorldCamera_CancelActivate = m_WorldCamera.FindAction("CancelActivate", throwIfNotFound: true);
            m_WorldCamera_Append = m_WorldCamera.FindAction("Append", throwIfNotFound: true);
            m_WorldCamera_Undo = m_WorldCamera.FindAction("Undo", throwIfNotFound: true);
            m_WorldCamera_Redo = m_WorldCamera.FindAction("Redo", throwIfNotFound: true);
            m_WorldCamera_DefaultCommand = m_WorldCamera.FindAction("DefaultCommand", throwIfNotFound: true);
            // UnitCommands
            m_UnitCommands = asset.FindActionMap("UnitCommands", throwIfNotFound: true);
            m_UnitCommands_Move = m_UnitCommands.FindAction("Move", throwIfNotFound: true);
            m_UnitCommands_Attack = m_UnitCommands.FindAction("Attack", throwIfNotFound: true);
            m_UnitCommands_Build = m_UnitCommands.FindAction("Build", throwIfNotFound: true);
            m_UnitCommands_Repair = m_UnitCommands.FindAction("Repair", throwIfNotFound: true);
            m_UnitCommands_Follow = m_UnitCommands.FindAction("Follow", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // WorldCamera
        private readonly InputActionMap m_WorldCamera;
        private List<IWorldCameraActions> m_WorldCameraActionsCallbackInterfaces = new List<IWorldCameraActions>();
        private readonly InputAction m_WorldCamera_Pan;
        private readonly InputAction m_WorldCamera_Zoom;
        private readonly InputAction m_WorldCamera_PanDrag;
        private readonly InputAction m_WorldCamera_Activate;
        private readonly InputAction m_WorldCamera_CancelActivate;
        private readonly InputAction m_WorldCamera_Append;
        private readonly InputAction m_WorldCamera_Undo;
        private readonly InputAction m_WorldCamera_Redo;
        private readonly InputAction m_WorldCamera_DefaultCommand;
        public struct WorldCameraActions
        {
            private @PlayerInputActions m_Wrapper;
            public WorldCameraActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pan => m_Wrapper.m_WorldCamera_Pan;
            public InputAction @Zoom => m_Wrapper.m_WorldCamera_Zoom;
            public InputAction @PanDrag => m_Wrapper.m_WorldCamera_PanDrag;
            public InputAction @Activate => m_Wrapper.m_WorldCamera_Activate;
            public InputAction @CancelActivate => m_Wrapper.m_WorldCamera_CancelActivate;
            public InputAction @Append => m_Wrapper.m_WorldCamera_Append;
            public InputAction @Undo => m_Wrapper.m_WorldCamera_Undo;
            public InputAction @Redo => m_Wrapper.m_WorldCamera_Redo;
            public InputAction @DefaultCommand => m_Wrapper.m_WorldCamera_DefaultCommand;
            public InputActionMap Get() { return m_Wrapper.m_WorldCamera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldCameraActions set) { return set.Get(); }
            public void AddCallbacks(IWorldCameraActions instance)
            {
                if (instance == null || m_Wrapper.m_WorldCameraActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_WorldCameraActionsCallbackInterfaces.Add(instance);
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @PanDrag.started += instance.OnPanDrag;
                @PanDrag.performed += instance.OnPanDrag;
                @PanDrag.canceled += instance.OnPanDrag;
                @Activate.started += instance.OnActivate;
                @Activate.performed += instance.OnActivate;
                @Activate.canceled += instance.OnActivate;
                @CancelActivate.started += instance.OnCancelActivate;
                @CancelActivate.performed += instance.OnCancelActivate;
                @CancelActivate.canceled += instance.OnCancelActivate;
                @Append.started += instance.OnAppend;
                @Append.performed += instance.OnAppend;
                @Append.canceled += instance.OnAppend;
                @Undo.started += instance.OnUndo;
                @Undo.performed += instance.OnUndo;
                @Undo.canceled += instance.OnUndo;
                @Redo.started += instance.OnRedo;
                @Redo.performed += instance.OnRedo;
                @Redo.canceled += instance.OnRedo;
                @DefaultCommand.started += instance.OnDefaultCommand;
                @DefaultCommand.performed += instance.OnDefaultCommand;
                @DefaultCommand.canceled += instance.OnDefaultCommand;
            }

            private void UnregisterCallbacks(IWorldCameraActions instance)
            {
                @Pan.started -= instance.OnPan;
                @Pan.performed -= instance.OnPan;
                @Pan.canceled -= instance.OnPan;
                @Zoom.started -= instance.OnZoom;
                @Zoom.performed -= instance.OnZoom;
                @Zoom.canceled -= instance.OnZoom;
                @PanDrag.started -= instance.OnPanDrag;
                @PanDrag.performed -= instance.OnPanDrag;
                @PanDrag.canceled -= instance.OnPanDrag;
                @Activate.started -= instance.OnActivate;
                @Activate.performed -= instance.OnActivate;
                @Activate.canceled -= instance.OnActivate;
                @CancelActivate.started -= instance.OnCancelActivate;
                @CancelActivate.performed -= instance.OnCancelActivate;
                @CancelActivate.canceled -= instance.OnCancelActivate;
                @Append.started -= instance.OnAppend;
                @Append.performed -= instance.OnAppend;
                @Append.canceled -= instance.OnAppend;
                @Undo.started -= instance.OnUndo;
                @Undo.performed -= instance.OnUndo;
                @Undo.canceled -= instance.OnUndo;
                @Redo.started -= instance.OnRedo;
                @Redo.performed -= instance.OnRedo;
                @Redo.canceled -= instance.OnRedo;
                @DefaultCommand.started -= instance.OnDefaultCommand;
                @DefaultCommand.performed -= instance.OnDefaultCommand;
                @DefaultCommand.canceled -= instance.OnDefaultCommand;
            }

            public void RemoveCallbacks(IWorldCameraActions instance)
            {
                if (m_Wrapper.m_WorldCameraActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IWorldCameraActions instance)
            {
                foreach (var item in m_Wrapper.m_WorldCameraActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_WorldCameraActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public WorldCameraActions @WorldCamera => new WorldCameraActions(this);

        // UnitCommands
        private readonly InputActionMap m_UnitCommands;
        private List<IUnitCommandsActions> m_UnitCommandsActionsCallbackInterfaces = new List<IUnitCommandsActions>();
        private readonly InputAction m_UnitCommands_Move;
        private readonly InputAction m_UnitCommands_Attack;
        private readonly InputAction m_UnitCommands_Build;
        private readonly InputAction m_UnitCommands_Repair;
        private readonly InputAction m_UnitCommands_Follow;
        public struct UnitCommandsActions
        {
            private @PlayerInputActions m_Wrapper;
            public UnitCommandsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_UnitCommands_Move;
            public InputAction @Attack => m_Wrapper.m_UnitCommands_Attack;
            public InputAction @Build => m_Wrapper.m_UnitCommands_Build;
            public InputAction @Repair => m_Wrapper.m_UnitCommands_Repair;
            public InputAction @Follow => m_Wrapper.m_UnitCommands_Follow;
            public InputActionMap Get() { return m_Wrapper.m_UnitCommands; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UnitCommandsActions set) { return set.Get(); }
            public void AddCallbacks(IUnitCommandsActions instance)
            {
                if (instance == null || m_Wrapper.m_UnitCommandsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_UnitCommandsActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Repair.started += instance.OnRepair;
                @Repair.performed += instance.OnRepair;
                @Repair.canceled += instance.OnRepair;
                @Follow.started += instance.OnFollow;
                @Follow.performed += instance.OnFollow;
                @Follow.canceled += instance.OnFollow;
            }

            private void UnregisterCallbacks(IUnitCommandsActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Build.started -= instance.OnBuild;
                @Build.performed -= instance.OnBuild;
                @Build.canceled -= instance.OnBuild;
                @Repair.started -= instance.OnRepair;
                @Repair.performed -= instance.OnRepair;
                @Repair.canceled -= instance.OnRepair;
                @Follow.started -= instance.OnFollow;
                @Follow.performed -= instance.OnFollow;
                @Follow.canceled -= instance.OnFollow;
            }

            public void RemoveCallbacks(IUnitCommandsActions instance)
            {
                if (m_Wrapper.m_UnitCommandsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IUnitCommandsActions instance)
            {
                foreach (var item in m_Wrapper.m_UnitCommandsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_UnitCommandsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public UnitCommandsActions @UnitCommands => new UnitCommandsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_TouchSchemeIndex = -1;
        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        private int m_XRSchemeIndex = -1;
        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }
        public interface IWorldCameraActions
        {
            void OnPan(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnPanDrag(InputAction.CallbackContext context);
            void OnActivate(InputAction.CallbackContext context);
            void OnCancelActivate(InputAction.CallbackContext context);
            void OnAppend(InputAction.CallbackContext context);
            void OnUndo(InputAction.CallbackContext context);
            void OnRedo(InputAction.CallbackContext context);
            void OnDefaultCommand(InputAction.CallbackContext context);
        }
        public interface IUnitCommandsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnBuild(InputAction.CallbackContext context);
            void OnRepair(InputAction.CallbackContext context);
            void OnFollow(InputAction.CallbackContext context);
        }
    }
}
