
$domain = "https://blazorui.stoicdreams.com"

$urls = [System.Collections.ArrayList]@();

$appsettings = Get-Content "AppSettings.cs"

$appsettings | Select-String -Pattern '(?<=NavDetail.Create\([^,]+,[^,]+, ?")([^"]+)(?=", ?UserRoles.Guest\))' | ForEach-Object { $_.Matches } | ForEach-Object {
	$item = @{url = $_.Value};
	$urls.Add($item) | Out-Null
}

function buildSitemap
{
	begin
	{
		'<?xml version="1.0" encoding="utf-8" ?>'
		'<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">'
	}

	process
	{
		'	<url>'
		"		<loc>$($domain)$($_.url)</loc>"
		"		<lastmod>{0:yyyy-MM-dd}</lastmod>" -f (Get-Date).Date
		'	</url>'
	}

	end
	{
		"</urlset>"
	}
}


$urls | buildSitemap | Out-File wwwroot/sitemap.xml -Encoding ascii
