
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)





task Build {
    Remove-Item $PSScriptRoot/module -Recurse -Force -ErrorAction Ignore
}

task Clean {
    #Remove Module Build
    Remove-Item $PSScriptRoot/module -Recurse -Force -ErrorAction Ignore

    exec { & $script:dotnetExe clean -c $Configuration "$PSScriptRoot/src/$script:ModuleName/$script:ModuleName.csproj" }
    exec { & $script:dotnetExe clean -c $Configuration "$PSScriptRoot/src/OutGridView.Models/OutGridView.Models.csproj" }
    exec { & $script:dotnetExe clean -c $Configuration "$PSScriptRoot/src/OutGridView.Gui/OutGridView.Gui.csproj" }
    exec { & $script:dotnetExe clean -c $Configuration "$PSScriptRoot/src/Microsoft.PowerShell.GraphicalTools.MatterBridge/Microsoft.PowerShell.GraphicalTools.MatterBridge.csproj" }

    Get-ChildItem "$PSScriptRoot\module\$script:ModuleName\Commands\en-US\*-help.xml" -ErrorAction Ignore | Remove-Item -Force -ErrorAction Ignore
}
task . Clean, Build
#task . Clean, Build, BuildCmdletHelp, PackageModule, UploadArtifacts
