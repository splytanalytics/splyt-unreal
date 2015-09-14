namespace UnrealBuildTool.Rules
{
    public class SplytCore : ModuleRules
    {
        public SplytCore(TargetInfo Target)
        {
            PCHUsage = PCHUsageMode.NoSharedPCHs;

            PrivateIncludePaths.AddRange(
                new string[] {
                    "Runtime/SplytCore/Public/platform/unreal",
                    "Runtime/SplytCore/Public/vendor",
                    "Runtime/SplytCore/Public/src"
                }
                );

            PrivateDependencyModuleNames.AddRange(
                new string[] {
                    "Core",
                    "Engine",
                    "HTTP"
                }
                );
        }
    }
}
