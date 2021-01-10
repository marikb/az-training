#!/bin/bash
location="West US"
randomIdentifier=AsafSqlDemo

resource="marik-demo"
server="server-$randomIdentifier"
database="database-$randomIdentifier"

login="asaf"
password="bogdanbogdan1!"

#Configure my ip
myIp=`curl -4 ifconfig.co`

startIP=$myIp
endIP=$myIp

#echo "Creating $resource..."
#az group create --name $resource --location "$location"

echo "Creating $server in $location..."
az sql server create --name $server --resource-group $resource --location "$location" --admin-user $login --admin-password $password

echo "Configuring firewall..."
az sql server firewall-rule create --resource-group $resource --server $server -n AllowYourIp --start-ip-address $startIP --end-ip-address $endIP

#Create DBs
echo "Creating "$database-1" on $server..."
az sql db create --resource-group $resource --server $server --name "$database-1" --sample-name AdventureWorksLT --edition GeneralPurpose --family Gen5 --capacity 2 --zone-redundant false

echo "Creating "$database-2" on $server..."
az sql db create --resource-group $resource --server $server --name "$database-2" --sample-name AdventureWorksLT --edition GeneralPurpose --family Gen5 --capacity 2 --zone-redundant false