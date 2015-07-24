namespace UnrealBuildTool.Rules
{
	public class SplytAnalytics : ModuleRules
	{
		public SplytAnalytics(TargetInfo Target)
		{
			PublicIncludePaths.AddRange(
				new string[] {
					// ... add public include paths required here ...
					//"Runtime/ThirdParty/SplytCore/Public/platform/unreal",
					//"Runtime/ThirdParty/SplytCore/Public/vendor",
					//"Runtime/ThirdParty/SplytCore/Public/src",
				}
				);

			PrivateIncludePaths.AddRange(
				new string[] {
					"Runtime/SplytAnalytics/Private",
					// ... add other private include paths required here ...
				}
				);

			PublicDependencyModuleNames.AddRange(
				new string[]
				{
					"Core",
					"SplytCore",
					// ... add other public dependencies that you statically link with here ...
				}
				);

			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
					// ... add private dependencies that you statically link with here ...
				}
				);

			DynamicallyLoadedModuleNames.AddRange(
				new string[]
				{
					// ... add any modules that your module loads dynamically here ...
				}
				);
		}
	}
}
