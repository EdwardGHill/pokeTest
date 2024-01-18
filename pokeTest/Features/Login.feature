Feature: Login

Valid users can login to the pokedex whilest invalid users cannot.


Scenario: Successful Login
	Given I open the Pokedex app
	And I enter a valid username 
	And I enter a valid password
	When I click the Login button
	#Then I am successfully logged in - haven't implemented yet



Scenario: Invalid Password
	Given I open the Pokedex app
	And I enter 'adamx123654' as my username
	And I enter 'this' as my password
	When I click the Login button
	Then A login error message is displayed



Scenario: Invalid UserName
	Given I open the Pokedex app
	And I enter 'not-a-user' as my username
	And I enter 'Qwertyuiop1!' as my password
	When I click the Login button
	Then A login error message is displayed

