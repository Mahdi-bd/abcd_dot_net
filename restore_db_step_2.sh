#! /bin/bash
# Here The output of step 1 is 
#LogicalName 		PhysicalName 
#PT_Data 		C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALHOST\MSSQL\DATA\PT.mdf
#PT_Log 		C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALHOST\MSSQL\DATA\PT.ldf

#I means the we have to restore the "PT_Data" "PT_Log" 


data=rpd_db_1_Data
log=rpd_db_1_Log

container_name=mssql
server_name=mssql
user=SA
sa_password=saPass1234
db_name=rps_db
 
bak_file_name=rps_db.bak

cmd_conf=1

docker exec -it $container_name /opt/mssql-tools/bin/sqlcmd -S $server_name -U $user -P $sa_password -Q 'RESTORE DATABASE '$db_name' FROM DISK = "/var/opt/mssql/backups/'$bak_file_name'" WITH MOVE '\"$data\"' TO "/var/opt/mssql/data/'$db_name'_userdata.ndf", MOVE '\"$log\"' TO "/var/opt/mssql/data/'$db_name'_log.ldf"'

echo '..........List Of Databses.......'
docker exec -it $container_name /opt/mssql-tools/bin/sqlcmd -S $server_name -U $user -P $sa_password -Q 'SELECT Name FROM sys.Databases'

# For Sql CMD

read -p "Do You Want to enter sqlcmd (A CLI For Execute Sql Query) Enter - 1 If You Wish " IsSqlCmd

if [ $IsSqlCmd -eq $cmd_conf ]
then
docker exec -it $container_name /opt/mssql-tools/bin/sqlcmd -S $server_name -U $user -P $sa_password
else
echo Script Finished
fi



