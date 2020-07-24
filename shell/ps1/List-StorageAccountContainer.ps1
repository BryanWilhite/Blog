Push-Location $PSScriptRoot

$accountName = "songhaystorage"
$containerName = "day-path-blog"

$accountKey = "o9yYN8V5A/JqdJAjPpZj9AN3PizChq6Y697kld5681Tqe+GgzB8BqtdF6DaPj3yLfoP0DFW2BD1CxMhiYBTPWg=="

&az storage blob list --container-name $containerName `
    --account-key $accountKey `
    --account-name $accountName `
    --auth-mode key > ..\az-storage-account-container-list.json
