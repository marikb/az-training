#!/bin/bash
location="West US"
randomIdentifier=AsafSqlDemo

resource="marik-demo"
server="server-$randomIdentifier-new"
database="database-$randomIdentifier"

login="asaf"
password="bogdanbogdan1!"

#Configure my ip
myIp=`curl -4 ifconfig.co`

startIP=$myIp
endIP=$myIp

#TODO: remove echo "Creating $resource..."
#az group create --name $resource --location "$location"

echo "Creating $server in $location..."
az mysql server create --name "$server" --resource-group $resource --location "$location" --admin-user $login --admin-password $password

#Firewall rule
echo "Configuring firewall..."
az mysql server firewall-rule create --resource-group $resource --server $server -n AllowYourIp --start-ip-address $startIP --end-ip-address $endIP


az mysql server update --resource-group $resource --name $server --ssl-enforcement Disabled
mysql -h "$server.mysql.database.azure.com" -u "$login" -p

#Create DB
echo "Creating "$database-demo" on $server..."
CREATE DATABASE demodatabase;
#az sql db create --resource-group $resource --server $server --name "$database" --sample-name AdventureWorksLT --edition GeneralPurpose --family Gen5 --capacity 2 --zone-redundant false
USE demodatabase;


    CREATE TABLE Tblpersonstest (
        id serial PRIMARY KEY,
        FOREIGN KEY (cityId) REFERENCES Tblcities (cityId),
        firstname VARCHAR(50), 
        lastname VARCHAR(50),
        email VARCHAR(50), 
        password VARCHAR(50), 
        salary INTEGER,
        cityId INTEGER
    );

INSERT INTO Tblpersons (id, firstname, lastname,email,password,salary,cityid) VALUES (1, 'Asaf', 'Amir','Asaf@gmail.com','123',120,1); 

CREATE TABLE Tblcities (
	cityId serial PRIMARY KEY, 
	name VARCHAR(50)
);

INSERT INTO Tblcities (cityId, name) VALUES (1,'Hadera');
