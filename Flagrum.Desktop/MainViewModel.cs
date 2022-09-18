﻿using Flagrum.Desktop.Architecture;
using Flagrum.Web.Persistence;
using Flagrum.Web.Persistence.Entities;
using Flagrum.Web.Services;
using HelixToolkit.SharpDX.Core;
using HelixToolkit.SharpDX.Core.Animations;
using HelixToolkit.SharpDX.Core.Model.Scene;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Camera = HelixToolkit.Wpf.SharpDX.Camera;
using Geometry3D = HelixToolkit.SharpDX.Core.Geometry3D;
using Material = HelixToolkit.Wpf.SharpDX.Material;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;

namespace Flagrum.Desktop;

public class MainViewModel : ObservableObject, IDisposable
{
    private readonly List<BoneSkinMeshNode> _armatureNodes = new();
    private readonly CompositionTargetEx _compositeHelper = new();
    private readonly IEffectsManager? _effectsManager;
    private NodeAnimationUpdater? _animationUpdater;
    private Camera? _camera;

    private bool _hasWebView2Runtime;
    private bool _isViewportVisible;
    private Material _material;
    private Geometry3D _mesh;
    private SceneNodeGroupModel3D _modelGroup;
    private bool _showArmature;
    private int _viewportHeight;
    private int _viewportLeft = 514;
    private int _viewportTop;
    private int _viewportWidth;
    private string _viewportRotateGesture;
    private string _viewportPanGesture;

    public MainViewModel()
    {
        ViewportHelper = new ViewportHelper(this);
        EffectsManager = new DefaultEffectsManager();
        Camera = new PerspectiveCamera
        {
            Position = new Point3D(50, 30, 100),
            LookDirection = new Vector3D(-50, -30, -100),
            UpDirection = new Vector3D(0, 1, 0),
            NearPlaneDistance = 0,
            FarPlaneDistance = 10000
        };

        //TODO zet default values in de database
        //TODO lees uit de database de gestures en zet ze in de constructor...

        using var context = new FlagrumDbContext(new SettingsService());

        _viewportRotateGesture = context.GetString(StateKey.ViewportRotateGesture);
        _viewportPanGesture = context.GetString(StateKey.ViewportPanGesture);

        if (_viewportRotateGesture == null)
        {
            _viewportRotateGesture = "MiddleClick";
            context.SetString(StateKey.ViewportRotateGesture, _viewportRotateGesture);
        }

        if (_viewportPanGesture == null)
        {
            _viewportPanGesture = "Shift+MiddleClick";
            context.SetString(StateKey.ViewportPanGesture, _viewportPanGesture);
        }

        // var builder2 = new MeshBuilder();
        // builder2.AddSphere(new Vector3(), 2);
        // Mesh = builder2.ToMesh();
        // return;

        // var importer = new Importer();
        // importer.Configuration.CreateSkeletonForBoneSkinningMesh = true;
        // importer.Configuration.SkeletonSizeScale = 0.04f;
        // importer.Configuration.GlobalScale = 0.1f;
        //
        // var scene = importer.Load(@"C:\Users\Kieran\Desktop\nh00_010_animated.fbx");
        // //ModelGroup.AddNode(scene.Root);
        // BoneSkinMeshNode temp = null;
        // foreach (var node in scene.Root.Items.Traverse())
        // {
        //     if (node is BoneSkinMeshNode {IsSkeletonNode: true} n)
        //     {
        //         _armatureNodes.Add(n);
        //         n.Visible = false;
        //     }
        //
        //     if (node is BoneSkinMeshNode {IsSkeletonNode: false} m)
        //     {
        //         if (m.Name == "ShirtShape")
        //         {
        //             m.Material = new PBRMaterial
        //             {
        //                 AlbedoMap = TextureModel.Create(
        //                     @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\sourceimages\nh00_010_cloth_00_b_$h.png"),
        //                 NormalMap = TextureModel.Create(
        //                     @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\sourceimages\nh00_010_cloth_00_n_$h.png")
        //             };
        //
        //             temp = m;
        //         }
        //         else if (m.Name == "bodyShape")
        //         {
        //             m.Material = new PBRMaterial
        //             {
        //                 // AlbedoMap = TextureModel.Create(
        //                 //     @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\sourceimages\nh00_010_skin_01_b_$h.png"),
        //                 // NormalMap = TextureModel.Create(
        //                 //     @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\sourceimages\nh00_010_skin_01_n_$h.png")
        //                 AlbedoMap = TextureModel.Create(@"C:\Users\Kieran\Desktop\Cursed\diffuse.png"),
        //                 NormalMap = TextureModel.Create(@"C:\Users\Kieran\Desktop\Cursed\normal.png")
        //             };
        //         }
        //     }
        // }
        //return;


        //_animationUpdater = new NodeAnimationUpdater(scene.Animations.First());


        //_compositeHelper.Rendering += CompositeHelper_Rendering;
    }

    public ViewportHelper ViewportHelper { get; }
    public Viewport3DX Viewer { get; set; }

    public bool HasWebView2Runtime
    {
        get => _hasWebView2Runtime;
        set => SetValue(ref _hasWebView2Runtime, value);
    }

    public int ViewportLeft
    {
        get => _viewportLeft;
        set => SetValue(ref _viewportLeft, value);
    }

    public int ViewportTop
    {
        get => _viewportTop;
        set => SetValue(ref _viewportTop, value);
    }

    public int ViewportWidth
    {
        get => _viewportWidth;
        set => SetValue(ref _viewportWidth, value);
    }

    public int ViewportHeight
    {
        get => _viewportHeight;
        set => SetValue(ref _viewportHeight, value);
    }

    public string ViewportRotateGesture
    {
        get => _viewportRotateGesture;
        set => SetValue(ref _viewportRotateGesture, value);
    }

    public string ViewportPanGesture
    {
        get => _viewportPanGesture;
        set => SetValue(ref _viewportPanGesture, value);
    }

    public bool IsViewportVisible
    {
        get => _isViewportVisible;
        set => SetValue(ref _isViewportVisible, value);
    }

    public Camera? Camera
    {
        get => _camera;
        set => SetValue(ref _camera, value);
    }

    public IEffectsManager? EffectsManager
    {
        get => _effectsManager;
        private init => SetValue(ref _effectsManager, value);
    }

    public SceneNodeGroupModel3D ModelGroup
    {
        get => _modelGroup;
        set => SetValue(ref _modelGroup, value);
    }

    public bool ShowArmature
    {
        get => _showArmature;
        set
        {
            if (SetValue(ref _showArmature, value))
            {
                foreach (var node in _armatureNodes)
                {
                    node.Visible = value;
                }
            }
        }
    }

    public void Dispose()
    {
        if (EffectsManager != null)
        {
            var effectsManager = EffectsManager as IDisposable;
            Disposer.RemoveAndDispose(ref effectsManager);
        }

        GC.SuppressFinalize(this);
    }

    private void CompositeHelper_Rendering(object? sender, RenderingEventArgs e)
    {
        _animationUpdater?.Update(Stopwatch.GetTimestamp(), Stopwatch.Frequency);
    }
}