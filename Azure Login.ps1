$subscription_name = ''

try {
    Get-AzureRmSubscription -ErrorAction SilentlyContinue | Out-Null
} catch {
    Login-AzureRmAccount -ErrorAction Stop
}
Select-AzureRmSubscription -SubscriptionName $subscription_name -ErrorAction Stop