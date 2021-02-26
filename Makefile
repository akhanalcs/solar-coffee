#This is a makefile
#This is how it works
#target: dependencies
#	*This is one tab over*action
#
#Project Variables
PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

#Phony because migrations or db is not file but name of commands or targets
.PHONY: migrations db

#Go to SolarCoffee.Data dir, run this command and after the command go up with cd ..
#&& is used to link commands together
#$(mname) is an interpolation placeholder for passing migration name to it
migrations:
	cd ./SolarCoffee.Data && dotnet ef migrations add $(mname)  --startup-project ../SolarCoffee.Web/ && cd ..

db:
	cd ./SolarCoffee.Data && dotnet ef database update --startup-project ../SolarCoffee.Web/ && cd..
