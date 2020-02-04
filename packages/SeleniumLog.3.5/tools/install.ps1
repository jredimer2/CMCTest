param($installPath, $toolsPath, $package, $project)

$file1 = $project.ProjectItems.Item("SLConfig.xml")
 
$copyToOutput1 = $file1.Properties.Item("CopyToOutputDirectory")
$copyToOutput1.Value = 1