Push-Location $PSScriptRoot

$accountName = "songhaystorage"
$containerName = "rasx-context-blog"

$accountKey = "o9yYN8V5A/JqdJAjPpZj9AN3PizChq6Y697kld5681Tqe+GgzB8BqtdF6DaPj3yLfoP0DFW2BD1CxMhiYBTPWg=="

$path = "..\Songhay.Publications.Tests\json"

Get-ChildItem -Path $path -Filter "index-*.c.json" | `
    ForEach-Object {
        &az storage blob upload --container-name $containerName `
        --file $_.FullName `
        --name $_.Name `
        --account-key $accountKey `
        --account-name $accountName `
        --auth-mode key `
        --content-cache-control "max-age=864000,public,must-revalidate" `
        --content-encoding "gzip" `
        --content-type "application/json"
    }
