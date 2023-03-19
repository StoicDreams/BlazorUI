
$userprofile = $env:USERPROFILE
$searchfolder = "$userprofile\.nuget\packages\stoicdreams.blazorui"

Get-ChildItem -Path $searchfolder -Directory -Recurse -Force -Filter "staticwebassets" | ForEach-Object {
	Write-Host $_.FullName
	$indexfile = "$($_.FullName)\index.html"
	$indexbackup = "$($_.FullName)\index.backup.html"
	if (Test-Path -Path $indexbackup) {
		$content = Get-Content -Path $indexbackup
		$content | Set-Content -Path $indexfile
	}
}
