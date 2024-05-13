﻿// <auto-generated/>
// This file is generated by UnityDotG. Do not modify it manually.

using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter.VContainer;

namespace tana_gh.GalaxyInBottles
{
    public partial class RootLifetimeScope
    {
        [SerializeField] private ItemSetting[] _itemSettings;
    
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
        
            if (_itemSettings != null) builder.RegisterInstance(_itemSettings);
            builder.Register<SettingStore<ItemSetting>>(Lifetime.Scoped);
            builder.RegisterEntryPoint<RootEntryPoint>();
        }
    }
}
