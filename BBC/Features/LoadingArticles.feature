Feature: BBCNews
	In order to read different news online  
	As a user
	I want to be able to see news' titles so I can choose between them 

Scenario: Headline article name loaded successfully
    Given I am on the BBC home page
 	When I click on News Tab 
	Then I should see News page loading with the name of headline article visible on it


Scenario: Secondary articles' name loaded successfully
    Given I am on the BBC home page
	When I click on News Tab
	Then I should see News page loading with 15 secondary articles on it
	And The name of the first secondary article is [PLACEHOLDER]
	And The name of the last secondary article is [PLACEHOLDER]