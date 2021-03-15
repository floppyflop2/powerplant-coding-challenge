# powerplant-coding-challenge
exercise for gem spaas 

# Tests

To run the tests go in the directoy powerplant-coding-challenge\powerplant-coding-challenge-api\TestProject
and type the command "dotnet test"

# Build

To run the application:
  - go in the directoy powerplant-coding-challenge\powerplant-coding-challenge-api\powerplant-coding-challenge-api and execute the command 
  - "dotnet build"  
  - "dotnet run"

the port can be already in use if it's the case you have to change it in the file LaunchSetting.json

note that there is many config files in the NLog.config you can set: 
  - internalLogFile with the path for the internal logs
  - fileName with the path for the differents logs such as exception

# NB
The solution could be enhance by checking if the actual load is inferior to the pmin of the powerplant try to use another one to avoid loss 
 
