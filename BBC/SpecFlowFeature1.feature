Feature: BBCNews
	In order to read different news online  
	As a user
	I want to be able to see news' titles so I can choose between them 

Scenario: Headline article name loaded successfully
    Given I am on the BBC home page
 	When I click on News Tab 
	Then I should see News page loading with the name of headline article visible on it