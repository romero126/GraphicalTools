Measure-Command { Invoke-Build Build }
#pwsh-preview -c "Import-Module '$PSScriptRoot/module/Microsoft.PowerShell.GraphicalTools'; Get-Process | Out-GridView -PassThru"






pwsh-preview -c {
    Get-ChildItem $pwd/Module/Microsoft.PowerShell.GraphicalTools
    #Import-Module '$PSScriptRoot/module/Microsoft.PowerShell.GraphicalTools'; 
    #Get-Item $pwd/Module/Microsoft.PowerShell.GraphicalTools/Microsoft.PowerShell.GraphicalTools.dll
    Add-Type -path "$pwd/Module/Microsoft.PowerShell.GraphicalTools/Microsoft.PowerShell.GraphicalTools.dll"

    $MatterBridge = [Microsoft.PowerShell.GraphicalTools.MatterBridge]::new()
    $MatterBridge  | ft -a

}