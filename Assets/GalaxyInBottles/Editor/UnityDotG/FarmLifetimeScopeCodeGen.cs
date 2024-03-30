using System.Linq;
using tana_gh.UnityDotG.Editor;

namespace tana_gh.GalaxyInBottles.Editor
{
    [CodeGen]
    public class FarmLifetimeScopeCodeGen
    {
        public static void Generate(CodeGenContext context)
        {
            var settings = TypeAttributeUtil.GetAllTypesWithAttribute<SettingAttribute>();
            var handlers = TypeAttributeUtil.GetAllTypesWithAttribute<HandlerAttribute>();
            var messages = TypeAttributeUtil.GetAllTypesWithAttribute<MessageAttribute>();

            context.AutoGeneratedFolder = UnityDotGConstants.autoGeneratedFolder;
            context.AddCode("FarmLifetimeScope.g.cs",
$@"
using UnityEngine;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace tana_gh.GalaxyInBottles
{{
    public partial class FarmLifetimeScope
    {{{
        settings
        .Select(setting => $@"[SerializeField] private {setting.GetTypeName()} {setting.GetVarName()};")
        .ToLines(8)
    }
        protected override void Configure(IContainerBuilder builder)
        {{
            base.Configure(builder);
        {
            settings
            .Select(setting => $@"if ({setting.GetVarName()} != null) builder.RegisterInstance({setting.GetVarName()});")
            .ToLines(12)
        }{
            handlers
            .Select(handler => $@"builder.Register<{handler.GetTypeName()}>(Lifetime.Scoped);")
            .ToLines(12)
        }{
            (messages.Any() ? new string[] { $@"var options = builder.RegisterMessagePipe();" } : Enumerable.Empty<string>())
            .Concat(
                messages
                .Select(message => $@"builder.RegisterMessageBroker<{message.GetTypeName()}>(options);")
            )
            .ToLines(12)
        }
            builder.RegisterEntryPoint<FarmEntryPoint>();
        }}
    }}
}}
"
            );
        }
    }
}
