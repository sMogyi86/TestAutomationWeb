Feature: BeadandoSpecflowTest

Scenario: Fill out the questionnaire
	Given I open the survey's webpage
	When Choose the first question
	And I answer it with 2
	Then the UI shall react by changing the answer to 2