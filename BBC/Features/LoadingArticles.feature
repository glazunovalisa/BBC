Feature: BBCNews
	In order to read different news online  
	As a user
	I want to be able to see news' titles so I can choose between them 


Background: 
        Given I am on the BBC home page
        When I click on News Tab

Scenario: Headline article name loaded successfully
	Then I should see News page loading with the name of headline article visible on it

Scenario: Correct number of secondary articles loaded 
	Then I should see News page loading with 15 secondary articles on it

Scenario: The name of the first secondary article is as expected
	Then The name of the first secondary article is [PLACEHOLDER]

Scenario: The name of the last secondary article is as expected
	Then The name of the last secondary article is [PLACEHOLDER]
