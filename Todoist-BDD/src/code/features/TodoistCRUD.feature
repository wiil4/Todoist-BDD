Feature: TodoistCRUD

A scenario for testing LogIn feature of todoist
with valid username and password

@functionality @logIn 
Scenario: TC01LogIn
	Given A valid email and password
	| email                 | password    |
	| willcorreos@gmail.com | todoisttest |
	When I try to logIn
	Then I expect to be successfully LogedIn


@project-creation @functionality
Scenario: TC02Project Creation
	Given I am correctly logged in
	When I navigate to Projects
	And I try to add a new project with name "MojixProject"
	Then I expect the Add button to be enabled
	When I click on Add button
	Then I expect project to be displayed


@update-project-name @functionality
Scenario: TC03Updating Project Name
	Given I am correctly logged in
	When I hover on project with name "MojixProject"
	And I right click on it 
	And I click on edit project button
	And I change the project name to "Mojix2023"
	Then I expect the project name changed in projects list


@project-deletion @functionality
Scenario: TC04Delete Project
	Given I am correctly logged in
	When I hover on project with name "Mojix2023"
	And I right click on it
	And I click on delete project button
	And I confirm the project deletion
	Then I expect the project to be deleted