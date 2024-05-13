using System;
using System.Linq;
using tana_gh.UnityDotG.Editor;

namespace tana_gh.GalaxyInBottles.Editor
{
    [CodeGen]
    public class SandboxLifetimeScopeCodeGen
    {
        public static void Generate(CodeGenContext context)
        {
            context.AutoGeneratedFolder = UnityDotGConstants.AutoGeneratedFolder;

            foreach (var sceneKind in Enum.GetValues(typeof(SceneKind)).Cast<SceneKind>())
            {
                GenerateOne(context, sceneKind);
            }
        }

        public static void GenerateOne(CodeGenContext context, SceneKind sceneKind)
        {
            var settings = RoleAttributeUtil.GetAllTypesWithRole("Setting", sceneKind);
            var settingArrays = RoleAttributeUtil.GetAllTypesWithRole("SettingArray", sceneKind);
            var settingStores = RoleAttributeUtil.GetAllTypesWithRole("SettingStore", sceneKind);
            var handlers = RoleAttributeUtil.GetAllTypesWithRole("Handler", sceneKind);

            context.AddCode($"{sceneKind}LifetimeScope.g.cs",
$@"
using UnityEngine;
using VContainer;
using VContainer.Unity;
using VitalRouter.VContainer;

namespace tana_gh.GalaxyInBottles
{{
    public partial class {sceneKind}LifetimeScope
    {{{
        settings
        .Select(setting => $@"[SerializeField] private {setting.GetTypeName()} {setting.GetVarName(false)};")
        .ToLines(8)
    }{
        settingArrays
        .Select(settingArray => $@"[SerializeField] private {settingArray.GetTypeName()}[] {settingArray.GetArrayVarName(false)};")
        .ToLines(8)
    }
    
        protected override void Configure(IContainerBuilder builder)
        {{
            base.Configure(builder);
        {
            settings
            .Select(setting => $@"if ({setting.GetVarName(false)} != null) builder.RegisterInstance({setting.GetVarName(false)});")
            .ToLines(12)
        }{
            settingArrays
            .Select(settingArray => $@"if ({settingArray.GetArrayVarName(false)} != null) builder.RegisterInstance({settingArray.GetArrayVarName(false)});")
            .ToLines(12)
        }{
            settingStores
            .Select(settingStore => $@"builder.Register<{settingStore.GetTypeName()}>(Lifetime.Scoped);")
            .ToLines(12)
        }{
            handlers
            .Select(handler => $@"builder.Register<{handler.GetTypeName()}>(Lifetime.Scoped);")
            .ToLines(12)
        }{
            (
                handlers.Any() ?
                new string[] { $@"builder.RegisterVitalRouter(routing =>", $@"{{" }
                .Concat(handlers.Select(handler => $@"    routing.Map<{handler.GetTypeName()}>();"))
                .Concat(new string[] { $@"}});" }) :
                Enumerable.Empty<string>()
            )
            .ToLines(12)
        }
            builder.RegisterEntryPoint<{sceneKind}EntryPoint>();
        }}
    }}
}}
"
            );
        }
    }
}
