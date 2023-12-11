# for install sql server in docker 
``
docker pull mcr.microsoft.com/mssql/server
``

# to running sql server in docker 
``
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123" -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server
``

# to stop the sql server in docker 
``
docker stop sql_server_container
``

# connection string 
``
"Server=localhost,1433;Database=dataBaseName;User=sa;Password=YourPassword123;Encrypt=False;"
``