Feature: Weather App Tests
	Gherkin tests
	
Scenario: App is started without a stored home city
	Given there is no stored home city
    When the app starts
    Then the input field should be empty
            
Scenario Outline: App is started with a stored home city
	Given that <homeCity> has been stored as the home city
	When the app starts
    Then the input field should contain the word <homeCity>

	Examples: 
	| homeCity |
	| London |

Scenario: Get My Weather-button is clicked without input
	Given there is no input in the input field 
    When the Get My Weather-button is clicked
    Then a warning message should be shown

Scenario Outline: Get My Weather-button is clicked with faulty input
	Given that <faultyInput> is entered in the input field
    When the Get My Weather-button is clicked
    Then a warning message should be shown

	Examples:
	| faultyInput |
	| NotAPlace123 |

Scenario Outline: Get My Weather-button is clicked with input
	Given that <input> is entered in the input field
    When the Get My Weather-button is clicked
    Then the app should display weather information on a new page

	Examples:
	| input  |
	| London |