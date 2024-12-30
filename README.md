# ibm-mq-test
An example of .NET 8 using IBM MQ

# Docker YML for IBM MQ
Run the IMB MQ on a Docker Container.
Find the file **ibm-mq.yml** on the **Docker** folder.

## Container Usage
We assuming your LINUX or WSL are ready to run Docker Containers
 - Copy the file to a Linux folder on your preference
 - Go to the respective Linux Folder
 - Type the command **docker compose -f ibm-mq.yml up** (if you preffer to run on background on your terminal, use **docker compose -f ibm-mq.yml up -d**)
 
   NOTE: You can change the YML file by your own, changing the App or Admin Password

## Console Using
To access the IBM MQ  Console use the following URL
 - https://localhost:9443/ibmmq/console/
 - Use amdin user and password values on the runnig container YML file

   NOTE: **localhost** can be replaced by your running Container IP Device
