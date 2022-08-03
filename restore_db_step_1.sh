#! /bin/bash

container_name=mssql
bak_file_path=../DB
bak_file_name=rps_db.bak
server_name=mssql
user=SA
sa_password=saPass1234

#Create a Folder for backup file into the container 
#IF FOLDER EXIST JUST COMMENT OUT

docker exec -it $container_name mkdir /var/opt/mssql/backups

#copy the bak file in container
docker cp $bak_file_path/$bak_file_name $container_name:/var/opt/mssql/backups

#Restore Your DB
#Step a: Get list of the files that were backed up in the file

docker exec -it $container_name /opt/mssql-tools/bin/sqlcmd -S $server_name -U $user -P $sa_password -Q 'RESTORE FILELISTONLY FROM DISK = "/var/opt/mssql/backups/'$bak_file_name\" | tr -s ' ' | cut -d ' ' -f 1-5



