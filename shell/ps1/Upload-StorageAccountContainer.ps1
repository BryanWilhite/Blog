Push-Location $PSScriptRoot

$jsonPath = $args[0]

if (-not(Test-Path $jsonPath)) {
    Write-Warning "Cannot find path $jsonPath. Exiting script."
    exit
}

$settings = Get-Content -Path $jsonPath | ConvertFrom-Json

$azStorageCnn = $settings.ProgramMetadata.CloudStorageSet.SonghayCloudStorage."general-purpose-v1"

&az storage blob upload-batch `
    --connection-string $azStorageCnn `
    --content-encoding gzip `
    --content-type "applicaton/json" `
    --destination day-path-blog `
    --pattern "index-*.c.json" `
    --source ../Songhay.Publications.Tests/json
